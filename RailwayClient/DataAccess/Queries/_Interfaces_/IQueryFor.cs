namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Интерфейс инжекстора параметров в запрос <see cref="IQuery{TCriterion,TEntity}"/> через объекты типа <see cref="ICriterion"/>
    /// </summary>
    /// <typeparam name="TResult">Тип данных, возвращаемый запросом</typeparam>
    public interface IQueryFor<out TResult>
    {
        /// <summary> Задать параметры выборки <see cref="ICriterion"/> для объектов БД </summary>
        /// <typeparam name="TCriterion">Тип критерия, который может быть использован для построения запроса</typeparam>
        /// <param name="criterion">Объект, хронящий информацию о параметрах выборки объектов БД</param>
        /// <returns>Результаты запроса к БД</returns>
        TResult With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion;
    }
}