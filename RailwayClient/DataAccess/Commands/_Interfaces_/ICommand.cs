namespace RailwayClient.DataAccess.Commands
{
    /// <summary>
    ///     Интерфейс запроса на преобразование данных
    /// </summary>
    /// <typeparam name="TContext">Тип объекта-контейнера, содержащего объекты для изменений</typeparam>
    public interface ICommand<in TContext>
        where TContext : IContext
    {
        /// <summary> Выполнить запрос на преобразование данных в бд </summary>
        /// <param name="сontext">Объект-контейнер для данных, которые будут изменены</param>
        void Execute(TContext сontext);
    }
}