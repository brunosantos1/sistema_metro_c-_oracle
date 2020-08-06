using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.Web.Controllers
{
    public class OficinasController : Controller
    {
        // GET: Oficinas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }
    }
}