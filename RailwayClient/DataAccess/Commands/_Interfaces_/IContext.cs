using RailwayClient.DataAccess.SettingsEF;

namespace RailwayClient.DataAccess.Commands
{
    /// <summary>
    ///     Интерфейс, позволяющий определять контекст, согласно которому будут удалены записи
    /// </summary>
    public interface IContext
    {
        IUnitOfWork GetUnitOfWork();
    }
}