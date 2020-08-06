using PM.Web.ViewModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PM.Web.ViewModel.Copese
{
    public class NotaCopeseEFMRViewModel
    {
        public NotaCopeseEFMRViewModel()
        {

        }
        public int? id_nota { get; set; }

        public int id_nota_Ref { get; set; }
        public string cd_nota_sap { get; set; }
        [Required]
        [DisplayName("Nota de Referência")]
        public string cd_nota_sap_Ref { get; set; }
        public string cd_tp_nota_sap_Ref { get; set; }
        public string ds_descricao_Ref { get; set; }
        public string ds_observacao_Ref { get; set; }

        public int id_local_inst_Ref { get; set; }
        public string cd_local_inst_sap_Ref { get; set; }
        public string ds_local_inst_Ref { get; set; }

        public int id_code_Ref { get; set; }
        public string ds_breve_code_Ref { get; set; }

        public DateTime dt_hora_nota { get; set; }
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
        public string nm_st_copese { get; set; }
        public string nm_frota { get; set; }
        public string nm_trem { get; set; }
        public string nm_carro { get; set; }
        public string nm_sintoma { get; set; }
        public string nm_sistema { get; set; }
        public string nm_zona { get; set; }
        public string nm_complemento { get; set; }
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

        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarTipoNota { get; set; }
        public List<SelectListItem> SelecionarPrioridade { get; set; }
        public List<SelectListItem> SelecionarElementoPEP { get; set; }
        public List<SelectListItem> SelecionarEquipamento { get; set; }
        public List<SelectListItem> SelecionarMaterial { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }
        public List<SelectListItem> SelecionarLinha { get; set; }

        #endregion

        public List<TarefaViewModel> GridTarefas { get; set; }
        public List<MaterialViewModel> GridMateriais { get; set; }

        [DisplayName("Notificador")]
        public int id_notificador_fk { get; set; }

        [DisplayName("RG Notificador")]
        public string rg_notificador { get; set; }

        [DisplayName("Nome Notificador")]
        public string nm_notificador { get; set; }

        public int id_linha { get; set; }

        public string nm_linha { get; set; }



        public int? id_plantonista_acionado { get; set; }
        [Required]
        [DisplayName("Plantonista Acionado")]
        public string nm_plantonista_acionado { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O campo CIM Acionado é obrigatório.")]
        [DisplayName("CIM Acionado")] public int id_cim_acionado { get; set; }
        public string nm_cim_acionado { get; set; }
        public int? id_pl_represent_acionado1 { get; set; }
        public string nm_pl_represent_acionado1 { get; set; }
        public int? id_pl_represent_acionado2 { get; set; }
        public string nm_pl_represent_acionado2 { get; set; }
        public int? id_pl_represent_acionado3 { get; set; }
        public string nm_pl_represent_acionado3 { get; set; }
        public int? id_pl_represent_acionado4 { get; set; }
        public string nm_pl_represent_acionado4 { get; set; }
        public OperacaoType Operacao { get; set; }

        public List<SelectListItem> SelecionarCimAcionado { get; set; }

    }
}