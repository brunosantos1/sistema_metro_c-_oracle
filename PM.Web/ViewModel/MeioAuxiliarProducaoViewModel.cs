using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class MeioAuxiliarProducaoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int MeioAuxiliarProducao { get; set; }

        [Display(Name = "Operação:")]
        public int CodOperacao { get; set; }

        [Display(Name = "Equipamento:")]
        public string NumeroEquipamento { get; set; }

        [Display(Name = "Denominação:")]
        public DateTime NomeEquipamento { get; set; }   

        [Display(Name = "Patrimônio:")]
        public string Patrimonio { get; set; }

        public bool Incluir { get; set; }

        public bool Excluir { get; set; }

        public bool Estornar { get; set; }
    }
}