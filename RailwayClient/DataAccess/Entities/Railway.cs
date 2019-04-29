using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RailwayClient.DataAccess.Entities
{
    /// <summary>
    ///     Сущность ж/д дороги
    /// </summary>
    public class Railway
    {
        /// <summary> Идентификатор дороги (Первичный ключ) </summary>
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary> Код дороги </summary>
        [JsonProperty(PropertyName = "code")]
        public short Code { get; set; }

        /// <summary> Наименование полное </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary> Наименование сокращенное </summary>
        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }

        /// <summary> Условный идентификатор страны дороги </summary>
        [JsonProperty(PropertyName = "countryID")]
        public int CountryId { get; set; }

        /// <summary> Короткое наименование для телеграфа </summary>
        [JsonProperty(PropertyName = "telegraphName")]
        public string TelegraphName { get; set; }

        /// <summary> Дата создания записи </summary>
        [JsonProperty(PropertyName = "dateCreate")]
        public DateTime DateCreate { get; set; }

        /// <summary> Дата обновления записи </summary>
        [JsonProperty(PropertyName = "dateUpdate")]
        public DateTime DateUpdate { get; set; }
    }
}