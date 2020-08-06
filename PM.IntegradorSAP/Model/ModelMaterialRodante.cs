using PM.IntegradorSAP.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml;
using PM.IntegradorSAP.Helper;

namespace PM.IntegradorSAP.Model
{
    public class ModelMaterialRodante
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
        public string Linha { get; set; }
        public string Local { get; set; }
        public string CentroTrabalho { get; set; }
        public string Centro { get; set; }
        public string Observacao { get; set; }
        public string InterOperacional { get; set; }
        public string IncidenteNotavel { get; set; }
        public string Fumaca { get; set; }
        public string TipoManutencao { get; set; }
        public string StatusNota { get; set; }
        public string StatusUsuario { get; set; }
        public List<ModelMaterialRodanteMedida> Medida { get; set; }

        public ModelMaterialRodante()
        {
            Medida = new List<ModelMaterialRodanteMedida>();
        }
    }
    public class ModelMaterialRodanteMedida
    {
        public string ItemMedia { get; set; }
        public string GrpCodMedidas { get; set; }
        public string CodMedidas { get; set; }
        public string StatusMedida { get; set; }
        public string DataInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FuncResposavel { get; set; }
        public string Responsavel { get; set; }
        public string RGLogado { get; set; }
        public string DataProgramanda { get; set; }
        public string HoraProgramada { get; set; }
    }

    
}