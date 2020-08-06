using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class OperacaoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int Operacao { get; set; }

        [Display(Name = "Sel:")]
        public int SelecaoOperacao { get; set; }

        [Display(Name = "Num Lista:")]
        public int NumeroLista { get; set; }

        [Display(Name = "Descr Lista de Tarefas:")]
        public string DescrListaTarefas { get; set; }

        [Display(Name = "Texto Operação:")]
        public string TextoOperacao { get; set; }

        [Display(Name = "Num:")]
        public int NumeroParticipantes { get; set; }

        [Display(Name = "Dur:")]
        public int Duracao { get; set; }

        [Display(Name = "Uni:")]
        public string Uni { get; set; }
    }
}