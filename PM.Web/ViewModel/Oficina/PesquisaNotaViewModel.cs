using PM.WebServices.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using static PM.Web.ViewModel.Enum.Enum;

namespace PM.Web.ViewModel
{
    public class PesquisaNotaViewModel
    {
        public PesquisaNotaViewModel()
        {
            ConsultaNotas = new List<Nota>();
        }

        public int id_nota_Ref { get; set; }
        public string cd_nota_sap_Ref { get; set; }

        public string cd_tp_nota_sap_Ref { get; set; }
        public string ds_descricao_Ref { get; set; }

        #region  Preenchimento de DropDownList

        public List<SelectListItem> SelecionarMaterial { get; set; }
        public List<SelectListItem> SelecionarTipoNota { get; set; }
        public List<SelectListItem> SelecionarStatusUsuario { get; set; }
        public List<SelectListItem> SelecionarPrioriedade { get; set; }
        public List<SelectListItem> SelecionarCode { get; set; }
        public List<SelectListItem> SelecionarCentroTrabalho { get; set; }

        #endregion

        public int id_tp_nota_fk { get; set; }
        public string ds_elemento_pep { get; set; }
        public string cd_nota_sap { get; set; }

        public int id_nota { get; set; }
        //public string numero_ordem { get; set; }
        public string ds_descricao { get; set; }
        public string eq_etiqueta { get; set; }
        public int id_prioridade_fk { get; set; }
        public int id_equipamento_fk { get; set; }
        public int nr_inventario { get; set; }

        public int id_tp_nota { get; set; }
        public string ar_tp_nota { get; set; }

        public int id_code_sintoma_fk { get; set; }
        public string ds_breve_code { get; set; }

        public int id_st_usuario { get; set; }
        public string ds_st_usuario { get; set; }

        public string ds_objeto_tecnico { get; set; }
        public string nr_serie_fabricante { get; set; }
        public string nr_identificacao_tecnica { get; set; }

        //public int id_ordem { get; set; }
        //public string ds_st_usuario { get; set; }

        public int id_material_fk { get; set; }
        public string ds_material { get; set; }

        public int id_centro_trabalho { get; set; }
        public string ds_breve_centro_trabalho { get; set; }
        public int clickdescricaoNota { get; set; }

        public bool btnConsultar { get; set; }
        public bool btnImprimir { get; set; }
        public bool btnLimpar { get; set; }
        public bool btnExportar { get; set; }

        //public class Nota 
        //{
        //    public Nota Nota { get; set; }
        //    public bool Selecionar { get; set; }
        //}
        public List<Nota> ConsultaNotas { get; set; }
    }
}