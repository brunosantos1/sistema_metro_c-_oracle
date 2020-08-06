using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class MedidaViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int Medida { get; set; }

        public string Historico { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime HoraInicio { get; set; }

        public string Motivo { get; set; }

        public string Responsavel { get; set; }
    }
}