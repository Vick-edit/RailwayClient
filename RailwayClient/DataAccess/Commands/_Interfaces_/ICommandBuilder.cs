namespace RailwayClient.DataAccess.Commands
{
    /// <summary>
    ///     Интерфейс обновления данных в БД через объекты типа <see cref="ICommand{TContext}"/>
    /// </summary>
    public interface ICommandBuilder
    {
        /// <summary> Найти и выполнить команду </summary>
        /// <typeparam name="TContext">Тип данных контекста, позволяющего выбрать даные для команды</typeparam>
        void ExecuteCommand<TContext>(TContext context) where TContext : IContext;
    }
}