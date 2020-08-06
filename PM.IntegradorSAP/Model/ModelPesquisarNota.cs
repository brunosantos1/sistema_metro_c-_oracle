using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.IntegradorSAP.Model
{
    public class ModelPesquisarNotas
    {
        public string TipoNota { get; set; }
        public string NumeroNota { get; set; }
        public string LocalInstalacao { get; set; }
        public string Prioridade { get; set; }
        public string DataDe { get; set; }
        public string DataAte { get; set; }
        public string Notificador { get; set; }
        public string StatusUsuario { get; set; }
        public string StatusNota { get; set; }
        public string Solicitante { get; set; }
        public string NumeroOrdem { get; set; }
        public string CentroTrabalho { get; set; }
        public string Centro { get; set; }
        public string Equipamento { get; set; }
        public string Material { get; set; }
        public string Code { get; set; }
        public string GrpCode { get; set; }
        public string NotaRerencia { get; set; }
        public string CausaRaiz { get; set; }
        public string Diagnostico { get; set; }
        public string EventoGerador { get; set; }
    }

    
}