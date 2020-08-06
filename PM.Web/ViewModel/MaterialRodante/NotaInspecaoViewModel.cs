using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel.MaterialRodante
{
    public class NotaInspecaoViewModel : BaseViewModel
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

        [DisplayName("Id Sistema")]
        public int? id_sistema_fk { get; set; }

        [DisplayName("Sistema")]
        public string ds_sistema { get; set; }

        [DisplayName("Id Local Instalação")]
        public int? id_local_instalacao_fk { get; set; }

        [DisplayName("Local Instalação")]
        [Required]
        public string ds_local_instalacao { get; set; }

        [DisplayName("Id Sintoma")]
        public int? id_sintoma_fk { get; set; }

        [DisplayName("Sintoma")]
        public string ds_sintoma { get; set; }

        [DisplayName("Id Prioridade")]
        public int? id_prioridade_fk { get; set; }

        [DisplayName("Descrição")]
        [Required]
        public string ds_descricao { get; set; }

        [DisplayName("Prioridade")]
        public string ds_prioridade { get; set; }

        [DisplayName("Notificador")]
        public int? id_notificador_fk { get; set; }

        [DisplayName("RG Notificador")]
        public string rg_notificador { get; set; }

        [DisplayName("Nome Notificador")]
        [Required]
        public string nm_notificador { get; set; }

        [DisplayName("Local")]
        [Required]
        public string sg_local { get; set; }

        [DisplayName("Linha")]
        [Required]
        public int? id_linha_fk { get; set; }

        [DisplayName("Id Centro de Trabalho")]
        public int? id_centro_trabalho_fk { get; set; }

        [DisplayName("Centro de Trabalho")]
        [Required]
        public string ds_centro_trabalho_fk { get; set; }

        [DisplayName("Observação")]
        public string ds_observacao { get; set; }

        [DisplayName("Incidente Notável")]
        public bool st_in_notavel { get; set; }

        [DisplayName("Fumaça")]
        public bool st_fumaca { get; set; }

        [DisplayName("Reboque")]
        public bool st_reboque { get; set; }

        public IEnumerable<SelectListItem> LocalList
        {
            get
            {
                return new List<SelectListItem>
                    {
                        new SelectListItem { Text = "Selecione um item", Value = String.Empty},
                        new SelectListItem { Text = "Via", Value = "v"},
                        new SelectListItem { Text = "Pátio", Value = "p"}
                    };
            }
        }
    }
}