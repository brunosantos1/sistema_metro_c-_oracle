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

    public partial class SistemaLogOperacoesItem
    {
        /// <summary>
        /// Initializes a new instance of the SistemaLogOperacoesItem class.
        /// </summary>
        public SistemaLogOperacoesItem() { }

        /// <summary>
        /// Initializes a new instance of the SistemaLogOperacoesItem class.
        /// </summary>
        public SistemaLogOperacoesItem(int idLogOperacoes, string dsPropriedade, string nmAmigavel, string dsValorOrigem, int nuOrdem, int? idLogOperacoesItem = default(int?), string dsValorPara = default(string), BaseModel baseModel = default(BaseModel))
        {
            IdLogOperacoesItem = idLogOperacoesItem;
            IdLogOperacoes = idLogOperacoes;
            DsPropriedade = dsPropriedade;
            NmAmigavel = nmAmigavel;
            DsValorOrigem = dsValorOrigem;
            DsValorPara = dsValorPara;
            NuOrdem = nuOrdem;
            BaseModel = baseModel;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_log_operacoes_item")]
        public int? IdLogOperacoesItem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_log_operacoes")]
        public int IdLogOperacoes { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_propriedade")]
        public string DsPropriedade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nm_amigavel")]
        public string NmAmigavel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_valor_origem")]
        public string DsValorOrigem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_valor_para")]
        public string DsValorPara { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nu_ordem")]
        public int NuOrdem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (DsPropriedade == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DsPropriedade");
            }
            if (NmAmigavel == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NmAmigavel");
            }
            if (DsValorOrigem == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DsValorOrigem");
            }
            if (this.DsPropriedade != null)
            {
                if (this.DsPropriedade.Length > 50)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsPropriedade", 50);
                }
                if (this.DsPropriedade.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsPropriedade", 0);
                }
            }
            if (this.NmAmigavel != null)
            {
                if (this.NmAmigavel.Length > 50)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "NmAmigavel", 50);
                }
                if (this.NmAmigavel.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "NmAmigavel", 0);
                }
            }
            if (this.DsValorOrigem != null)
            {
                if (this.DsValorOrigem.Length > 200)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsValorOrigem", 200);
                }
                if (this.DsValorOrigem.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsValorOrigem", 0);
                }
            }
            if (this.DsValorPara != null)
            {
                if (this.DsValorPara.Length > 200)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsValorPara", 200);
                }
                if (this.DsValorPara.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsValorPara", 0);
                }
            }
        }
    }
}