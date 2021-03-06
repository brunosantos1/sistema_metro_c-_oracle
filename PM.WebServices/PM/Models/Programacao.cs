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

    public partial class Programacao
    {
        /// <summary>
        /// Initializes a new instance of the Programacao class.
        /// </summary>
        public Programacao() { }

        /// <summary>
        /// Initializes a new instance of the Programacao class.
        /// </summary>
        public Programacao(int? idProgramacao = default(int?), string cdTpProgramacao = default(string), int? idTremFk = default(int?), DateTime? dtPlanejEntrega = default(DateTime?), DateTime? hrPlanejEntrega = default(DateTime?), int? idLinPlanejEntregaFk = default(int?), DateTime? dtPrevLiberacao = default(DateTime?), DateTime? hrPrevLiberacao = default(DateTime?), int? idRgProgramacao = default(int?), string dsObservacao = default(string), DateTime? dtAutorizacao = default(DateTime?), DateTime? hrAutorizacao = default(DateTime?), int? idRgAutorizacao = default(int?), DateTime? dtCancelamento = default(DateTime?), DateTime? hrCancelamento = default(DateTime?), int? idRgCancelamento = default(int?), DateTime? dtEntrega = default(DateTime?), DateTime? hrEntrega = default(DateTime?), DateTime? dtLiberacao = default(DateTime?), DateTime? hrLiberacao = default(DateTime?), int? idCtTrab = default(int?), int? stProgramacao = default(int?), int? idEntregaTremFk = default(int?), int? idTipoManutencaoFk = default(int?), int? idRgLiberacao = default(int?), string dsMotivoCancelamento = default(string), IList<Nota> notas = default(IList<Nota>), BaseModel baseModel = default(BaseModel), Trem trem = default(Trem), Linha linha = default(Linha), Empregado empregadoProgramacao = default(Empregado), Empregado empregadoLiberacao = default(Empregado), Empregado empregadoAutorizacao = default(Empregado), Empregado empregadoCancelamento = default(Empregado), CentroTrabalho centroTrabalho = default(CentroTrabalho), EntregaTrem entregaTrem = default(EntregaTrem))
        {
            IdProgramacao = idProgramacao;
            CdTpProgramacao = cdTpProgramacao;
            IdTremFk = idTremFk;
            DtPlanejEntrega = dtPlanejEntrega;
            HrPlanejEntrega = hrPlanejEntrega;
            IdLinPlanejEntregaFk = idLinPlanejEntregaFk;
            DtPrevLiberacao = dtPrevLiberacao;
            HrPrevLiberacao = hrPrevLiberacao;
            IdRgProgramacao = idRgProgramacao;
            DsObservacao = dsObservacao;
            DtAutorizacao = dtAutorizacao;
            HrAutorizacao = hrAutorizacao;
            IdRgAutorizacao = idRgAutorizacao;
            DtCancelamento = dtCancelamento;
            HrCancelamento = hrCancelamento;
            IdRgCancelamento = idRgCancelamento;
            DtEntrega = dtEntrega;
            HrEntrega = hrEntrega;
            DtLiberacao = dtLiberacao;
            HrLiberacao = hrLiberacao;
            IdCtTrab = idCtTrab;
            StProgramacao = stProgramacao;
            IdEntregaTremFk = idEntregaTremFk;
            IdTipoManutencaoFk = idTipoManutencaoFk;
            IdRgLiberacao = idRgLiberacao;
            DsMotivoCancelamento = dsMotivoCancelamento;
            Notas = notas;
            BaseModel = baseModel;
            Trem = trem;
            Linha = linha;
            EmpregadoProgramacao = empregadoProgramacao;
            EmpregadoLiberacao = empregadoLiberacao;
            EmpregadoAutorizacao = empregadoAutorizacao;
            EmpregadoCancelamento = empregadoCancelamento;
            CentroTrabalho = centroTrabalho;
            EntregaTrem = entregaTrem;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_programacao")]
        public int? IdProgramacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cd_tp_programacao")]
        public string CdTpProgramacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_trem_fk")]
        public int? IdTremFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_planej_entrega")]
        public DateTime? DtPlanejEntrega { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_planej_entrega")]
        public DateTime? HrPlanejEntrega { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_lin_planej_entrega_fk")]
        public int? IdLinPlanejEntregaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_prev_liberacao")]
        public DateTime? DtPrevLiberacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_prev_liberacao")]
        public DateTime? HrPrevLiberacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_rg_programacao")]
        public int? IdRgProgramacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_observacao")]
        public string DsObservacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_autorizacao")]
        public DateTime? DtAutorizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_autorizacao")]
        public DateTime? HrAutorizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_rg_autorizacao")]
        public int? IdRgAutorizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_cancelamento")]
        public DateTime? DtCancelamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_cancelamento")]
        public DateTime? HrCancelamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_rg_cancelamento")]
        public int? IdRgCancelamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_entrega")]
        public DateTime? DtEntrega { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_entrega")]
        public DateTime? HrEntrega { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_liberacao")]
        public DateTime? DtLiberacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "hr_liberacao")]
        public DateTime? HrLiberacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_ct_trab")]
        public int? IdCtTrab { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "st_programacao")]
        public int? StProgramacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_entrega_trem_fk")]
        public int? IdEntregaTremFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_tipo_manutencao_fk")]
        public int? IdTipoManutencaoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_rg_liberacao")]
        public int? IdRgLiberacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_motivo_cancelamento")]
        public string DsMotivoCancelamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Notas")]
        public IList<Nota> Notas { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BaseModel")]
        public BaseModel BaseModel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Trem")]
        public Trem Trem { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Linha")]
        public Linha Linha { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmpregadoProgramacao")]
        public Empregado EmpregadoProgramacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmpregadoLiberacao")]
        public Empregado EmpregadoLiberacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmpregadoAutorizacao")]
        public Empregado EmpregadoAutorizacao { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmpregadoCancelamento")]
        public Empregado EmpregadoCancelamento { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "CentroTrabalho")]
        public CentroTrabalho CentroTrabalho { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EntregaTrem")]
        public EntregaTrem EntregaTrem { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.CdTpProgramacao != null)
            {
                if (this.CdTpProgramacao.Length > 3)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "CdTpProgramacao", 3);
                }
                if (this.CdTpProgramacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "CdTpProgramacao", 0);
                }
            }
            if (this.DsObservacao != null)
            {
                if (this.DsObservacao.Length > 2000)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsObservacao", 2000);
                }
                if (this.DsObservacao.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsObservacao", 0);
                }
            }
            if (this.DsMotivoCancelamento != null)
            {
                if (this.DsMotivoCancelamento.Length > 2000)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsMotivoCancelamento", 2000);
                }
                if (this.DsMotivoCancelamento.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsMotivoCancelamento", 0);
                }
            }
            if (this.Notas != null)
            {
                foreach (var element in this.Notas)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.Trem != null)
            {
                this.Trem.Validate();
            }
            if (this.Linha != null)
            {
                this.Linha.Validate();
            }
            if (this.EmpregadoProgramacao != null)
            {
                this.EmpregadoProgramacao.Validate();
            }
            if (this.EmpregadoLiberacao != null)
            {
                this.EmpregadoLiberacao.Validate();
            }
            if (this.EmpregadoAutorizacao != null)
            {
                this.EmpregadoAutorizacao.Validate();
            }
            if (this.EmpregadoCancelamento != null)
            {
                this.EmpregadoCancelamento.Validate();
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.EntregaTrem != null)
            {
                this.EntregaTrem.Validate();
            }
        }
    }
}
