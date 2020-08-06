using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.LogAndAlert.Models;

namespace PM.LogAndAlert.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Notificador(int ID)
        {
            ViewBag.Valor = string.Format("O Notificador é  [{0}]", ID);
            return PartialView();
        }
        public ActionResult CentroDeTrabalho(int ID)
        {
            ViewBag.Valor = string.Format("O Centro De Trabalho é  [{0}]", ID);
            return PartialView();
        }
        public ActionResult Responsavel(int ID)
        {
            ViewBag.Valor = string.Format("O Responsavel é  [{0}]", ID);
            return PartialView();
        }
        public ActionResult Solicitante(int ID)
        {
            ViewBag.Valor = string.Format("O Solicitante é  [{0}]", ID);
            return PartialView();
        }
        public ActionResult AplicacaoLog(string ID)
        {
            //ViewBag.tipolog = new SelectList((new dbTipoLog()).getTipoLog().OrderBy(c => c._text).ToList() , "_value", "_text");
            ViewBag.Valor = string.Format("Estamos falando da aplicação numero [ {0} ]", ID);
            return PartialView();
        }
    }
}