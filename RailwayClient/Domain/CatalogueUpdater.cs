using RailwayClient.DataAccess.Commands;

namespace RailwayClient.Domain
{
    /// <summary>
    ///     Выгрузки нового справочника с сервера и обновления данных в БД
    /// </summary>
    public class CatalogueUpdater : ICatalogueUpdater
    {
        private readonly IRailwayRestClient _restClient;
        private readonly ICommandBuilder _commandBuilder;

        public CatalogueUpdater(IRailwayRestClient restClient, ICommandBuilder commandBuilder)
        {
            _restClient = restClient;
            _commandBuilder = commandBuilder;
        }

        /// <inheritdoc />
        public void UpdateCatalogue()
        {
            var newRailways = _restClient.GetRailways();
            var newStations = _restClient.GetStation();

            var updateCatalogueContext = new СatalogueUpdateContext(newRailways, newStations);
            _commandBuilder.ExecuteCommand(updateCatalogueContext);
        }
    }
}