using System;
using System.Collections.Generic;
using RailwayClient.DataAccess.Entities;
using RailwayClient.DataAccess.SettingsEF;
using RestSharp;
using RestSharp.Serialization;

namespace RailwayClient.Domain
{
    /// <summary>
    ///     Класс для доступа к сервису со всеми справочниками
    /// </summary>
    public class RailwayRestClient : IRailwayRestClient
    {
        private const string HOST_URL = "https://vpn.ugmk-trans.com:44395";
        private const string SERVICE_METHOD = "api/info/{catalogue}/getall";
        private const string RAILWAY_CATALOGUE = "Railway";
        private const string STATION_CATALOGUE = "Station";

        private readonly IRestSerializer _restSerializer;


        public RailwayRestClient(IRestSerializer restSerializer)
        {
            _restSerializer = restSerializer;
        }


        /// <inheritdoc />
        public List<Railway> GetRailways()
        {
            var client = new RestClient(HOST_URL)
                .UseSerializer(() => _restSerializer);

            var request = new RestRequest(SERVICE_METHOD);
            request.AddUrlSegment("catalogue", RAILWAY_CATALOGUE);

            var response = client.Get<List<Railway>>(request);
            if (response == null || !response.IsSuccessful)
                throw new Exception($"Ошибка обращения к сервису - {response?.ResponseStatus}");

            return response.Data;
        }

        /// <inheritdoc />
        public List<Station> GetStation()
        {
            var client = new RestClient(HOST_URL)
                .UseSerializer(() => _restSerializer);

            var request = new RestRequest(SERVICE_METHOD);
            request.AddUrlSegment("catalogue", STATION_CATALOGUE);

            var response = client.Get<List<Station>>(request);
            if (response == null || !response.IsSuccessful)
                throw new Exception($"Ошибка обращения к сервису - {response?.ResponseStatus}");

            return response.Data;
        }
    }
}