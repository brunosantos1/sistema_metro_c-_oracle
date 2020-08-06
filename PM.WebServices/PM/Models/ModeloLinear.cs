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

    public partial class ModeloLinear
    {
        /// <summary>
        /// Initializes a new instance of the ModeloLinear class.
        /// </summary>
        public ModeloLinear() { }

        /// <summary>
        /// Initializes a new instance of the ModeloLinear class.
        /// </summary>
        public ModeloLinear(int? idMdRfLinear = default(int?), string cdSap = default(string), string dsModelo = default(string), string tpModelo = default(string), bool? cdDiMarcador = default(bool?), int? idUnDiMarcadorFk = default(int?), BaseModel baseModel = default(BaseModel), UnidadeMedida unidadeMedida = default(UnidadeMedida))
        {
            IdMdRfLinear = idMdRfLinear;
            CdSap = cdSap;
            DsModelo = dsModelo;
            TpModelo = tpModelo;
            CdDiMarcador = cdDiMarcador;
            IdUnDiMarcadorFk = idUnDiMarcadorFk;
            BaseModel = baseModel;
            UnidadeMedida = unidadeMedida;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_md_rf_linear")]
        public int? IdMdRfLinear { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_modelo")]
        public string DsModelo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tp_modelo")]
        public string TpModelo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_di_marcador")]
        public bool? CdDiMarcador { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_di_marcador_fk")]
        public int? IdUnDiMarcadorFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedida")]
        public UnidadeMedida UnidadeMedida { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdSap != null)
            {
                if (this.CdSap.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 30);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.DsModelo != null)
            {
                if (this.DsModelo.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsModelo", 40);
                }
                if (this.DsModelo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsModelo", 0);
                }
            }
            if (this.TpModelo != null)
            {
                if (this.TpModelo.Length > 4)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "TpModelo", 4);
                }
                if (this.TpModelo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "TpModelo", 0);
                }
            }
        }
    }
}
