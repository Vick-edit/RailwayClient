using RailwayClient.DataAccess.SettingsEF;

namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Критерий для выборки всех записей
    /// </summary>
    public class GetAllCriterion : ICriterion
    {
        /// <inheritdoc />
        public IUnitOfWork GetUnitOfWork()
        {
            return new RailwayContext();
        }
    }
}