using PM.WebServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static PM.Web.ViewModel.Enum.Enum;

namespace PM.Web.ViewModel
{
    public class PesquisaPrioritarioViewModel
    {
        public PriorizacaoEnum Nivel { get; set; }

        public CentroTrabalhoViewModel CentroTrabalho { get; set; }

        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }

        #endregion

        public List<MaterialViewModel> GridMateriais { get; set; }

        public bool btnFiltrar { get; set; }

        public bool btnLimpar { get; set; }

        public bool btnImprimir { get; set; }

        public bool btnExportar { get; set; }

        public List<MaterialViewModel> Materiais { get; set; }

        public bool btnLiberar { get; set; }

        public bool btnCancelar { get; set; }
    }
}