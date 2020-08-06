using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class IntervencaoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int Intervencao { get; set; }

        [Display(Name = "Código Objeto:")]
        public string CodParteObj { get; set; }

        [Display(Name = "Descr Parte Objeto:")]
        public string DescrParteObj { get; set; }

        [Display(Name = "Defeito:")]
        public string DefeitoObj { get; set; }

        [Display(Name = "Reparo:")]
        public string ReparoFeitoObj { get; set; }

        [Display(Name = "Quantidade:")]
        public string QtdeObj { get; set; }

        [Display(Name = "Ação:")]
        public bool Incluir { get; set; }

        [Display(Name = "Ação:")]
        public bool Excluir { get; set; }
    }
}