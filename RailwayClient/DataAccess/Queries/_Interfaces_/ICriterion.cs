using RailwayClient.DataAccess.SettingsEF;

namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Интерфейс, позволяющий хронить в классах параметры выборки объектов, траслируемые потом в SQL запросы
    /// </summary>
    public interface ICriterion
    {
        IUnitOfWork GetUnitOfWork();
    }
}