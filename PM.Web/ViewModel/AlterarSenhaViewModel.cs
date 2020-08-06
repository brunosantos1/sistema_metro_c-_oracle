using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PM.Web.ViewModel
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage = "A {0} é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatório")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova senha")]
        [Compare("NovaSenha", ErrorMessage = "A nova senha e a senha de confirmação não correspondem.")]
        public string ConfirmaNovaSenha { get; set; }
    }
}