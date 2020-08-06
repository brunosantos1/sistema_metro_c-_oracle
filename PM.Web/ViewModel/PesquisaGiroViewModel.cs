using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class PesquisaGiroViewModel
    {
        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarMaterial { get; set; }
        public List<SelectListItem> SelecionarTipoNota { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }
        public List<SelectListItem> SelecionarPrioridade { get; set; }
        public List<SelectListItem> SelecionarStatusUsuario { get; set; }
        public List<SelectListItem> SelecionarCatalogo { get; set; }
        public List<SelectListItem> SelecionarNota { get; set; }
        public List<NotaViewModel> GridNotas { get; set; }

        #endregion


        public MaterialViewModel Material { get; set; }

        public CentroTrabalhoViewModel CentroTrabalho { get; set; }

        public List<MaterialViewModel> Materiais { get; set; }

        public bool btnFiltrar { get; set; }

        public bool btnLimpar { get; set; }

        public bool btnImprimir { get; set; }

        public bool btnExportar { get; set; }

    }
}