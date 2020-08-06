using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;

namespace PM.Web.ViewModel
{
    public class ProgramarMPViewModel : BaseViewModel
    {
        public ProgramarMPViewModel()
        {
        }

        public int id { get; set; }
        public int idTipoProgramacao { get; set; }
        public int idLinha { get; set; }
        public int idPatio { get; set; }
        public int idTrens { get; set; }
        public int idTipo_manutencao { get; set; }
        public int idCentroTrabalho { get; set; }
        public string data_entrega { get; set; }
        public string hora_entrega { get; set; }
        public string data_liberacao { get; set; }
        public string hora_liberacao { get; set; }
        public string observacao { get; set; }

        public int ftCentroDeTrabalho { get; set; }
        public string ftTipoManutencao { get; set; }
        public int ftLocalInstalacao { get; set; }
        public string ftDataDe { get; set; }
        public string ftDataAte { get; set; }

        public List<SelectListItem> SelecionarftCentroDeTrabalho { get; set; }
        public List<SelectListItem> SelecionarftLocalInstalacao { get; set; }
        public List<SelectListItem> SelecionarTipoProgramacao { get; set; }
        public List<SelectListItem> SelecionarLinha { get; set; }
        public List<SelectListItem> SelecionarTrens { get; set; }
        public List<SelectListItem> SelecionarPatioLinha { get; set; }
        public List<SelectListItem> SelecionarTipoManutencao { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }
    }
}