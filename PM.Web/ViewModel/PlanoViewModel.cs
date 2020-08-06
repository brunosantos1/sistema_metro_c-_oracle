using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class PlanoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Plano")]
        public string Plano { get; set; }

        [Display(Name = "Denominação")]
        public string Denominacao { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name = "Reiniciar")]
        public bool Reiniciar { get; set; }
    }
}