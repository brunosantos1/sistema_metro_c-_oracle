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

    public partial class Complemento
    {
        /// <summary>
        /// Initializes a new instance of the Complemento class.
        /// </summary>
        public Complemento() { }

        /// <summary>
        /// Initializes a new instance of the Complemento class.
        /// </summary>
        public Complemento(int? idComplemento = default(int?), string dsComplemento = default(string), int? idGrcodeSistemaFk = default(int?), GrupoCode grCodeSistema = default(GrupoCode), BaseModel baseModel = default(BaseModel))
        {
            IdComplemento = idComplemento;
            DsComplemento = dsComplemento;
            IdGrcodeSistemaFk = idGrcodeSistemaFk;
            GrCodeSistema = grCodeSistema;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_complemento")]
        public int? IdComplemento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_complemento")]
        public string DsComplemento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_grcode_sistema_fk")]
        public int? IdGrcodeSistemaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GrCodeSistema")]
        public GrupoCode GrCodeSistema { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.GrCodeSistema != null)
            {
                this.GrCodeSistema.Validate();
            }
        }
    }
}