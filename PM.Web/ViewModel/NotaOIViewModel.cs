using PM.WebServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class NotaOIViewModel
    {
        public NotaViewModel NotaRef { get; set; }

        public NotaViewModel Nota { get; set; }

        public List<TarefaViewModel> SelecionarTarefas { get; set; }

        public List<TarefaViewModel> ReservarTarefas { get; set; }

        public int TempoPrevisto { get; set; }

        public int Unidade { get; set; }

        public string DadosAdicionais { get; set; }

        public bool btnSalvar { get; set; }

        public bool btnCancelar { get; set; }

        public List<TarefaViewModel> Tarefas { get; set; }

        public List<MaterialViewModel> Materiais { get; set; }

        public List<TipoNotaViewModel> TipoNotas { get; set; }

        public List<CentroTrabalhoViewModel> CentroTrabalhos { get; set; }

        public List<PrioridadeViewModel> Prioridades { get; set; }

        public PrioridadeViewModel Prioridade { get; set; }

        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarTipoNota { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }
        public List<SelectListItem> SelecionarPrioridade { get; set; }

        #endregion

    }
}