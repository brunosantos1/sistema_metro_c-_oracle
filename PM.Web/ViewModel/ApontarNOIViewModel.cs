using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class ApontarNOIViewModel
    {
        public NotaViewModel Nota { get; set; }

        public List<MedidaViewModel> MedidaEnum { get; set; }

        public List<OperacaoViewModel> Operacaos { get; set; }

        public List<IntervencaoViewModel> Intervencaos { get; set; }

        public List<MaoDeObraViewModel> MaoDeObras { get; set; }

        public List<MaterialViewModel> Materials { get; set; }

        public List<MeioAuxiliarProducaoViewModel> MeioAuxiliarProducaos { get; set; }

        public List<DocumentosMedicaoViewModel> DocumentosMedicaos { get; set; }

        public bool Salvar { get; set; }

        public bool Encerrar { get; set; }

        public bool Cancelar { get; set; }
    }
}