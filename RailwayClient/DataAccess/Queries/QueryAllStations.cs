using System.Collections.Generic;
using System.Linq;
using RailwayClient.DataAccess.Entities;

namespace RailwayClient.DataAccess.Queries
{
    /// <summary>
    ///     Достать из БД все ж/д стнации
    /// </summary>
    public class QueryAllStations : IQuery<GetAllCriterion, List<Station>>
    {
        /// <inheritdoc />
        public List<Station> Execute(GetAllCriterion criterion)
        {
            using (var dbConnection = criterion.GetUnitOfWork())
            {
                return dbConnection.Set<Station>().ToList();
            }
        }
    }
}