using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;

namespace PM.Web.ViewModel
{
    public class EntregaTrensViewModel : BaseViewModel
    {
        public EntregaTrensViewModel()
        {
        }

        public int id { get; set; }
        public int linha { get; set; }
        public int patio { get; set; }
        public int trens { get; set; }
        public string data_entrega { get; set; }
        public string hora_entrega { get; set; }
        public List<WebServices.Models.Nota> NotasMC { get; set; }

        public List<WebServices.Models.Nota> NotasMI { get; set; }

        public List<WebServices.Models.Nota> NotasProg { get; set; }

        public List<SelectListItem> SelecionarLinha { get; set; }
        public List<SelectListItem> SelecionarTrens { get; set; }
        public List<SelectListItem> SelecionarPatioLinha { get; set; }        
    }
} 