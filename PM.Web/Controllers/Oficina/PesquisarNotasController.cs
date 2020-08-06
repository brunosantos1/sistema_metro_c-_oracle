using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM.Web.ViewModel;
using PM.WebServices.Service;
using PM.WebServices.Models;
using PM.Domain.Entities.Enum;

namespace PM.Web.Controllers
{
    /// <summary>
    /// PesquisarNotas Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    [RoutePrefix("Oficina2")]
    public class PesquisarNotasController : BaseController
    {
        /// <summary>
        /// PesquisarNota metodo da Controller responsavel pela chamada da tela e inicializacao dos dados.
        /// </summary>
        /// 
        [Route("PesquisarNota")]
        public ActionResult PesquisarNota()
        {
            PesquisaNotaViewModel telaVM = new PesquisaNotaViewModel();

            #region  Carrega DropDownlists

            telaVM.clickdescricaoNota = 2;
            telaVM.SelecionarMaterial = CarregaDropDownList(ServicoType.Material);
            telaVM.SelecionarTipoNota = CarregaDropDownList(ServicoType.TipoNota);
            telaVM.SelecionarStatusUsuario = CarregaDropDownList(ServicoType.StatusUsuario);
            telaVM.SelecionarPrioriedade = CarregaDropDownList(ServicoType.Prioridade);
            telaVM.SelecionarCode = CarregaDropDownList(ServicoType.Code);
            telaVM.SelecionarCentroTrabalho = CarregaDropDownList(ServicoType.CentroTrabalho);

            #endregion

            return View("~/Views/oficina/PesquisarNota.cshtml", telaVM);
        }

        /// <summary>
        /// ConsultarNota metodo da Controller responsavel consulta e retorno dos dados da lista.
        /// </summary>
        /// 
        [Route("ConsultarNota")]
        public ActionResult ConsultarNota(PesquisaNotaViewModel telaVM)
        {
            //Pesquisar pelo numero da nota de referencia
            //if (telaVM.id_nota_Ref > 0)
            //{
            //    var notas = new NotaServices().GetByid_nota_Ref(telaVM.id_nota_Ref);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (telaVM.id_tp_nota_fk > 0)
            //{
            //    var notas = new NotaServices().GetByid_tp_nota(telaVM.id_tp_nota_fk);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (!string.IsNullOrEmpty(telaVM.cd_nota_sap))
            //{
            //    var notas = new NotaServices().GetBycd_nota_sap(telaVM.cd_nota_sap);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (!string.IsNullOrEmpty(telaVM.ds_descricao))
            //{
            //    var notas = new NotaServices().GetByds_descricao(telaVM.ds_descricao);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (!string.IsNullOrEmpty(telaVM.eq_etiqueta))
            //{
            //    var notas = new NotaServices().GetByeq_etiqueta(telaVM.eq_etiqueta);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (telaVM.id_st_usuario > 0)
            //{
            //    var notas = new NotaServices().GetByid_st_usuario(telaVM.id_st_usuario);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (telaVM.id_prioridade_fk > 0)
            //{
            //    var notas = new NotaServices().GetByid_prioridade_fk(telaVM.id_prioridade_fk);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (telaVM.id_code_sintoma_fk > 0)
            //{
            //    var notas = new NotaServices().GetByid_code_sintoma_fk(telaVM.id_code_sintoma_fk);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (telaVM.id_equipamento_fk > 0)
            //{
            //    var notas = new NotaServices().GetByid_equipamento_fk(telaVM.id_equipamento_fk);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}
            //else if (telaVM.id_material_fk > 0)
            //{
            //    var notas = new NotaServices().GetByid_material_fk(telaVM.id_material_fk);
            //    telaVM.ConsultaNotas = notas.ToList();
            //}

            Nota nota = new Nota();
            //nota.IdNota = telaVM.id_nota;
            nota.IdNotaReferenciaFk = telaVM.id_nota_Ref;
            nota.IdTpNotaFk = telaVM.id_tp_nota_fk;
            nota.CdNotaSap = telaVM.cd_nota_sap;
            nota.DsDescricao = telaVM.ds_descricao;
            //StatusUsuario stUsuario = new StatusUsuario();
            //stUsuario.IdStUsuario = telaVM.id_st_usuario;
            //nota.StatusUsuarios.Add(stUsuario);
            nota.IdPrioridadeFk = telaVM.id_prioridade_fk;
            //nota.EqEtiqueta = telaVM.eq_etiqueta;
            nota.IdCodeSintomaFk = telaVM.id_code_sintoma_fk;
            nota.IdEquipamentoFk = telaVM.id_equipamento_fk;
            //nota.ds = telaVM.ds_objeto_tecnico;
            nota.IdMaterialFk = telaVM.id_material_fk;
            nota.IdCentroTrabalhoFk = telaVM.id_centro_trabalho;

            var notasRetorno = new NotaServices().ConsultarNotaParametros(nota);
            telaVM.ConsultaNotas = notasRetorno.ToList();

            #region  Carrega DropDownlists

            telaVM.clickdescricaoNota = 2;
            telaVM.SelecionarMaterial = CarregaDropDownList(ServicoType.Material);
            telaVM.SelecionarTipoNota = CarregaDropDownList(ServicoType.TipoNota);
            telaVM.SelecionarStatusUsuario = CarregaDropDownList(ServicoType.StatusUsuario);
            telaVM.SelecionarPrioriedade = CarregaDropDownList(ServicoType.Prioridade);
            telaVM.SelecionarCode = CarregaDropDownList(ServicoType.Code);
            telaVM.SelecionarCentroTrabalho = CarregaDropDownList(ServicoType.CentroTrabalho);

            #endregion

            return View("~/Views/oficina/PesquisarNota.cshtml", telaVM);
        }

        /// <summary>
        /// ImprimirNota metodo da Controller responsavel por imprimir os dados em relatório.
        /// </summary>
        /// 
        [Route("ImprimirNota")]
        public ActionResult ImprimirNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// ExportarNota metodo da Controller responsavel por exportar os dados para pdf/excell.
        /// </summary>
        /// 
        [Route("ExportarNota")]
        public ActionResult ExportarNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// DetalhesNota metodo da Controller responsavel por mostrar os dados na tela.
        /// </summary>
        /// 
        [Route("DetalhesNota")]
        public ActionResult DetalhesNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// EditarNota metodo da Controller responsavel pela edição dos dados na tela.
        /// </summary>
        /// 
        [Route("EditarNota")]
        public ActionResult EditarNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// CancelarNota metodo da Controller responsavel por Cancelar a Nota Fiscal.
        /// </summary>
        /// 
        [Route("CancelarNota")]
        public ActionResult CancelarNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// ConfirmarNota metodo da Controller responsavel por Confirmar a gravacao dos dados.
        /// </summary>
        /// 
        [Route("ConfirmarNota")]
        public ActionResult ConfirmarNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// AgendarNota metodo da Controller responsavel por gravar o agendamento da nota fiscal.
        /// </summary>
        /// 
        [Route("AgendarNota")]
        public ActionResult AgendarNota(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);

        }
    }
}
