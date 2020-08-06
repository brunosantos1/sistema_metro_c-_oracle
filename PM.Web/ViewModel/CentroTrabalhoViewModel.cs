using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class CentroTrabalhoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Centro de Trabalho:")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição do Centro de Trabalho:")]
        public string Descricao { get; set; }
    }
}