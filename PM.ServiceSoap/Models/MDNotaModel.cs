using System.Runtime.Serialization;

namespace PM.ServiceSoap.Models
{
    public class MDNotaModel
    {
        //[MaxLength()]
        [DataMember(Name = "RIWO00-QMART", EmitDefaultValue = false)]
        public string TipoNota { get; set; }

        //[MaxLength()]
        [DataMember(Name = "RIWO1-TPLNR", EmitDefaultValue = false)]
        public string FrotaTremCarro { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-QMTXT", EmitDefaultValue = false)]
        public string Descricao { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-QMNAM", EmitDefaultValue = false)]
        public string Notificador { get; set; }

        //[MaxLength()]
        [DataMember(Name = "CI_QMEL-ZZLINHA", EmitDefaultValue = false)]
        public string Linha { get; set; }

        //[MaxLength()]
        [DataMember(Name = "CI_QMEL-ZZVIA", EmitDefaultValue = false)]
        public string Local { get; set; }

        //[MaxLength()]
        [DataMember(Name = "RIWO00-GEWRK", EmitDefaultValue = false)]
        public string CentroTrabalho { get; set; }

        //[MaxLength()]
        [DataMember(Name = "RIWO00-SWERK", EmitDefaultValue = false)]
        public string Centro { get; set; }

        //[MaxLength()]
        //[DataMember(Name = "", EmitDefaultValue = false)]
        public string Obs { get; set; }

        //[MaxLength()]
        [DataMember(Name = "J_STMAINT-ANWSO", EmitDefaultValue = false)]
        public string IncidenteNotavel { get; set; }

        //[MaxLength()]
        [DataMember(Name = "J_STMAINT-ANWSO", EmitDefaultValue = false)]
        public string Fumaca { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-QMDAT", EmitDefaultValue = false)]
        public string DataNota { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-MZEIT", EmitDefaultValue = false)]
        public string HoraNota { get; set; }

        //[MaxLength()]
        //[DataMember(Name = "", EmitDefaultValue = false)]
        public string NumeroMedida { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-MNGRP", EmitDefaultValue = false)]
        public string GrpCodeMedidas { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-MNCOD", EmitDefaultValue = false)]
        public string CodeMedidas { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-PARVW", EmitDefaultValue = false)]
        public string FuncaoResponsavelMedida { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-PARNR", EmitDefaultValue = false)]
        public string Responsavel { get; set; }

        //[MaxLength()]
        [DataMember(Name = "RIWO00-SMSTTXT", EmitDefaultValue = false)]
        public string StatusMedida { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-PSTER", EmitDefaultValue = false)]
        public string DataInicioMedida { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-PSTUR", EmitDefaultValue = false)]
        public string HoraInicioMedida { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-ERLNAM", EmitDefaultValue = false)]
        public string RGEmpregadoLogado { get; set; }

        //[MaxLength()]
        //[DataMember(Name = "", EmitDefaultValue = false)]
        public string NotaReferencia { get; set; }

        //[MaxLength()]
        [DataMember(Name = "J_STMAINT-ANWSO", EmitDefaultValue = false)]
        public string Diagnostico { get; set; }

        //[MaxLength()]
        [DataMember(Name = "J_STMAINT-ANWSO", EmitDefaultValue = false)]
        public string CausaRaiz { get; set; }

        //[MaxLength()]
        [DataMember(Name = "J_STMAINT-ANWSO", EmitDefaultValue = false)]
        public string SituacaoCodificacao { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-QMDAT", EmitDefaultValue = false)]
        public string GrpPlnjPM { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-MZEIT", EmitDefaultValue = false)]
        public string CentroTrabRespon { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMSM-MNGRP", EmitDefaultValue = false)]
        public string DeptoRespon { get; set; }

    }
}