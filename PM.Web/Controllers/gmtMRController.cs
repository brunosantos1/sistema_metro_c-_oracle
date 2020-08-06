using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Controllers
{
    public class gmtMRController : Controller
    {
        // GET: gmtMR
        public ActionResult new_Novo() { return View(); }
        public ActionResult new_DefeitoDetectado() { return View(); }
        public ActionResult new_NotaCorretiva() { return View(); }
        public ActionResult new_NotaDeServico() { return View(); }

        public ActionResult new_SolicitarEntregaDeTrem() { return View(); }
        public ActionResult new_SolicitarManobra() { return View(); }
        public ActionResult new_DocumentoDeMedicao() { return View(); }
        



        public ActionResult search_EntregaTrem() { return View(); }
        public ActionResult search_Manobra() { return View(); }
        public ActionResult search_Nota() { return View(); }
        public ActionResult search_NotaCorretiva() { return View(); }
        public ActionResult search_NotaInspecao() { return View(); }
        public ActionResult search_Ordens() { return View(); }
        public ActionResult search_Trens() { return View(); }

        public ActionResult detail_NotaCorretiva() { return View(); }
        public ActionResult detail_NotaDeServico() { return View(); }
        public ActionResult detail_NotaDeInspecao() { return View(); }
        public ActionResult detail_DefeitoDectado() { return View(); }

    }
}