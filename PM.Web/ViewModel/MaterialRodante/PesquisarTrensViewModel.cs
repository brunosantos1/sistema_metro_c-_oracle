using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;

namespace PM.Web.ViewModel
{
    public class PesquisarTrensViewModel : BaseViewModel
    {
        public PesquisarTrensViewModel()
        {
        }

        public int id { get; set; }
        public int linha { get; set; }
        public int status { get; set; }
        public int patio { get; set; }
        public int trens_liberados { get; set; }
        public int trens_falha { get; set; }
        public int trens_entregue { get; set; }
        public int trens_manobra { get; set; }
        public int trens_total { get; set; }

        public List<SelectListItem> SelecionarLinha { get; set; }
        public List<SelectListItem> SelecionarStatus { get; set; }
        public List<SelectListItem> SelecionarPatioLinha { get; set; }
        public List<Trem> Trens { get; set; }
    }
}