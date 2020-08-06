    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class LiberacaoIndividualViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public bool Liberacao { get; set; }

        public NotaViewModel Nota { get; set; }

        [Display(Name = "Data de Recebimento:")]
        public DateTime DtRecebimento { get; set; }
    }
}