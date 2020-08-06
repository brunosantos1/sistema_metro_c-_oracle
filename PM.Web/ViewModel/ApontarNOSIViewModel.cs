using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class ApontarNOSIViewModel
    {
        public NotaViewModel Nota { get; set; }

        public List<MedidaViewModel> MedidaEnum { get; set; }

        public List<NotaViewModel> NotaReferencia { get; set; }

        public List<OperacaoViewModel> Operacaos { get; set; }

        public List<MaoDeObraViewModel> MaoDeObras { get; set; }

        public List<MaterialViewModel> Materials { get; set; }

        public bool Salvar { get; set; }

        public bool Encerrar { get; set; }

        public bool Cancelar { get; set; }
    }
}