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

    public partial class TipoCapacidade
    {
        /// <summary>
        /// Initializes a new instance of the TipoCapacidade class.
        /// </summary>
        public TipoCapacidade() { }

        /// <summary>
        /// Initializes a new instance of the TipoCapacidade class.
        /// </summary>
        public TipoCapacidade(int? idTpCapacidade = default(int?), string cdSap = default(string), string dsTpCapacidade = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdTpCapacidade = idTpCapacidade;
            CdSap = cdSap;
            DsTpCapacidade = dsTpCapacidade;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_tp_capacidade")]
        public int? IdTpCapacidade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_tp_capacidade")]
        public string DsTpCapacidade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

    }
}