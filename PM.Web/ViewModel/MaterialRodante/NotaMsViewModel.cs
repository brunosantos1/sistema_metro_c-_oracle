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
    public class NotaMsViewModel : BaseViewModel
    {
        public NotaMsViewModel()
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

        [DisplayName("Complemento")]
        [Required]
        public int? id_complemento_fk { get; set; }

        [DisplayName("Posição")]
        [Required]
        public int? id_posicao_fk { get; set; }

        [DisplayName("Local Instalação")]
        public int? id_local_instalacao_fk { get; set; }
        [DisplayName("Descrição do Local Instalação")]
        public string ds_local_instalacao { get; set; }


        [DisplayName("Tipo de Serviço")]
        [Required]
        public int? id_code_tp_servico_fk { get; set; }


        [DisplayName("Descrição")]
        [Required]
        public string ds_descricao { get; set; }


        [DisplayName("Cód Solicitante")]
        [Required]
        public int? id_solicitante_fk { get; set; }

        [DisplayName("Solicitante")]
        [Required]
        public string nm_solicitante { get; set; }

        [DisplayName("Linha")]
        [Required]
        public int? id_linha_fk { get; set; }

        [DisplayName("Cód Centro de Trabalho")]
        [Required]
        public int? id_centro_trabalho_fk { get; set; }

        [DisplayName("Data Programada")]
        public string dt_programada { get; set; }

        [DisplayName("Hora Programada")]
        public string hr_programada { get; set; }

        public string dt_hora_programada { get; set; }

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