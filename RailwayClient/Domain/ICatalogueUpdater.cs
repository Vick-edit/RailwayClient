namespace RailwayClient.Domain
{
    /// <summary>
    ///     Интерфейс выгрузки нового справочника с сервера и обновления данных в БД
    /// </summary>
    public interface ICatalogueUpdater
    {
        void UpdateCatalogue();
    }
}