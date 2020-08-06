using PM.Web.ViewModel.Enum;
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
    public class NotaPericiaMRViewModel : BaseViewModel
    {
        string _dt_hora_nota;

        public NotaPericiaMRViewModel() { }

        [DisplayName("Nota de referência")]
        public string cd_nota_sap_Ref { get; set; }

        [DisplayName("Nota")]
        public string cd_nota_sap { get; set; }

        [DisplayName("Tipo da Nota")]
        public int id_tp_nota_fk { get; set; }
        //public int IdLinhaFk { get; set; }
        
        public string nm_frota { get; set; }

        public string cd_sap_trem { get; set; }
        public string nm_trem { get; set; }

        public int id_carro { get; set; }

        public string nm_carro { get; set; }

        public string ds_evento_gerador { get; set; }

        [DisplayName("Num BO Metro")]
        public string cd_bo_metro { get; set; }

        [DisplayName("Descr BO Metro")]
        public string ds_bo_metro { get; set; }

        [DisplayName("Num BO SSP")]
        public string cd_bo_ssp { get; set; }

        [DisplayName("Descr BO SSP")]
        public string ds_bo_ssp { get; set; }

        [DisplayName("Notificador")]
        public int id_notificador_fk { get; set; }

        [DisplayName("RG Notificador")]
        public string rg_notificador { get; set; }

        [DisplayName("Nome Notificador")]
        public string nm_notificador { get; set; }

        public int id_linha { get; set; }

        public string nm_linha { get; set; }

        [DisplayName("Descrição")]
        public string ds_descricao { get; set; }

        [DisplayName("Observação")]
        public string ds_observacao { get; set; }

        [DisplayName("Data da Nota Perícia:")]
        public string dt_hora_nota
        {
            get
            {
                return _dt_hora_nota;
            }
            set
            {
                _dt_hora_nota = value;
            }
        }

        [DisplayName("Data da Nota Perícia:")]
        public string dt_hora_nota_ref { get; set; }

        public int id_local_inst { get; set; }

        #region Foren Key
        public int id_local_inst_Ref { get; set; }

        public int? id_frota_fk { get; set; }

        public int? id_trem_fk { get; set; }

        public int? id_ev_gerador_fk { get; set; }

        public int? id_st_pericia_fk { get; set; }

        [DisplayName("Situação da Perícia")]
        public string ds_st_pericia { get; set; }

        [DisplayName("Centro de Trabalho")]
        public int? id_centro_trabalho_fk { get; set; }

        public string ds_ct_trabalho { get; set; }

        [DisplayName("Nota Referência")]
        public int? id_nota_referencia_fk { get; set; }

        public int id_nota { get; set; }
        #endregion

        #region  Preenchimento de DropDownList
        public List<SelectListItem> SelecionarStatusPericia { get; set; }

        public List<SelectListItem> SelecionarFrota { get; set; }
        public List<SelectListItem> SelecionarTrem { get; set; }
        public List<SelectListItem> SelecionarCarro { get; set; }

        public List<SelectListItem> SelecionarEventoGerador { get; set; }
        public List<SelectListItem> SelecionarLinha { get; set; }
        #endregion

        public bool habilitaNotaReferencia { get; set; }
        public bool btnSalvar { get; set; }
        public bool btnCancelar { get; set; }

        public OperacaoType Operacao { get; set; }
    }
}
