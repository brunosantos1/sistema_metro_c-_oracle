using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel.MaterialRodante
{
    public class PesquisarNotaMIViewModel : BaseViewModel
    {
        [DisplayName("Id Nota")]
        public int id_nota { get; set; }

        [DisplayName("Frota")]
        [Required]
        public int? id_frota_fk { get; set; }

        [DisplayName("Trem")]
        [Required]
        public int? id_trem_fk { get; set; }

        [DisplayName("Carro")]
        [Required]
        public int? id_carro_fk { get; set; }

        [DisplayName("N da Nota")]
        public string cd_sap { get; set; }

        [DisplayName("De")]
        public DateTime? dt_inicial { get; set; }

        [DisplayName("Até")]
        public DateTime? dt_final { get; set; }

        [DisplayName("Rg Notificador")]
        [Required]
        public string rg_notificador { get; set; }

        [DisplayName("Notificador")]
        [Required]
        public string nm_notificador { get; set; }

        [DisplayName("Id Notificador")]
        [Required]
        public int? id_notificador_fk { get; set; }

        [DisplayName("Status")]
        public int? id_status_usuario { get; set; }

        public IEnumerable<SelectListItem> TypeList
        {
            get
            {
                return new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Frota 1", Value = "1"},
                        new SelectListItem { Text = "Frota 2", Value = "2"},
                        new SelectListItem { Text = "Frota 3", Value = "3"}
                    };
            }
        }

        public IEnumerable<SelectListItem> LocalList
        {
            get
            {
                return new List<SelectListItem>
                    {
                        new SelectListItem { Text = "", Value = ""},
                        new SelectListItem { Text = "Via", Value = "v"},
                        new SelectListItem { Text = "Pátio", Value = "p"}
                    };
            }
        }

        public IEnumerable<SelectListItem> FrotaList
        {
            get; set;
        }
    }
}