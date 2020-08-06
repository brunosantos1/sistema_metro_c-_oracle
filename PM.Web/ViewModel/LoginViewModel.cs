using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PM.Web.ViewModel
{
    public class LoginViewModel
    {
       
        //////[key]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter {1} caracteres no máximo e o mínimo de {2} caracteres.", MinimumLength = 4)]
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter o mínimo de {2} caracteres.", MinimumLength = 4)]
        //[Required(ErrorMessage = "A {0} é obrigatório")]
        [Display(Name = "Senha")]
        public string SenhaLogin { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool Lembrar { get; set; }

        private EmailViewModel emailViewModel;

        public EmailViewModel EmailViewModel
        {
            get {
                if (emailViewModel == null)
                {
                    emailViewModel = new EmailViewModel();
                }
                return emailViewModel; }
            set { emailViewModel = value; }
        }
        public string Captcha { get; set; }



    }
}