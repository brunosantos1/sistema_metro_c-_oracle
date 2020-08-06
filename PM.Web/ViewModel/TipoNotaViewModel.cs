using PM.WebServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class TipoNotaViewModel : BaseViewModel
    {
        public int TipoId { get; set; }

        public int Codigo { get; set; }

        [Display(Name = "Tipo de Nota:")]
        public string Descricao { get; set; }
    }
}