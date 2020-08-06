using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class ElementoPEPViewModel : BaseViewModel
    {
        public int ElementoPEPId { get; set; }

        [Display(Name = "Elemento PEP:")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição do Elemento PEP:")]
        public string Descricao { get; set; }
    }
}