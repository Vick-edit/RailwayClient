using System.Collections.Generic;
using RailwayClient.DataAccess.Entities;

namespace RailwayClient.Domain
{
    /// <summary>
    ///     Интерфейс, доступа к данным 
    /// </summary>
    public interface IRailwayRestClient
    {
        /// <summary> Получить список всех ж/д дорог </summary>
        List<Railway> GetRailways();

        /// <summary> Получить список всех ж/д станций </summary>
        List<Station> GetStation();
    }
}