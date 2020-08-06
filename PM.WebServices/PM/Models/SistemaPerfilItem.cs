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

    public partial class SistemaPerfilItem
    {
        /// <summary>
        /// Initializes a new instance of the SistemaPerfilItem class.
        /// </summary>
        public SistemaPerfilItem() { }

        /// <summary>
        /// Initializes a new instance of the SistemaPerfilItem class.
        /// </summary>
        public SistemaPerfilItem(int? idPerfilItem = default(int?), int? idPerfilFk = default(int?), bool? flgAcessar = default(bool?), bool? flgIncluir = default(bool?), bool? flgAlterar = default(bool?), bool? flgExportar = default(bool?), bool? flgImprimir = default(bool?), BaseModel baseModel = default(BaseModel))
        {
            IdPerfilItem = idPerfilItem;
            IdPerfilFk = idPerfilFk;
            FlgAcessar = flgAcessar;
            FlgIncluir = flgIncluir;
            FlgAlterar = flgAlterar;
            FlgExportar = flgExportar;
            FlgImprimir = flgImprimir;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_perfilItem")]
        public int? IdPerfilItem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_perfil_fk")]
        public int? IdPerfilFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "flg_Acessar")]
        public bool? FlgAcessar { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "flg_Incluir")]
        public bool? FlgIncluir { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "flg_Alterar")]
        public bool? FlgAlterar { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "flg_Exportar")]
        public bool? FlgExportar { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "flg_Imprimir")]
        public bool? FlgImprimir { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

    }
}