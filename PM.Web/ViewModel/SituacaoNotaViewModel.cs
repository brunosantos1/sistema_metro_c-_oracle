using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class SituacaoNotaViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string Descricao { get; set; }
    }
}