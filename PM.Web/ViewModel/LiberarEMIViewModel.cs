using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class LiberarEMIViewModel
    {
        public NotaViewModel Nota { get; set; }

        [Display(Name = "Data de Liberação:")]
        public DateTime DtLiberacao { get; set; }

        public SituacaoEquipamentoMaterialViewModel SituacaoEquipamentoMaterial { get; set; }

        public bool btnFiltrar { get; set; }

        public bool btnLimpar { get; set; }

        public List<PlanoViewModel> Planos { get; set; }

        public List<EstruturaViewModel> Estruturas { get; set; }

    }
}