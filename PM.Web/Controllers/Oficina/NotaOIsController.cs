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
    /// NotaOIs Controller responsavel pelas ações e trocas de dados de Front e Back.
    /// </summary>
    /// 
    [RoutePrefix("Oficina2")]
    public class NotaOIsController : BaseController
    {
        /// <summary>
        /// Criar metodo da Controller responsavel pela chamada da tela e inicializacao dos dados.
        /// </summary>
        /// 
        [Route("Criar")]
        public ActionResult Criar()
        {
            NotaOIViewModel telaVM = new NotaOIViewModel();

            #region  Carrega DropDownlists

            var tipoNotas = new TipoNotaServices().GetAll();
            telaVM.SelecionarTipoNota = tipoNotas.Select(d => new SelectListItem { Value = d.IdTpNota.ToString(), Text = d.DsTpNota }).ToList();

            var prioridades = new PrioridadeServices().GetAll();
            telaVM.SelecionarPrioridade = prioridades.Select(d => new SelectListItem { Value = d.IdPrioridade.ToString(), Text = d.DsPrioridade }).ToList();

            var centroTrabalhos = new CentroTrabalhoServices().GetAll();
            telaVM.SelecionarCentroTrabalho = centroTrabalhos.Select(d => new SelectListItem { Value = d.IdCtTrabalho.ToString(), Text = d.DsCtTrabalho }).ToList();

            #endregion

            return View(telaVM);
        }

        /// <summary>
        /// HttpPost Criar metodo da Controller responsavel pelo envio dos dados ao servioco de gravacao.
        /// </summary>
        /// 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "Salvar", Argument = "Salvar")]
        public ActionResult Criar(NotaOIViewModel telaVM)
        {

            return View(telaVM);
        }

        /// <summary>
        /// Cancelar metodo da Controller responsavel por cancelar a nota fiscal.
        /// </summary>
        /// 
        [Route("Cancelar")]
        public ActionResult Cancelar(NotaOIViewModel telaVM)
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
