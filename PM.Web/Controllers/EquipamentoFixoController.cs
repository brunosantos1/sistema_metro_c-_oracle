using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Models;
using PM.WebServices.Service;

namespace PM.Web.Controllers
{
    public class EquipamentoFixoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NotaED(int? id)
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
        public ActionResult NotaEI(int? id)
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
        public ActionResult NotaEC(int? id)
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

        public ActionResult CancelarNota()
        {
            return View();
        }

        public ActionResult DetalhesNota()
        {
            return View();
        }

        public ActionResult PesquisarNota()
        {
            ViewBag.Tipo = "nota";
            return View("PesquisarNotaOrdem");
        }

        public ActionResult PesquisarOrdem()
        {
            ViewBag.Tipo = "ordem";
            return View("PesquisarNotaOrdem");
        }

        public ActionResult ApontarNota()
        {
            return View();
        }

        [HttpGet]
        public JsonResult OperacoesOrdem(int? id)
        {
            //List<Object> resultado = new List<object>();

            Ordem ordem;
            List<OperacaoOrdem> operacoesOrdem = new List<OperacaoOrdem>();
            if (id != null)
            {
                operacoesOrdem = new OperacaoOrdemServices().GetByOrdem((int)id).ToList();
            }
            return Json(operacoesOrdem, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public JsonResult OperacoesOrdem(OrdemViewModel ordem)
        //{
        //    OrdemModel.Nome = OrdemViewModel.Nome;
        //    //List<Object> resultado = new List<object>();

        //    Ordem ordem;
        //    List<OperacaoOrdem> operacoesOrdem = new List<OperacaoOrdem>();
        //    if (id != null)
        //    {
        //        operacoesOrdem = new OrdemServices().GetByOrdem((int)id).ToList();
        //    }
        //    return Json(operacoesOrdem, JsonRequestBehavior.AllowGet);
        //}


        //[HttpGet]
        //public ActionResult ApontarOrdem(int? id)
        //{
        //    Ordem ordem;
        //    Nota nota;
        //    List<MedidaNota> medidasNota;
        //    List<Nota> notasVinculadas;
        //    List<OperacaoOrdem> operacoesOrdem;

        //    if (id == null)
        //    {
        //        ordem = new Ordem();
        //    }
        //    else
        //    {
        //        ordem = new OrdemServices().GetById((int)id);
        //        if (ordem != null && ordem.FkNota != null)
        //        {
        //            try
        //            {
        //                nota = new NotaServices().GetById((int)ordem.FkNota);
        //                if (nota != null && nota.IdNota != null)
        //                {
        //                    ordem.Nota = nota;
        //                    medidasNota = new MedidaNotaServices().GetByNota((int)nota.IdNota).ToList();

        //                    ordem.Nota.MedidasNota = medidasNota;
        //                    notasVinculadas = new NotaServices().GetNotasVinculadas((int)nota.IdNota).ToList();
        //                    //ordem.Nota.NotasVinculadas = notasVinculadas;

                            

        //                }
        //            } catch(Exception ex)
        //            {
        //                System.Console.WriteLine("Hello World");
        //            }
                    
        //        }

        //    }

        //    return View(ordem);
        //}

        public ActionResult TransferirNota()
        {
            return View();
        }

        public ActionResult CriarNotaEA()
        {
            return View();
        }

        public ActionResult PesquisarOperacao()
        {
            return View();
        }


        public ActionResult PesquisarConfirmacao()
        {
            return View();
        }

        public ActionResult AceitarTransferencia()
        {
            return View();
        }

        public ActionResult RecusarTransferencia()
        {
            return View();
        }

        public ActionResult ConsultarNotaVinculada()
        {
            return View();
        }

        public ActionResult Programacao()
        {
            return View();
        }

        public ActionResult ConsultarMicroprogramacao()
        {
            return View();
        }

        public ActionResult Planejamento()
        {
            return View();
        }

        public ActionResult EnvioEmail()
        {
            return View();
        }

        public ActionResult VisualizarMicroprogramacao()
        {
            return View();
        }

        public ActionResult CriarOrdem()
        {
            return View();
        }

        public ActionResult ParalisarNota()
        {
            return View();
        }

        public ActionResult FinalizarNotaECED()
        {
            return View();
        }

        public ActionResult FinalizarNotaEP()
        {
            return View();
        }


        public ActionResult InserirDocumentoMedicao()
        {
            return View();
        }






        public ActionResult ApontamentoHorariosLiberacao()
        {
            return View();
        }

        public ActionResult VisualizarProgramavel()
        {
            return View();
        }

        public ActionResult PesquisarMedidas()
        {
            return View();
        }

        public ActionResult CentroTrabalho()
        {
            return View();
        }

        public ActionResult PesquisarCentroTrabalho()
        {
            return View();
        }
    }
}