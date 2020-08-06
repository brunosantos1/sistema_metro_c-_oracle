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

    public partial class MedidaNota
    {
        /// <summary>
        /// Initializes a new instance of the MedidaNota class.
        /// </summary>
        public MedidaNota() { }

        /// <summary>
        /// Initializes a new instance of the MedidaNota class.
        /// </summary>
        public MedidaNota(int? idMedidaNota = default(int?), int? idNotaFk = default(int?), int? sqMedidaNota = default(int?), DateTime? dtHoraMedidaNota = default(DateTime?), int? idStMedidaFk = default(int?), int? idEmpregadoFk = default(int?), int? idCodeTxFk = default(int?), int? idStUsuarioFk = default(int?), int? idEmpregadoResponsavelFk = default(int?), int? idCentTrabResponsavelFk = default(int?), string fnResponsavel = default(string), DateTime? dtProgramada = default(DateTime?), string dsMotivo = default(string), BaseModel baseModel = default(BaseModel), CentroTrabalho centroTrabalho = default(CentroTrabalho), Code codeTx = default(Code), Empregado empregado = default(Empregado), Empregado empregadoResponsavel = default(Empregado), Nota nota = default(Nota), StatusMedida statusMedida = default(StatusMedida), StatusUsuario statusUsuario = default(StatusUsuario))
        {
            IdMedidaNota = idMedidaNota;
            IdNotaFk = idNotaFk;
            SqMedidaNota = sqMedidaNota;
            DtHoraMedidaNota = dtHoraMedidaNota;
            IdStMedidaFk = idStMedidaFk;
            IdEmpregadoFk = idEmpregadoFk;
            IdCodeTxFk = idCodeTxFk;
            IdStUsuarioFk = idStUsuarioFk;
            IdEmpregadoResponsavelFk = idEmpregadoResponsavelFk;
            IdCentTrabResponsavelFk = idCentTrabResponsavelFk;
            FnResponsavel = fnResponsavel;
            DtProgramada = dtProgramada;
            DsMotivo = dsMotivo;
            BaseModel = baseModel;
            CentroTrabalho = centroTrabalho;
            CodeTx = codeTx;
            Empregado = empregado;
            EmpregadoResponsavel = empregadoResponsavel;
            Nota = nota;
            StatusMedida = statusMedida;
            StatusUsuario = statusUsuario;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_medida_nota")]
        public int? IdMedidaNota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_nota_fk")]
        public int? IdNotaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sq_medida_nota")]
        public int? SqMedidaNota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_hora_medida_nota")]
        public DateTime? DtHoraMedidaNota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_st_medida_fk")]
        public int? IdStMedidaFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_empregado_fk")]
        public int? IdEmpregadoFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_code_tx_fk")]
        public int? IdCodeTxFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_st_usuario_fk")]
        public int? IdStUsuarioFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_empregado_responsavel_fk")]
        public int? IdEmpregadoResponsavelFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id_cent_trab_responsavel_fk")]
        public int? IdCentTrabResponsavelFk { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fn_responsavel")]
        public string FnResponsavel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dt_programada")]
        public DateTime? DtProgramada { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ds_motivo")]
        public string DsMotivo { get; set; }

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
        [JsonProperty(PropertyName = "CodeTx")]
        public Code CodeTx { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Empregado")]
        public Empregado Empregado { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EmpregadoResponsavel")]
        public Empregado EmpregadoResponsavel { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Nota")]
        public Nota Nota { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StatusMedida")]
        public StatusMedida StatusMedida { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StatusUsuario")]
        public StatusUsuario StatusUsuario { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.FnResponsavel != null)
            {
                if (this.FnResponsavel.Length > 2)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "FnResponsavel", 2);
                }
                if (this.FnResponsavel.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "FnResponsavel", 0);
                }
            }
            if (this.DsMotivo != null)
            {
                if (this.DsMotivo.Length > 100)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "DsMotivo", 100);
                }
                if (this.DsMotivo.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "DsMotivo", 0);
                }
            }
            if (this.CentroTrabalho != null)
            {
                this.CentroTrabalho.Validate();
            }
            if (this.CodeTx != null)
            {
                this.CodeTx.Validate();
            }
            if (this.Empregado != null)
            {
                this.Empregado.Validate();
            }
            if (this.EmpregadoResponsavel != null)
            {
                this.EmpregadoResponsavel.Validate();
            }
            if (this.Nota != null)
            {
                this.Nota.Validate();
            }
            if (this.StatusMedida != null)
            {
                this.StatusMedida.Validate();
            }
            if (this.StatusUsuario != null)
            {
                this.StatusUsuario.Validate();
            }
        }
    }
}
