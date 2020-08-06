using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class LiberarMLoteViewModel
    {
        public MaterialViewModel Material { get; set; }

        public CentroTrabalhoViewModel CentroTrabalho { get; set; }

        [Display(Name = "Data de Liberação:")]
        public DateTime DtLiberacao { get; set; }

        public SituacaoLiberacaoViewModel SituacaoLiberacao { get; set; }

        [Display(Name = "Quantidade (Lote):")]
        public int Quantidade { get; set; }

        public bool btnFiltrar { get; set; }

        public bool btnLimpar { get; set; }

        public bool btnLiberar { get; set; }

        public bool btnCancelar { get; set; }

        public List<LiberacaoIndividualViewModel> LiberacaoIndividual { get; set; }
    }
}