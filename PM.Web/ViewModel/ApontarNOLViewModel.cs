using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class ApontarNOLViewModel
    {
        public MaterialViewModel Material { get; set; }

        public List<ApontamentoLoteViewModel> Apontar { get; set; }

        public List<OperacaoViewModel> Operacaos { get; set; }

        public List<IntervencaoViewModel> Intervencaos { get; set; }

        public List<MaoDeObraViewModel> MaoDeObras { get; set; }

        public List<MaterialViewModel> Materials { get; set; }

        public List<MeioAuxiliarProducaoViewModel> MeioAuxiliarProducaos { get; set; }

        public bool Salvar { get; set; }

        public bool Encerrar { get; set; }

        public bool Cancelar { get; set; }
    }
}