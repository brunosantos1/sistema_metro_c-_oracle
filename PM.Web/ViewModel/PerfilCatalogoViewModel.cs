using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class PerfilCatalogoViewModel : BaseViewModel
    {
        public int PerfilCatalogoId { get; set; }

        [Display(Name = "Perfil de Catálogo:")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição do Perfil de Catálogo:")]
        public string Descricao { get; set; }
    }
}