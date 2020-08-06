using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace PM.Web.ViewModel.Copese
{
    public class PesquisaNotaCopeseEFMRViewModel : BaseViewModel
    {
        public PesquisaNotaCopeseEFMRViewModel()
        {
            this.gridNotaCopese = new List<GridNotaCopeseViewModel>();
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

        public string nm_frota { get; set; }

        public string cd_sap_trem { get; set; }
        public string nm_trem { get; set; }

        [DisplayName("Carro")]
        public int id_carro { get; set; }
        public string nm_carro { get; set; }

        public int id_local_inst { get; set; }
        public int id_local_inst_Ref { get; set; }

        #region Foren Key
        [DisplayName("Frota")]
        public int? id_frota_fk { get; set; }

        [DisplayName("Trem")]
        public int? id_trem_fk { get; set; }

        [DisplayName("Situação da Copese")]
        public int? id_st_copese_fk { get; set; }
        #endregion

        public int id_frota { get; set; }
        public int id_trem { get; set; }
        public int id_linha { get; set; }
        public int id_zona { get; set; }
        public int id_sistema { get; set; }
        public int id_complemento { get; set; }
        public int id_sintoma { get; set; }
        public int id_status_pericia { get; set; }
        public string nr_copese { get; set; }
        public string nr_nota_ref { get; set; }
        public string dt_inicio { get; set; }
        public string dt_fim { get; set; }
        public IList<GridNotaCopeseViewModel> gridNotaCopese { get; set; }

    }
}