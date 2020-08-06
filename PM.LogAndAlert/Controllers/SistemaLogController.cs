using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.LogAndAlert.Controllers
{
    public class SistemaLogController : Controller
    {
        // GET: SistemaLog
        public ActionResult acesso()
        {
            return View();
        }

        public ActionResult operacoes()
        {
            return View();
        }
        
    }
}