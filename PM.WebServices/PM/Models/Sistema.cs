﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace PM.WebServices.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Sistema
    {
        /// <summary>
        /// Initializes a new instance of the Sistema class.
        /// </summary>
        public Sistema() { }

        /// <summary>
        /// Initializes a new instance of the Sistema class.
        /// </summary>
        public Sistema(int? idSistema = default(int?), string nmSistema = default(string), int? idFrotaFk = default(int?), BaseModel baseModel = default(BaseModel), Frota frota = default(Frota))
        {
            IdSistema = idSistema;
            NmSistema = nmSistema;
            IdFrotaFk = idFrotaFk;
            BaseModel = baseModel;
            Frota = frota;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_sistema")]
        public int? IdSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_sistema")]
        public string NmSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_frota_fk")]
        public int? IdFrotaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Frota")]
        public Frota Frota { get; set; }

    }
}