namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Интерфейс запроса на получение данных
    /// </summary>
    /// <typeparam name="TCriterion">Тип критерия по которому будут отбираться данные</typeparam>
    /// <typeparam name="TResult">Тип данных, результата запроса к БД, не обязательно одна сущность</typeparam>
    public interface IQuery<in TCriterion, out TResult>
        where TCriterion : ICriterion
    {
        /// <summary> Выполнить запрос с заданными параметрами </summary>
        /// <param name="criterion">Объект с параметрами фильтрации записей в БД</param>
        /// <returns>Контейнер с результатами запроса(Одна сущность или список сущностей)</returns>
        TResult Execute(TCriterion criterion);
    }
}