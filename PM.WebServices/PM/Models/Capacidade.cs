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

    public partial class Capacidade
    {
        /// <summary>
        /// Initializes a new instance of the Capacidade class.
        /// </summary>
        public Capacidade() { }

        /// <summary>
        /// Initializes a new instance of the Capacidade class.
        /// </summary>
        public Capacidade(int? idCapacidade = default(int?), int? idCentroFk = default(int?), int? idCtTrabalhoFk = default(int?), string cdSap = default(string), int? idTpCapacidadeFk = default(int?), bool? crExcluidaPlanejamento = default(bool?), bool? crProgramacao = default(bool?), string crSobrecarga = default(string), bool? crCapacidadeOperacao = default(bool?), int? idCalendarioFk = default(int?), double? nrCapacidade = default(double?), int? idUnCapacidadeFk = default(int?), int? idUnBaseCapacidadeFk = default(int?), int? grUtilizacao = default(int?), int? idGpPlanejamentoFk = default(int?), DateTime? hrFimCapacidade = default(DateTime?), DateTime? hrInicioCapacidade = default(DateTime?), DateTime? hrIntervalo = default(DateTime?), BaseModel baseModel = default(BaseModel), CentroTrabalho centroTrabalho = default(CentroTrabalho), CentroLocalizacao centroLocalizacao = default(CentroLocalizacao), TipoCapacidade tipoCapacidade = default(TipoCapacidade), CalendarioFabrica calendario = default(CalendarioFabrica), GrupoPlanejamento gpPlanejamento = default(GrupoPlanejamento), UnidadeMedida unidadeMedidaCap = default(UnidadeMedida), UnidadeMedida unidadeMedidaBaseCap = default(UnidadeMedida))
        {
            IdCapacidade = idCapacidade;
            IdCentroFk = idCentroFk;
            IdCtTrabalhoFk = idCtTrabalhoFk;
            CdSap = cdSap;
            IdTpCapacidadeFk = idTpCapacidadeFk;
            CrExcluidaPlanejamento = crExcluidaPlanejamento;
            CrProgramacao = crProgramacao;
            CrSobrecarga = crSobrecarga;
            CrCapacidadeOperacao = crCapacidadeOperacao;
            IdCalendarioFk = idCalendarioFk;
            NrCapacidade = nrCapacidade;
            IdUnCapacidadeFk = idUnCapacidadeFk;
            IdUnBaseCapacidadeFk = idUnBaseCapacidadeFk;
            GrUtilizacao = grUtilizacao;
            IdGpPlanejamentoFk = idGpPlanejamentoFk;
            HrFimCapacidade = hrFimCapacidade;
            HrInicioCapacidade = hrInicioCapacidade;
            HrIntervalo = hrIntervalo;
            BaseModel = baseModel;
            CentroTrabalho = centroTrabalho;
            CentroLocalizacao = centroLocalizacao;
            TipoCapacidade = tipoCapacidade;
            Calendario = calendario;
            GpPlanejamento = gpPlanejamento;
            UnidadeMedidaCap = unidadeMedidaCap;
            UnidadeMedidaBaseCap = unidadeMedidaBaseCap;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_capacidade")]
        public int? IdCapacidade { get; set; }

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
        [JsonProperty(PropertyName = "cd_sap")]
        public string CdSap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_tp_capacidade_fk")]
        public int? IdTpCapacidadeFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_excluida_planejamento")]
        public bool? CrExcluidaPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_programacao")]
        public bool? CrProgramacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_sobrecarga")]
        public string CrSobrecarga { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cr_capacidade_operacao")]
        public bool? CrCapacidadeOperacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_calendario_fk")]
        public int? IdCalendarioFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_capacidade")]
        public double? NrCapacidade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_capacidade_fk")]
        public int? IdUnCapacidadeFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_un_base_capacidade_fk")]
        public int? IdUnBaseCapacidadeFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "gr_utilizacao")]
        public int? GrUtilizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_gp_planejamento_fk")]
        public int? IdGpPlanejamentoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_fim_capacidade")]
        public DateTime? HrFimCapacidade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_inicio_capacidade")]
        public DateTime? HrInicioCapacidade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_intervalo")]
        public DateTime? HrIntervalo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroLocalizacao")]
        public CentroLocalizacao CentroLocalizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TipoCapacidade")]
        public TipoCapacidade TipoCapacidade { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Calendario")]
        public CalendarioFabrica Calendario { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GpPlanejamento")]
        public GrupoPlanejamento GpPlanejamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedidaCap")]
        public UnidadeMedida UnidadeMedidaCap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnidadeMedidaBaseCap")]
        public UnidadeMedida UnidadeMedidaBaseCap { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdSap != null)
            {
                if (this.CdSap.Length > 3)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdSap", 3);
                }
                if (this.CdSap.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdSap", 0);
                }
            }
            if (this.CrSobrecarga != null)
            {
                if (this.CrSobrecarga.Length > 3)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CrSobrecarga", 3);
                }
                if (this.CrSobrecarga.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CrSobrecarga", 0);
                }
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.CentroLocalizacao != null)
            {
                this.CentroLocalizacao.Validate();
            }
            if (this.GpPlanejamento != null)
            {
                this.GpPlanejamento.Validate();
            }
        }
    }
}
