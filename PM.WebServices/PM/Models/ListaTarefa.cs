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

    public partial class ListaTarefa
    {
        /// <summary>
        /// Initializes a new instance of the ListaTarefa class.
        /// </summary>
        public ListaTarefa() { }

        /// <summary>
        /// Initializes a new instance of the ListaTarefa class.
        /// </summary>
        public ListaTarefa(int? idLtTarefa = default(int?), string cdGpLtTarefa = default(string), string cdSap = default(string), int? idStListaTarefaFk = default(int?), string dsLtTarefa = default(string), int? idLcInstalacaoFk = default(int?), int? cdEquipamentoFk = default(int?), int? idEstrategiaFk = default(int?), int? idCentroFk = default(int?), int? idCtTrabalhoFk = default(int?), int? idCtPlanejamentoFk = default(int?), int? idGpPlanejamentoFk = default(int?), BaseModel baseModel = default(BaseModel), CentroLocalizacao centro = default(CentroLocalizacao), Estrategia estrategia = default(Estrategia), GrupoPlanejamento gpPlanejamento = default(GrupoPlanejamento), CentroPlanejamento centroPlanejamento = default(CentroPlanejamento), LocalInstalacao localInstalacao = default(LocalInstalacao), Equipamento equipamento = default(Equipamento), CentroTrabalho centroTrabalho = default(CentroTrabalho), StatusListaTarefa statusListaTarefa = default(StatusListaTarefa))
        {
            IdLtTarefa = idLtTarefa;
            CdGpLtTarefa = cdGpLtTarefa;
            CdSap = cdSap;
            IdStListaTarefaFk = idStListaTarefaFk;
            DsLtTarefa = dsLtTarefa;
            IdLcInstalacaoFk = idLcInstalacaoFk;
            CdEquipamentoFk = cdEquipamentoFk;
            IdEstrategiaFk = idEstrategiaFk;
            IdCentroFk = idCentroFk;
            IdCtTrabalhoFk = idCtTrabalhoFk;
            IdCtPlanejamentoFk = idCtPlanejamentoFk;
            IdGpPlanejamentoFk = idGpPlanejamentoFk;
            BaseModel = baseModel;
            Centro = centro;
            Estrategia = estrategia;
            GpPlanejamento = gpPlanejamento;
            CentroPlanejamento = centroPlanejamento;
            LocalInstalacao = localInstalacao;
            Equipamento = equipamento;
            CentroTrabalho = centroTrabalho;
            StatusListaTarefa = statusListaTarefa;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lt_tarefa")]
        public int? IdLtTarefa { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_gp_lt_tarefa")]
        public string CdGpLtTarefa { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_st_lista_tarefa_fk")]
        public int? IdStListaTarefaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_lt_tarefa")]
        public string DsLtTarefa { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lc_instalacao_fk")]
        public int? IdLcInstalacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_equipamento_fk")]
        public int? CdEquipamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_estrategia_fk")]
        public int? IdEstrategiaFk { get; set; }

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
        [JsonProperty(PropertyName = "id_ct_planejamento_fk")]
        public int? IdCtPlanejamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_gp_planejamento_fk")]
        public int? IdGpPlanejamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Centro")]
        public CentroLocalizacao Centro { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Estrategia")]
        public Estrategia Estrategia { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GpPlanejamento")]
        public GrupoPlanejamento GpPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroPlanejamento")]
        public CentroPlanejamento CentroPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "LocalInstalacao")]
        public LocalInstalacao LocalInstalacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Equipamento")]
        public Equipamento Equipamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StatusListaTarefa")]
        public StatusListaTarefa StatusListaTarefa { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdGpLtTarefa != null)
            {
                if (this.CdGpLtTarefa.Length > 8)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdGpLtTarefa", 8);
                }
                if (this.CdGpLtTarefa.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdGpLtTarefa", 0);
                }
            }
            if (this.CdSap != null)
            {
                if (this.CdSap.Length > 2)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 2);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.DsLtTarefa != null)
            {
                if (this.DsLtTarefa.Length > 40)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsLtTarefa", 40);
                }
                if (this.DsLtTarefa.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsLtTarefa", 0);
                }
            }
            if (this.Centro != null)
            {
                this.Centro.Validate();
            }
            if (this.Estrategia != null)
            {
                this.Estrategia.Validate();
            }
            if (this.GpPlanejamento != null)
            {
                this.GpPlanejamento.Validate();
            }
            if (this.CentroPlanejamento != null)
            {
                this.CentroPlanejamento.Validate();
            }
            if (this.LocalInstalacao != null)
            {
                this.LocalInstalacao.Validate();
            }
            if (this.Equipamento != null)
            {
                this.Equipamento.Validate();
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.StatusListaTarefa != null)
            {
                this.StatusListaTarefa.Validate();
            }
        }
    }
}
