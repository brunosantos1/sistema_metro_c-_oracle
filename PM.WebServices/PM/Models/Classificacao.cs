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

    public partial class Classificacao
    {
        /// <summary>
        /// Initializes a new instance of the Classificacao class.
        /// </summary>
        public Classificacao() { }

        /// <summary>
        /// Initializes a new instance of the Classificacao class.
        /// </summary>
        public Classificacao(int? idClassificacao = default(int?), int? idLcInstalacaoFk = default(int?), int? idEquipamentoFk = default(int?), int? idCentroFk = default(int?), int? idCtTrabalhoFk = default(int?), string cdClasse = default(string), string cdCaracteristica = default(string), string cdValorCaracteristica = default(string), bool? stClassificacao = default(bool?), BaseModel baseModel = default(BaseModel), CentroLocalizacao centroLocalizacao = default(CentroLocalizacao), LocalInstalacao localInstalacao = default(LocalInstalacao), CentroTrabalho centroTrabalho = default(CentroTrabalho), Equipamento equipamento = default(Equipamento))
        {
            IdClassificacao = idClassificacao;
            IdLcInstalacaoFk = idLcInstalacaoFk;
            IdEquipamentoFk = idEquipamentoFk;
            IdCentroFk = idCentroFk;
            IdCtTrabalhoFk = idCtTrabalhoFk;
            CdClasse = cdClasse;
            CdCaracteristica = cdCaracteristica;
            CdValorCaracteristica = cdValorCaracteristica;
            StClassificacao = stClassificacao;
            BaseModel = baseModel;
            CentroLocalizacao = centroLocalizacao;
            LocalInstalacao = localInstalacao;
            CentroTrabalho = centroTrabalho;
            Equipamento = equipamento;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_classificacao")]
        public int? IdClassificacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lc_instalacao_fk")]
        public int? IdLcInstalacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_equipamento_fk")]
        public int? IdEquipamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_centro_fk")]
        public int? IdCentroFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_trabalho_fk")]
        public int? IdCtTrabalhoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_classe")]
        public string CdClasse { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_caracteristica")]
        public string CdCaracteristica { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_valor_caracteristica")]
        public string CdValorCaracteristica { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "st_classificacao")]
        public bool? StClassificacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroLocalizacao")]
        public CentroLocalizacao CentroLocalizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LocalInstalacao")]
        public LocalInstalacao LocalInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Equipamento")]
        public Equipamento Equipamento { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdClasse != null)
            {
                if (this.CdClasse.Length > 18)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdClasse", 18);
                }
                if (this.CdClasse.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdClasse", 0);
                }
            }
            if (this.CdCaracteristica != null)
            {
                if (this.CdCaracteristica.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdCaracteristica", 30);
                }
                if (this.CdCaracteristica.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdCaracteristica", 0);
                }
            }
            if (this.CdValorCaracteristica != null)
            {
                if (this.CdValorCaracteristica.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdValorCaracteristica", 30);
                }
                if (this.CdValorCaracteristica.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdValorCaracteristica", 0);
                }
            }
            if (this.CentroLocalizacao != null)
            {
                this.CentroLocalizacao.Validate();
            }
            if (this.LocalInstalacao != null)
            {
                this.LocalInstalacao.Validate();
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.Equipamento != null)
            {
                this.Equipamento.Validate();
            }
        }
    }
}
