using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class RelatorioGiroViewModel
    {
        public MaterialViewModel Material { get; set; }

        public CentroTrabalhoViewModel CentroTrabalho { get; set; }

        public List<MaterialViewModel> MateriaisViewModel { get; set; }

        public bool btnFiltrar { get; set; }

        public bool btnLimpar { get; set; }

        public bool btnImprimir { get; set; }

        public bool btnExportar { get; set; }

    }
}