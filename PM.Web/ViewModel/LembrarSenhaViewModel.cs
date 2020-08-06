using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PM.Web.ViewModel
{
    public class LembrarSenhaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

    }
}