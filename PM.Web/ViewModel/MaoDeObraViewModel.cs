using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class MaoDeObraViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int MaoDeObrax { get; set; }

        [Display(Name = "CenTrab:")]
        public string CentroTrab { get; set; }

        [Display(Name = "RG:")]
        public string Rg { get; set; }

        [Display(Name = "Dt Exec:")]
        public DateTime DataExec { get; set; }

        [Display(Name = "Dur:")]
        public int DuracaoExec { get; set; }

        [Display(Name = "Unid:")]
        public string UniExec { get; set; }

        [Display(Name = "Tarifa:")]
        public int Tarifa { get; set; }

        [Display(Name = "Ação:")]
        public bool Incluir { get; set; }

        [Display(Name = "Ação:")]
        public bool Excluir { get; set; }
    }
}