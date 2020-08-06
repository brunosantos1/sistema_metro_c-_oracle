using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace PM.Web.ViewModel.Pericia
{
    public class PesquisaNotaPericiaMRViewModel : BaseViewModel
    {
        public PesquisaNotaPericiaMRViewModel()
        {
            this.gridNotaCopese = new List<GridNotaPericiaViewModel>();
        }
        public LocalInstalacaoRefViewModel LocalInstalacaoRef_ret { get; set; }
        public List<SelectListItem> SelecionarFrota { get; set; }
        public List<SelectListItem> SelecionarTrem { get; set; }
        public List<SelectListItem> SelecionarCarro { get; set; }
        public List<SelectListItem> SelecionarLinha { get; set; }
        public List<SelectListItem> SelecionarZona { get; set; }
        public List<SelectListItem> SelecionarSistema { get; set; }
        public List<SelectListItem> SelecionarComplemento { get; set; }
        public List<SelectListItem> SelecionarSintoma { get; set; }
        public List<SelectListItem> SelecionarStatusPericia { get; set; }
        public List<SelectListItem> SelecionarStatusCopese { get; set; }
        public List<SelectListItem> SelecionarEventoGerador { get; set; }


        public string nm_frota { get; set; }

        public string cd_sap_trem { get; set; }
        public string nm_trem { get; set; }

        [DisplayName("Carro")]
        public int id_carro { get; set; }
        public string nm_carro { get; set; }

        public int id_local_inst { get; set; }

        #region Foren Key
        [DisplayName("Frota")]
        public int? id_frota_fk { get; set; }

        [DisplayName("Trem")]
        public int? id_trem_fk { get; set; }

        [DisplayName("Situação da Perícia")]
        public int? id_st_pericia_fk { get; set; }
        #endregion

        [DisplayName("Num BO Metro")]
        public string cd_bo_metro { get; set; }

        [DisplayName("Num BO SSP")]
        public string cd_bo_ssp { get; set; }

        public int id_nota { get; set; }

        [DisplayName("Nota de referência")]
        public string cd_nota_sap_Ref { get; set; }

        [DisplayName("Nota")]
        public string cd_nota_sap { get; set; }

        public int id_frota { get; set; }
        public int id_trem { get; set; }
        public int id_linha { get; set; }
        public int id_zona { get; set; }
        public int id_sistema { get; set; }
        public int id_complemento { get; set; }
        public int id_sintoma { get; set; }
        public int id_ev_gerador_fk { get; set; }
        public string dt_inicio { get; set; }
        public string dt_fim { get; set; }
        public IList<GridNotaPericiaViewModel> gridNotaCopese { get; set; }

    }
    public class GridNotaPericiaViewModel : BaseViewModel
    {
        public GridNotaPericiaViewModel()
        {

        }
        public string cd_nota_sap { get; set; }
        public string cd_nota_sap_Ref { get; set; }
        public string nr_lc_inst { get; set; }
        public string ds_lc_inst { get; set; }
        public string ds_nota { get; set; }
        public string ds_evento_gerador { get; set; }
        public string dt_nota { get; set; }
        public string hr_nota { get; set; }
        public string ds_st_pericia { get; set; }
        public string id_nota { get; set; }
    }
}