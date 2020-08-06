using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class MontarSubEquipamentoViewModel
    {
        public EquipamentoViewModel Equipamento { get; set; }

        public MaterialViewModel Material { get; set; }

        public List<EquipamentoViewModel> Equipamentos { get; set; }

        public List<MaterialViewModel> Materials { get; set; }

        public List<EstruturaViewModel> Estruturas { get; set; }
    }
}