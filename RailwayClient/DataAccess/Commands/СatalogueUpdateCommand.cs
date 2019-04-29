using System;
using RailwayClient.DataAccess.Entities;

namespace RailwayClient.DataAccess.Commands
{
    /// <summary>
    ///     Команда для полной замены справочников
    /// </summary>
    public class СatalogueUpdateCommand : ICommand<СatalogueUpdateContext>
    {
        /// <inheritdoc />
        public void Execute(СatalogueUpdateContext сontext)
        {
            using (var dbConnection = сontext.GetUnitOfWork())
            {
                dbConnection.Set<Railway>().RemoveRange(dbConnection.Set<Railway>());
                dbConnection.Set<Station>().RemoveRange(dbConnection.Set<Station>());

                dbConnection.Set<Railway>().AddRange(сontext.Railways);
                dbConnection.Set<Station>().AddRange(сontext.Stations);

                dbConnection.Commit();
            }
        }
    }
}