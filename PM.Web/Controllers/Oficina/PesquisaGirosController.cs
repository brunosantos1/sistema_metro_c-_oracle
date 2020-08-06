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

namespace PM.Web.Controllers
{
    /// <summary>
    /// PesquisarNotas Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    [RoutePrefix("Oficina2")]
    public class PesquisaGirosController : BaseController
    {
        /// <summary>
        /// PesquisarNota metodo da Controller responsavel pela chamada da tela e inicializacao dos dados.
        /// </summary>
        [Route("PesquisaGiro")]
        public ActionResult PesquisaGiro()
        {
            PesquisaGiroViewModel telaVM = new PesquisaGiroViewModel();

            #region Carrega DropDownlists

            var materiais = new MaterialServices().GetAll();
            telaVM.SelecionarMaterial = materiais.Select(d => new SelectListItem { Value = d.IdMaterial.ToString(), Text = d.DsMaterial }).ToList();

            var centroTrabalhos = new CentroTrabalhoServices().GetAll();
            telaVM.SelecionarCentroTrabalho = centroTrabalhos.Select(d => new SelectListItem { Value = d.IdCtTrabalho.ToString(), Text = d.DsCtTrabalho }).ToList();

            #endregion

            return View(telaVM);
        }

        /// <summary>
        /// Filtrar metodo da Controller responsavel por filtrar e retornar dos dados da lista.
        /// </summary>
        /// 
        [Route("Filtrar")]
        public ActionResult Filtrar(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Limpar metodo da Controller responsavel por limpar os dados na tela.
        /// </summary>
        /// 
        [Route("Limpar")]
        public ActionResult Limpar(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Imprimir metodo da Controller responsavel por imprimr os dados em relatório.
        /// </summary>
        /// 
        [Route("Imprimir")]
        public ActionResult Imprimir(PesquisaNotaViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Exportar metodo da Controller responsavel por exportar os dados para o excel/pdf.
        /// </summary>
        /// 
        [Route("Exportar")]
        public ActionResult Exportar(PesquisaNotaViewModel telaVM)
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
