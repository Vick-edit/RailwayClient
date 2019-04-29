namespace RailwayClient.DTO
{
    /// <summary>
    ///     Класс представляет одну строку отчёты
    /// </summary>
    public class ReportRowDTO
    {
        public const string RailwayNameColumn = "Наименование ж/д дороги";
        public const string LastUpdatedStationColumn = "Наименование последней обновленной станции";
        public const string AmountOfFreightStationColumn = "Кол-во станций открытых для грузовой работы";
        public const string TotalStationAmountColumn = "Общее кол-во станций на дороге";


        public string RailwayName { get; set; }

        public string LastUpdatedStation { get; set; }

        public int AmountOfFreightStation { get; set; }

        public int TotalStationAmount { get; set; }
    }
}