using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class ApontamentoLoteViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int Apontamento { get; set; }

        [Display(Name = "Sel")]
        public int Sel { get; set; }

        [Display(Name = "Nota")]
        public int NumeroNota { get; set; }

        [Display(Name = "Recebimento")]
        public DateTime DtRecebimento { get; set; }

        [Display(Name = "Liberação")]
        public DateTime DtLiberacao { get; set; }
    }
}