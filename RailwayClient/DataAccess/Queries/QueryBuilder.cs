using System;
using RailwayClient.Extensions;

namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Основная реализация <see cref="IQueryBuilder"/>, класс практически не содержит логики
    ///     основная задача класса, что он позволяет использовать критерии <see cref="ICriterion"/>,
    ///     которые мапятся в соответствующие <see cref="IQuery{TCriterion,TResult}"/>
    /// </summary>
    public class QueryBuilder : IQueryBuilder
    {
        private readonly IServiceProvider _serviceProvider;


        public QueryBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        /// <inheritdoc />
        public IQueryFor<TResult> For<TResult>()
        {
            return new QueryFor<TResult>(_serviceProvider);
        }


        #region Приватная реализация IQueryFor
        /// <summary>
        ///     Приватная реализация <see cref="IQueryFor"/>, позволяющая строить запросы на базе DI
        /// </summary>
        /// <typeparam name="TResult">Тип данных, возвращаемый запросом</typeparam>
        private class QueryFor<TResult> : IQueryFor<TResult>
        {
            private readonly IServiceProvider _serviceProvider;


            public QueryFor(IServiceProvider serviceProvider)
            {
                _serviceProvider = serviceProvider;
            }


            /// <inheritdoc />
            public TResult With<TCriterion>(TCriterion criterion) where TCriterion : ICriterion
            {
                var query = _serviceProvider.Resolve<IQuery<TCriterion, TResult>>();
                return query.Execute(criterion);
            }
        }

        #endregion
    }
}