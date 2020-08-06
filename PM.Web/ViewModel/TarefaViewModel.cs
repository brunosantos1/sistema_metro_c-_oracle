using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class TarefaViewModel : BaseViewModel
    {
        public int TarefaId { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public bool Selecionar { get; set; }

        public int Grupo { get; set; }

        public int Numero { get; set; }
    }
}