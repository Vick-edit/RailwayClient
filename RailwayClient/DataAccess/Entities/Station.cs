using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace RailwayClient.DataAccess.Entities
{
    /// <summary>
    ///     Сущность ж/д станции
    /// </summary>
    public class Station
    {
        /// <summary> Код станции (Первичный ключ) </summary>
        [Key]
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary> Идентификатор дороги </summary>
        [JsonProperty(PropertyName = "railwayID")]
        public int? RailwayId { get; set; }
        public Railway Railway { get; set; }

        /// <summary> Идентификатор станции </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary> Идентификатор отделения дороги </summary>
        [JsonProperty(PropertyName = "railwayDepartmentID")]
        public int RailwayDepartmentId { get; set; }

        /// <summary> Идентификатор страны </summary>
        [JsonProperty(PropertyName = "countryID")]
        public int CountryId { get; set; }

        /// <summary> 12-символьное наименование станции </summary>
        [MaxLength(12)]
        [JsonProperty(PropertyName = "name12Char")]
        public string Name12Char { get; set; }

        /// <summary> 40-символьное наименование станции </summary>
        [MaxLength(40)]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary> Признак станции, открытой для грузовой работы </summary>
        [JsonProperty(PropertyName = "freightSign")]
        public bool FreightSign { get; set; }

        /// <summary> Код станции с контрольным знаком </summary>
        [JsonProperty(PropertyName = "codeOSGD")]
        public string CodeOSGD { get; set; }

        /// <summary> Дата создания записи </summary>
        [JsonProperty(PropertyName = "dateCreate")]
        public DateTime DateCreate { get; set; }

        /// <summary> Дата обновления записи </summary>
        [JsonProperty(PropertyName = "dateUpdate")]
        public DateTime DateUpdate { get; set; }
    }
}