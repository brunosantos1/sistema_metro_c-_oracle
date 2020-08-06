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

    public partial class OperacaoOrdem
    {
        /// <summary>
        /// Initializes a new instance of the OperacaoOrdem class.
        /// </summary>
        public OperacaoOrdem() { }

        /// <summary>
        /// Initializes a new instance of the OperacaoOrdem class.
        /// </summary>
        public OperacaoOrdem(int? idOperacao = default(int?), int? idOrdemFk = default(int?), string dsBreve = default(string), int? nrPessoas = default(int?), double? drOperacao = default(double?), int? idNotaEaFk = default(int?), int? idCentroTrabalhoFk = default(int?), DateTime? dtHoraOperacao = default(DateTime?), int? idStatusOperacaoFk = default(int?), BaseModel baseModel = default(BaseModel), Ordem ordem = default(Ordem), Nota notaEA = default(Nota), CentroTrabalho centroTrabalho = default(CentroTrabalho), StatusOperacao statusOperacao = default(StatusOperacao))
        {
            IdOperacao = idOperacao;
            IdOrdemFk = idOrdemFk;
            DsBreve = dsBreve;
            NrPessoas = nrPessoas;
            DrOperacao = drOperacao;
            IdNotaEaFk = idNotaEaFk;
            IdCentroTrabalhoFk = idCentroTrabalhoFk;
            DtHoraOperacao = dtHoraOperacao;
            IdStatusOperacaoFk = idStatusOperacaoFk;
            BaseModel = baseModel;
            Ordem = ordem;
            NotaEA = notaEA;
            CentroTrabalho = centroTrabalho;
            StatusOperacao = statusOperacao;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_operacao")]
        public int? IdOperacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ordem_fk")]
        public int? IdOrdemFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_breve")]
        public string DsBreve { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "nr_pessoas")]
        public int? NrPessoas { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dr_operacao")]
        public double? DrOperacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_nota_ea_fk")]
        public int? IdNotaEaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_centro_trabalho_fk")]
        public int? IdCentroTrabalhoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_hora_operacao")]
        public DateTime? DtHoraOperacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_status_operacao_fk")]
        public int? IdStatusOperacaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Ordem")]
        public Ordem Ordem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NotaEA")]
        public Nota NotaEA { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StatusOperacao")]
        public StatusOperacao StatusOperacao { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.DsBreve != null)
            {
                if (this.DsBreve.Length > 20)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsBreve", 20);
                }
                if (this.DsBreve.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsBreve", 0);
                }
            }
            if (this.Ordem != null)
            {
                this.Ordem.Validate();
            }
            if (this.NotaEA != null)
            {
                this.NotaEA.Validate();
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.StatusOperacao != null)
            {
                this.StatusOperacao.Validate();
            }
        }
    }
}