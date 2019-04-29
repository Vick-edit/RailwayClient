using System;
using System.Collections.Generic;
using System.Linq;
using RailwayClient.DataAccess.Entities;
using RailwayClient.DTO;

namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Получить список данных, представляющих строки из отчёта
    /// </summary>
    public class QueryAllReportRow : IQuery<GetAllCriterion, List<ReportRowDTO>>
    {
        /// <inheritdoc />
        public List<ReportRowDTO> Execute(GetAllCriterion criterion)
        {
            using (var dbConnection = criterion.GetUnitOfWork())
            {
                return dbConnection.Set<Station>()
                    .GroupBy(s => s.Railway)
                    .Select(group => new ReportRowDTO()
                    {
                        RailwayName = group.Key != null ? group.Key.Name : "_null_",
                        AmountOfFreightStation = group.Count(station => station.FreightSign),
                        TotalStationAmount = group.Count(),
                        LastUpdatedStation = group.GroupBy(station => station.DateUpdate)
                            .OrderByDescending(stationGroup => stationGroup.Key) //Поиск последней обновлённой
                            .First()    
                            .OrderBy(stationGroup => stationGroup.Name)          //Среди обновлённых в один период сортируем по имени
                            .Select(stationFromGroup => stationFromGroup.Name)
                            .First(),
                    })
                    .ToList();
            }
        }
    }
}