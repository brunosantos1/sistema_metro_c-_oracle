using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class ApontarNOPSViewModel
    {
        public NotaViewModel Nota { get; set; }

        [Display(Name = "Nome do Cliente:")]
        public string NomeCliente { get; set; }

        [Display(Name = "Nº do Contrato:")]
        public int NumeroContrato { get; set; }

        public List<MedidaViewModel> MedidaEnum { get; set; }

        public List<OperacaoViewModel> Operacaos { get; set; }

        public List<MaoDeObraViewModel> MaoDeObras { get; set; }

        public List<MaterialViewModel> Materials { get; set; }

        public bool Salvar { get; set; }

        public bool Encerrar { get; set; }

        public bool Cancelar { get; set; }
    }
}