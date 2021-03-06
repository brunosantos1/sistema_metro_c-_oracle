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

    public partial class SistemaUsuario
    {
        /// <summary>
        /// Initializes a new instance of the SistemaUsuario class.
        /// </summary>
        public SistemaUsuario() { }

        /// <summary>
        /// Initializes a new instance of the SistemaUsuario class.
        /// </summary>
        public SistemaUsuario(int idUsuario, int idEmpresa, int idAplicacao, string dsDescricao, DateTime dtOcorrencia, BaseModel baseModel = default(BaseModel))
        {
            IdUsuario = idUsuario;
            IdEmpresa = idEmpresa;
            IdAplicacao = idAplicacao;
            DsDescricao = dsDescricao;
            DtOcorrencia = dtOcorrencia;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_usuario")]
        public int IdUsuario { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_empresa")]
        public int IdEmpresa { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_aplicacao")]
        public int IdAplicacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_descricao")]
        public string DsDescricao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_ocorrencia")]
        public DateTime DtOcorrencia { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (DsDescricao == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DsDescricao");
            }
            if (this.DsDescricao != null)
            {
                if (this.DsDescricao.Length > 100)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsDescricao", 100);
                }
                if (this.DsDescricao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsDescricao", 0);
                }
            }
        }
    }
}
