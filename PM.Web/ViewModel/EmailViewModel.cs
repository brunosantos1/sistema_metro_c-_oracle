using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PM.Web.ViewModel
{
    public class EmailViewModel
    {
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter {1} caracteres no máximo e o mínimo de {2} caracteres.", MinimumLength = 4)]
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Nome")]      
        public string Nome { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter {1} caracteres no máximo e o mínimo de {2} caracteres.", MinimumLength = 4)]
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter {1} caracteres no máximo e o mínimo de {2} caracteres.", MinimumLength = 4)]
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000, ErrorMessage = "O campo {0} deve ter {1} caracteres no máximo e o mínimo de {2} caracteres.", MinimumLength = 4)]
        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
    }
}