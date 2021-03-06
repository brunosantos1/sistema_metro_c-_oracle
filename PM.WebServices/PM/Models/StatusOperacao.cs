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

    public partial class StatusOperacao
    {
        /// <summary>
        /// Initializes a new instance of the StatusOperacao class.
        /// </summary>
        public StatusOperacao() { }

        /// <summary>
        /// Initializes a new instance of the StatusOperacao class.
        /// </summary>
        public StatusOperacao(int? idStOperacao = default(int?), string dsStOperacao = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdStOperacao = idStOperacao;
            DsStOperacao = dsStOperacao;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_st_operacao")]
        public int? IdStOperacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_st_operacao")]
        public string DsStOperacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.DsStOperacao != null)
            {
                if (this.DsStOperacao.Length > 150)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsStOperacao", 150);
                }
                if (this.DsStOperacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsStOperacao", 0);
                }
            }
        }
    }
}
