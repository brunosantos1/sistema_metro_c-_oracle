using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Controllers
{
    public class OficinaController : Controller
    {
        // GET: Oficina
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NotaOCOPOL(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }

            return View();
        }

        [HttpGet]
        public ActionResult NotaOI(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }

            return View();
        }

        [HttpGet]
        public ActionResult NotaPS(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "new";
            }
            else
            {
                ViewBag.Action = "edit";
            }

            return View();
        }







        public ActionResult PesquisarNota()
        {
            return View();
        }

        public ActionResult ConsultarNotaOCOPOL()
        {
            return View();
        }

        public ActionResult ConsultarNotaOI()
        {
            return View();
        }

        public ActionResult ConsultarNotaPS()
        {
            return View();
        }

        public ActionResult LiberarEquipamentoMaterialIndividualmente()
        {
            return View();
        }

        public ActionResult MontarSubequipamento()
        {
            return View();
        }

        public ActionResult LiberarMaterialEmLote()
        {
            return View();
        }

        public ActionResult PesquisarPrioritario()
        {
            return View();
        }

        public ActionResult RelatorioPrioritario()
        {
            return View();
        }

        public ActionResult PesquisarGiro()
        {
            return View();
        }

        public ActionResult RelatorioGiro()
        {
            return View();
        }

        public ActionResult ApontarNotaOrdemIndividualmente()
        {
            return View();
        }

        public ActionResult ApontarNotaOrdemLote()
        {
            return View();
        }

        public ActionResult ApontarNotaOrdemPrestacaoServico()
        {
            return View();
        }

        public ActionResult ApontarNotaOrdemServicoInterno()
        {
            return View();
        }
    }
}