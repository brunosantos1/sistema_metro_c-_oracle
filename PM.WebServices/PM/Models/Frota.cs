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

    public partial class Frota
    {
        /// <summary>
        /// Initializes a new instance of the Frota class.
        /// </summary>
        public Frota() { }

        /// <summary>
        /// Initializes a new instance of the Frota class.
        /// </summary>
        public Frota(int? idFrota = default(int?), string nmFrota = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdFrota = idFrota;
            NmFrota = nmFrota;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_frota")]
        public int? IdFrota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_frota")]
        public string NmFrota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

    }
}