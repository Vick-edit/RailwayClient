namespace RailwayClient.Domain
{
    /// <summary>
    ///     Интерфейс сборки отчёта Excel
    /// </summary>
    public interface IExcelReporter
    {
        /// <summary> Собрать данные и построить отчёт </summary>
        void Buildreport();
    }
}