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
    /// PesquisaPrioritarios Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    /// 
    [RoutePrefix("Oficina2")]
    public class PesquisaPrioritariosController : BaseController
    {
        /// <summary>
        /// PesquisarNota metodo da Controller responsavel pela chamada da tela e inicializacao dos dados.
        /// </summary>
        /// 
        [Route("PesquisarPrioritario")]
        public ActionResult PesquisarPrioritario()
        {
            PesquisaPrioritarioViewModel telaVM = new PesquisaPrioritarioViewModel();

            #region  Carrega tipos da Nota para selecao

            var centroTrabalhos = new CentroTrabalhoServices().GetAll();
            telaVM.SelecionarCentroTrabalho = centroTrabalhos.Select(d => new SelectListItem { Value = d.IdCtTrabalho.ToString(), Text = d.DsCtTrabalho }).ToList();

            #endregion

            return View(telaVM);
        }

        [Route("Filtrar")]
        public ActionResult Filtrar(PesquisaPrioritarioViewModel telaVM)
        {
            //telaVM.GridMateriais = new MaterialServices().GetByCentroTrabalho(telaVM.CentroTrabalho.Id).ToList();

            return View(telaVM);
        }

        /// <summary>
        /// Imprimir metodo da Controller responsavel por imprimir os dados em relatório.
        /// </summary>
        /// 
        [Route("Imprimir")]
        public ActionResult Imprimir(PesquisaPrioritarioViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Exportar metodo da Controller responsavel por exportar os dados para pdf/excell.
        /// </summary>
        /// 
        [Route("Exportar")]
        public ActionResult Exportar(PesquisaPrioritarioViewModel telaVM)
        {
            return View(telaVM);
        }

        /// <summary>
        /// Limpar metodo da Controller responsavel por limpar os dados na tela.
        /// </summary>
        /// 
        [Route("Limpar")]
        public ActionResult Limpar(PesquisaPrioritarioViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Cancelar metodo da Controller responsavel por cancelar a nota fiscal.
        /// </summary>
        /// 
        [Route("Cancelar")]
        public ActionResult Cancelar(PesquisaPrioritarioViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Liberar metodo da Controller responsavel por liberar a nota fiscal.
        /// </summary>
        /// 
        [Route("Liberar")]
        public ActionResult Liberar(PesquisaPrioritarioViewModel telaVM)
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
