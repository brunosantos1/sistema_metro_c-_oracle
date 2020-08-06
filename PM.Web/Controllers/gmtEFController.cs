using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Controllers
{
    public class gmtEFController : Controller
    {
        // GET: gmtEF
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult new_EquipamentoFixo()
        {
            return View();
        }

        public ActionResult SearchNotificador()
        {
            return PartialView();
        }

        public ActionResult SearchCentroDeTrabalho()
        {
            return PartialView();
        }

        public ActionResult getCentroDeTrabalho()
        {
            return View();
        }
        public ActionResult getConsultarOperacoes()
        {
            return View();
        }        
        public ActionResult getConfirmacoes()
        {
            return View();
        }
        public ActionResult new_Colaborador()
        {
            return View();
        }

        public ActionResult detail_NotaOrdem()
        {
            return View();
        }
        public ActionResult cancel_NotaOrdem(int id)
        {
            ViewBag.Valor = string.Format("Vamos Cancelar a Nota/Ordem de Numero {0}", id);
            return View();
        }
}
}