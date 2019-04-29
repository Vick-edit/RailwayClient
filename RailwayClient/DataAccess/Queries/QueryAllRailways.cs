using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using RailwayClient.DataAccess.Entities;

namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Достать из БД все ж/д дороги
    /// </summary>
    public class QueryAllRailways : IQuery<GetAllCriterion, List<Railway>>
    {
        /// <inheritdoc />
        public List<Railway> Execute(GetAllCriterion criterion)
        {
            using (var dbConnection = criterion.GetUnitOfWork())
            {
                return dbConnection.Set<Railway>().ToList();
            }
        }
    }
}