using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PM.Web.ViewModel
{
    public class NotaOCOPOLViewModel : BaseViewModel
    {
        public NotaOCOPOLViewModel()
        {
            this.GridListaTarefas = new List<ListaTarefaViewModel>();
            this.GridListaTarefaMateriais = new List<ListaTarefaMaterialViewModel>();
        }
        public int? id_nota { get; set; }
        public int id_nota_Ref { get; set; }
        public string cd_nota_sap_Ref { get; set; }
        public string cd_tp_nota_sap_Ref { get; set; }
        public string ds_descricao_Ref { get; set; }
        public string ds_observacao_Ref { get; set; }

        public int id_local_inst_Ref { get; set; }
        public string cd_local_inst_sap_Ref { get; set; }
        public string ds_local_inst_Ref { get; set; }

        public int id_code_Ref { get; set; }
        public string ds_breve_code_Ref { get; set; }

        public DateTime dt_hora_nota_Ref { get; set; }

        public DateTime dt_hora_nota_encerramento_Ref { get; set; }

        public string ds_breve_CentroTrabalho_Ref { get; set; }

        public int id_tp_nota { get; set; }
        public string cd_tp_nota_sap { get; set; }

        public string ds_descricao { get; set; }

        public int id_prioridade { get; set; }

        public string ds_prioridade { get; set; }

        public string eq_etiqueta { get; set; }

        public string ds_observacao { get; set; }

        public int id_elemento_pep { get; set; }
        public string ds_elemento_pep { get; set; }

        public int id_equipamento { get; set; }
        public string ds_objeto_tecnico { get; set; }
        public string nr_serie_fabricante { get; set; }
        public string nr_identificacao_tecnica { get; set; }
        public string nr_inventario { get; set; }

        public int id_material { get; set; }
        public string ds_material { get; set; }
        public int Qt_Lote { get; set; }
        public int Qt_Giro { get; set; }   // Nao achei a referencia deste campo na tabel
        public int Qt_Indisponivel { get; set; }   // Nao achei a referencia deste campo na tabel

        public int id_ct_trabalho { get; set; }
        public string ds_ct_trabalho { get; set; }
        public string ct_trabalho { get; set; }

        public int id_st_sistema_fk { get; set; }                           //Nao tem na tela
        public int id_un_medid_tempo_prev_fk { get; set; }                  //Nao tem na tela
        public int id_st_pericia_fk { get; set; }                           //Nao tem na tela
        public int id_ev_gerador_fk { get; set; }                           //Nao tem na tela
        public int id_diagnostico_fk { get; set; }                          //Nao tem na tela
        public int di_marco_inicial { get; set; }                           //Nao tem na tela
        public int co_comprimento { get; set; }                             //Nao tem na tela
        public bool if_oper_maior_cinco_min { get; set; }                   //Nao tem na tela
        public bool in_notavel { get; set; }                                //Nao tem na tela
        public bool in_fumaca { get; set; }                                 //Nao tem na tela
        public int tm_previsto { get; set; }                                //Nao tem na tela
        public int nr_contrato { get; set; }                                //Nao tem na tela
        public int fk_nota_vinculo { get; set; }                            //Nao tem na tela

        public string string_lista_tarefa { get; set; }
        public string string_lista_tarefa_material { get; set; }

        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarTipoNota { get; set; }
        public List<SelectListItem> SelecionarPrioridade { get; set; }
        public List<SelectListItem> SelecionarElementoPEP { get; set; }
        public List<SelectListItem> SelecionarEquipamento { get; set; }
        public List<SelectListItem> SelecionarMaterial { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }

        #endregion

        public List<ListaTarefaViewModel> GridListaTarefas { get; set; }
        public List<ListaTarefaMaterialViewModel> GridListaTarefaMateriais { get; set; }
    }

    public class ListaTarefaViewModel : BaseViewModel
    {
        [Display(Name = "Selecionar")]
        public bool Selecionar { get; set; }

        public int id_lt_tarefa { get; set; }

        [Display(Name = "Grupo")]
        public string cd_gp_lt_tarefa { get; set; }

        [Display(Name = "Numero")]
        public string cd_sap { get; set; }

        [Display(Name = "Nome da Lista de Tarefas")]
        public string ds_lt_tarefa { get; set; }

        public int? cd_equipamento_fk { get; set; }
    }

    public class ListaTarefaMaterialViewModel : BaseViewModel
    {
        [Display(Name = "Lista de Tarefas")]
        public string cd_sap { get; set; }

        [Display(Name = "Operação")]
        public string cd_operacao { get; set; }

        [Display(Name = "Código")]
        public string cd_material_antigo { get; set; }

        [Display(Name = "Denominação")]
        public string ds_material { get; set; }

        [Display(Name = "Qtde")]
        public double nr_quantidade { get; set; }

        [Display(Name = "Unidade")]
        public string ds_unidade_medida { get; set; }

        [Display(Name = "Reserva")]
        public bool Selecionar { get; set; }

        public int id_lt_tar_op_comp { get; set; }
        public int id_lt_tarefa_fk { get; set; }
        public int? id_operacao_fk { get; set; }
        public int? id_material_fk { get; set; }
        public int? id_un_duracao_fk { get; set; }
    }
}
