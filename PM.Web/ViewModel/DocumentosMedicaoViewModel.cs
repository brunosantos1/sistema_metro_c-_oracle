using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class DocumentosMedicaoViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int DocumentosMedicao { get; set; }

        [Display(Name = "Ponto de Med.:")]
        public string PontoMedicao { get; set; }

        [Display(Name = "Item Med.:")]
        public string ItemMedido { get; set; }

        [Display(Name = "Denominação:")]
        public string DenominacaoItemMedido { get; set; }

        [Display(Name = "ValorMedicao:")]
        public int ValorMedicao { get; set; }

        [Display(Name = "ValorTeorico:")]
        public int ValorTeoricoMedicao { get; set; }

        [Display(Name = "Unid.:")]
        public string UniMedicao { get; set; }

        [Display(Name = "Data Medição:")]
        public DateTime DataMedicao { get; set; }

        [Display(Name = "Ação:")]
        public bool Incluir { get; set; }

        [Display(Name = "Ação:")]
        public bool Excluir { get; set; }

        [Display(Name = "Ação:")]
        public bool Estornar { get; set; }
    }
}