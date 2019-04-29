using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using RailwayClient.DataAccess.Queries;
using RailwayClient.DTO;

namespace RailwayClient.Domain
{
    /// <summary>
    ///     Сборка и построение отчёта в Excel
    /// </summary>
    public class ExcelReporter : IExcelReporter
    {
        private const string EXCEL_FILE_NAME = @".\Report.xlsx";
        private const string WORKSHEET_NAME = @"ReportWorksheet";

        private readonly IQueryBuilder _queryBuilder;


        public ExcelReporter(IQueryBuilder queryBuilder)
        {
            _queryBuilder = queryBuilder;
        }


        /// <inheritdoc />
        public void Buildreport()
        {
            bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null;
            if(!isExcelInstalled)
                throw new Exception("На рабочей станции не установлен Microsoft Excel");

            var reportsRows = _queryBuilder.For<List<ReportRowDTO>>().With(new GetAllCriterion());
            var freightStationSum = reportsRows.Sum(x => x.AmountOfFreightStation);
            var totalStationSum = reportsRows.Sum(x => x.TotalStationAmount);

            BuildExcelTable(reportsRows, freightStationSum, totalStationSum);
        }


        private async void BuildExcelTable(List<ReportRowDTO> reportsRows, int freightStationSum, int totalStationSum)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add(WORKSHEET_NAME);
                using (var excelWorksheet = excel.Workbook.Worksheets[WORKSHEET_NAME])
                {
                    /*Заголовок*/
                    var rowNumber = 1;
                    var headerColumnRange = $"A{rowNumber}:D{rowNumber}";
                    var headers = new List<string[]> 
                    {
                        new string[]
                        {
                            ReportRowDTO.RailwayNameColumn,
                            ReportRowDTO.LastUpdatedStationColumn,
                            ReportRowDTO.AmountOfFreightStationColumn,
                            ReportRowDTO.TotalStationAmountColumn
                        },
                    };
                    excelWorksheet.Cells[headerColumnRange].LoadFromArrays(headers);
                    excelWorksheet.Cells[headerColumnRange].Style.Font.Bold = true;
                    excelWorksheet.Cells[headerColumnRange].Style.Font.Size = 12;
                    excelWorksheet.Cells[headerColumnRange].Style.WrapText = true;
                    excelWorksheet.Cells[headerColumnRange].AutoFitColumns();
                    excelWorksheet.Cells[headerColumnRange].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    excelWorksheet.Column(1).Width = 29.3;
                    excelWorksheet.Column(2).Width = 27.86;
                    excelWorksheet.Column(3).Width = 26.43;
                    excelWorksheet.Column(4).Width = 24.43;
                    excelWorksheet.View.FreezePanes(2,1);

                    /*Строки*/
                    foreach (var reportsRow in reportsRows)
                    {
                        rowNumber++;
                        excelWorksheet.Cells[$"A{rowNumber}"].Value = reportsRow.RailwayName;
                        excelWorksheet.Cells[$"B{rowNumber}"].Value = reportsRow.LastUpdatedStation;
                        excelWorksheet.Cells[$"C{rowNumber}"].Value = reportsRow.AmountOfFreightStation;
                        excelWorksheet.Cells[$"D{rowNumber}"].Value = reportsRow.TotalStationAmount;
                    }

                    /*Итого*/
                    rowNumber++;
                    var footerRange = $"A{rowNumber}:B{rowNumber}";
                    excelWorksheet.Cells[footerRange].Merge = true;
                    excelWorksheet.Cells[footerRange].Value = "Итого:";
                    excelWorksheet.Cells[footerRange].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    excelWorksheet.Cells[$"C{rowNumber}"].Value = freightStationSum;
                    excelWorksheet.Cells[$"D{rowNumber}"].Value = totalStationSum;

                    /*Сетка*/
                    var allTableRange = $"A1:D{rowNumber}";
                    excelWorksheet.Cells[allTableRange].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    excelWorksheet.Cells[allTableRange].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    excelWorksheet.Cells[allTableRange].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    excelWorksheet.Cells[allTableRange].Style.Border.Right.Style = ExcelBorderStyle.Thin;


                    /*Сохранение*/
                    FileInfo excelFile = new FileInfo(EXCEL_FILE_NAME);
                    if (excelFile.Exists)
                        excelFile.Delete();
                    excel.SaveAs(excelFile);
                }
            }

            await Task.Run(() => System.Diagnostics.Process.Start(EXCEL_FILE_NAME));
        }
    }
}