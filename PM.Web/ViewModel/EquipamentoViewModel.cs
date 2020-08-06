using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class EquipamentoViewModel : BaseViewModel
    {
        public int EquipamentoId { get; set; }

        [Display(Name = "Equipamento:")]
        public string Codigo { get; set; }

        [Display(Name = "Descrição do Equipamento:")]
        public string Descricao { get; set; }

        [Display(Name = "Núm. Série:")]
        public string NumeroSerie { get; set; }

        [Display(Name = "Núm. Id. Técnica:")]
        public string NumIdTecnica { get; set; }

        [Display(Name = "Núm. Inventário:")]
        public string NumInventario { get; set; }

        [Display(Name = "Núm. Patrimonio:")]
        public string NumPatrimonio { get; set; }

        [Display(Name = "Selecionar:")]
        public string Selecionar { get; set; }
    }
}