using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class PrioridadeViewModel : BaseViewModel
    {
        public int PrioridadeId { get; set; }
        public string Codigo { get; set; }

        [Display(Name = "Prioridade:")]
        public string Descricao { get; set; }
    }
}