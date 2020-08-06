using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class EstruturaViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Item")]
        public string Item { get; set; }

        public MaterialViewModel Material { get; set; }

        public EquipamentoViewModel Equipamento { get; set; }

        public EquipamentoViewModel SubEquipamento { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name = "Ação")]
        public string AcaoTipo { get; set; }

        public bool DesmontarSubEquip { get; set; }

        public bool MontarSubEquip { get; set; }
    }
}