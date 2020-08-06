using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PM.IntegradorSAP.Model
{
    public class ModelEquipamentoFixo
    {
        [Required]
        public string TipoNota { get; set; }
        [Required]
        public string LocInstalacao { get; set; }
        public string Code { get; set; }
        public string GrpCode { get; set; }
        public string Descricao { get; set; }
        public string Prioridade { get; set; }
        public string Notificador { get; set; }
        public string CentroTrabalho { get; set; }
        public string Centro { get; set; }
        public string Observacao { get; set; }
        public string IncidenteNotavel { get; set; }
        public string StatusNota { get; set; }
        public List<ModelEquipamentoFixoDadosLineares> DadosLineares { get; set; }
        public List<ModelEquipamentoFixoMedidas> Medida { get; set; }

        public ModelEquipamentoFixo()
        {
            DadosLineares = new List<ModelEquipamentoFixoDadosLineares>();
            Medida = new List<ModelEquipamentoFixoMedidas>();

        }
    }

    public class ModelEquipamentoFixoDadosLineares
    {
        public string MarcoInicial { get; set; }
        public string PontoPartida { get; set; }
        public string PontoFinal { get; set; }
        public string UniMedLineares { get; set; }
        public string DistMarcoInicial { get; set; }
        public string Comprimento { get; set; }
        public string MarcadorFinal { get; set; }
        public string DistMarcoFinal { get; set; }
    }

    public class ModelEquipamentoFixoMedidas
    {
        public string ItemMedia { get; set; }
        public string GrpCodMedidas { get; set; }
        public string CodMedidas { get; set; }
        public string StatusMedida { get; set; }
        public string FuncResposavel { get; set; }
        public string Responsavel { get; set; }
        public string RGLogado { get; set; }
        public string DataInicio { get; set; }
        public string HoraInicio { get; set; }
        public string DataProgramanda { get; set; }
        public string HoraProgramada { get; set; }
    }
}