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

    public partial class Tarifa
    {
        /// <summary>
        /// Initializes a new instance of the Tarifa class.
        /// </summary>
        public Tarifa() { }

        /// <summary>
        /// Initializes a new instance of the Tarifa class.
        /// </summary>
        public Tarifa(int? idTarifa = default(int?), string cdSap = default(string), string dsTpAtividade = default(string), int? idUnAtividadeFk = default(int?), BaseModel baseModel = default(BaseModel), UnidadeMedida unidadeMedida = default(UnidadeMedida))
        {
            IdTarifa = idTarifa;
            CdSap = cdSap;
            DsTpAtividade = dsTpAtividade;
            IdUnAtividadeFk = idUnAtividadeFk;
            BaseModel = baseModel;
            UnidadeMedida = unidadeMedida;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_tarifa")]
        public int? IdTarifa { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_tp_atividade")]
        public string DsTpAtividade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_atividade_fk")]
        public int? IdUnAtividadeFk { get; set; }

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
                if (this.CdSap.Length > 12)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 12);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.DsTpAtividade != null)
            {
                if (this.DsTpAtividade.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsTpAtividade", 40);
                }
                if (this.DsTpAtividade.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsTpAtividade", 0);
                }
            }
        }
    }
}
