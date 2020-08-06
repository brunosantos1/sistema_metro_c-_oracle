using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;

namespace PM.Web.ViewModel
{
    public class PesquisarProgramacaoTrensViewModel : BaseViewModel
    {
        public PesquisarProgramacaoTrensViewModel()
        {
        }


        public int id { get; set; }
        public int idTipoProgramacao { get; set; }
        public int idLinha { get; set; }
        public int idPatio { get; set; }
        public int idTrens { get; set; }
        public int idMotivo { get; set; }
        public int idTipo_manutencao { get; set; }
        public int idCentroTrabalho { get; set; }
        public int idStatus { get; set; }
        public string data_entrega_inicio { get; set; }
        public string data_entrega_final { get; set; }
        

        public List<SelectListItem> SelecionarLinha { get; set; }
        public List<SelectListItem> SelecionarPatio { get; set; }
        public List<SelectListItem> SelecionarTrens { get; set; }
        public List<SelectListItem> SelecionarTipoManutencao { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }
        public List<SelectListItem> SelecionarStatus { get; set; }
        public List<SelectListItem> SelecionarMotivo { get; set; }
        public List<SelectListItem> SelecionarTipoProgramacao { get; set; }


    }
}