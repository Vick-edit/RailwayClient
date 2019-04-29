using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using RailwayClient.DataAccess.Entities;
using RailwayClient.DataAccess.SettingsEF;

namespace RailwayClient.DataAccess.Commands
{
    /// <summary>
    ///     Контекст для команды полной замены справочников
    /// </summary>
    public class СatalogueUpdateContext : IContext
    {
        public IList<Railway> Railways { get; }
        public IList<Station> Stations { get; }


        public СatalogueUpdateContext(IList<Railway> railways, IList<Station> stations)
        {
            Railways = railways;
            Stations = stations;
            ValidateСatalogues();
        }


        /// <inheritdoc />
        public IUnitOfWork GetUnitOfWork()
        {
            return new RailwayContext();
        }

        private void ValidateСatalogues()
        {
            if (Railways == null || !Railways.Any())
                throw new ArgumentException("Список ж/д дорог должен быть задан");
            if (Stations == null || !Stations.Any())
                throw new ArgumentException("Список ж/д станций должен быть задан");

            bool isAnyBadExternalRefferences = Stations
                .Any(station => station.RailwayId != null 
                                && Railways.All(railway => railway.Id != station.RailwayId));

            if (isAnyBadExternalRefferences)
                throw new ArgumentException("Некоторые станции содержат ссылки на дороги, которых нет");
            if (Railways.Any(r => r.Id <= 0))
                throw new ArgumentException("Индентефикаторы ж/д дорог должны быть больше 0");
            if (Stations.Any(s => s.Code <= 0))
                throw new ArgumentException("Индентефикаторы станций должны быть больше 0");
        }
    }
}