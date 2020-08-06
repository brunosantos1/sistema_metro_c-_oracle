using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class StatusUsuarioViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        [Display(Name = "Status do Usuário:")]
        public string Descricao { get; set; }
    }
}