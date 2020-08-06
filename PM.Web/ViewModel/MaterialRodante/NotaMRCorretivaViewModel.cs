using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM.Web.ViewModel.MaterialRodante
{
    public class NotaMRCorretivaViewModel : BaseViewModel
    {
        public NotaMRCorretivaViewModel()
        {
        }
        [DisplayName("Id Nota")]
        public int? id_nota { get; set; }
        [DisplayName("Frota")]
        [Required]
        public int? id_frota_fk { get; set; }
        [DisplayName("Trem")]
        [Required]
        public int? id_trem_fk { get; set; }
        [DisplayName("Carro")]
        [Required]
        public int? id_carro_fk { get; set; }
        [DisplayName("Sistema")]
        [Required]
        public int? id_sistema_fk { get; set; }
        [DisplayName("Local Instalação")]
        public int? id_local_instalacao_fk { get; set; }
        [DisplayName("Descrição do Local Instalação")]
        public string ds_local_instalacao { get; set; }
        [DisplayName("Sintoma")]
        [Required]
        public int? id_sintoma_fk { get; set; }
        [DisplayName("Descrição")]
        [Required]
        public string ds_descricao { get; set; }
        [DisplayName("Prioridade")]
        [Required]
        public int? id_prioridade_fk { get; set; }
        [DisplayName("Linha")]
        [Required]
        public int? id_linha_fk { get; set; }

        [DisplayName("Local")]
        [Required]
        public string sg_local { get; set; }

        [DisplayName("Rg Notificador")]
        public string rg_notificador { get; set; }


        [DisplayName("Notificador")]
        [Required]
        public string nm_notificador { get; set; }

        [DisplayName("Id Notificador")]
        [Required]
        public int? id_notificador_fk { get; set; }

        [DisplayName("Interf. Operacional>5min")]
        public bool st_if_oper_maior_cinco_min { get; set; }
        [DisplayName("Incidente Notável")]
        public bool st_in_notavel { get; set; }
        [DisplayName("Fumaça")]
        public bool st_fumaca { get; set; }
        [DisplayName("Reboque")]
        public bool st_reboque { get; set; }


        [DisplayName("Cód Centro de Trabalho")]
        [Required]
        public int? id_centro_trabalho_fk { get; set; }

        [DisplayName("Centro Trabalho")]
        public string ds_centro_trabalho { get; set; }

        [DisplayName("Observação")]
        public string ds_observacao { get; set; }

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
    }
}