using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;

namespace PM.Web.ViewModel
{
    public class PesquisarEntregaTrensViewModel : BaseViewModel
    {
        public PesquisarEntregaTrensViewModel()
        {
        }

        public int id { get; set; }
        public int linha { get; set; }
        public int patio { get; set; }
        public int trens { get; set; }
        public int trem_status_liberacao { get; set; }
        public int id_resp_liberacao { get; set; }
        public int motivo { get; set; }

        public string motivo_cancelamento { get; set; }
        public int id_resp_cancelamento { get; set; }

        public int linha_novo { get; set; }
        public int patio_novo { get; set; }


        public string data_entrega_inicial { get; set; }
        public string data_entrega_final { get; set; }
        public List<SelectListItem> SelecionarLinha { get; set; }
        public List<SelectListItem> SelecionarTrens { get; set; }
        public List<SelectListItem> SelecionarPatioLinha { get; set; }
        public List<SelectListItem> SelecionarMotivo { get; set; }

        public List<SelectListItem> SelecionarStatusLiberacaoTrens { get; set; }
    }
}