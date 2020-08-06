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

    public partial class UnidadeMedida
    {
        /// <summary>
        /// Initializes a new instance of the UnidadeMedida class.
        /// </summary>
        public UnidadeMedida() { }

        /// <summary>
        /// Initializes a new instance of the UnidadeMedida class.
        /// </summary>
        public UnidadeMedida(int? idUnidadeMedida = default(int?), string dsUnidadeMedida = default(string), string txRelativoDimensao = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdUnidadeMedida = idUnidadeMedida;
            DsUnidadeMedida = dsUnidadeMedida;
            TxRelativoDimensao = txRelativoDimensao;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_unidade_medida")]
        public int? IdUnidadeMedida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_unidade_medida")]
        public string DsUnidadeMedida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tx_relativo_dimensao")]
        public string TxRelativoDimensao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

    }
}