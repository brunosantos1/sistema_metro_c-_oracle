using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class LocalInstalacaoRefViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Local de Instalação/Equipamento/Material:")]
        public string Codigo { get; set; }

        [Display(Name = "escrição do Local de Instalação/Equipamento/Material:")]
        public string Descricao { get; set; }
    }
}