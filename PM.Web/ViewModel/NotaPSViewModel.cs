using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class NotaPSViewModel
    {
        public NotaViewModel NotaRef { get; set; }

        public NotaViewModel Nota { get; set; }

        public List<TarefaViewModel> SelecionarTarefas { get; set; }

        public List<TarefaViewModel> ReservarTarefas { get; set; }

        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarTipoNota { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }
        public List<SelectListItem> SelecionarPrioridade { get; set; }

        #endregion

        public string DadosAdicionais { get; set; }

        public string NomeCliente { get; set; }

        public string NumeroContrato { get; set; }

        public int TempoPrevisto { get; set; }

        public bool btnSalvar { get; set; }

        public bool btnCancelar { get; set; }



    }
}