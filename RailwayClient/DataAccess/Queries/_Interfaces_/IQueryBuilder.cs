namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Интерфейс доступа к данным из БД через объекты типа <see cref="IQuery{TCriterion,TEntity}"/>
    /// </summary>
    public interface IQueryBuilder
    {
        /// <summary> Получить инжектор условий выборки данных <see cref="IQueryFor{TResult}"/> </summary>
        /// <typeparam name="TResult">Тип данных резльтата запроса к БД</typeparam>
        /// <returns>Инжектор параметров запроса для объектов типа <see cref="TResult"/></returns>
        IQueryFor<TResult> For<TResult>();
    }
}