using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.Web.ViewModel;
using PM.Web.ViewModel.MaterialRodante;
using System.Web.Script.Serialization;

namespace PM.Web.Controllers.MaterialRodante
{
    [RoutePrefix("MR/PesquisarNotaMI")]
    public class PesquisarNotaMIController : Controller
    {
        private JsonResult FormatJson(Object values)
        {
            var _values = new { data = values };
            return Json(_values, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Pesquisar")]
        public ActionResult Pesquisar()
        {
            List<Frota> frotas = new FrotaServices().GetAll().ToList();
            List<SelectListItem> frotaSelect = new List<SelectListItem>();

            frotaSelect.Add(new SelectListItem { Text = String.Empty, Value = String.Empty });

            foreach (Frota frota in frotas)
            {
                frotaSelect.Add(new SelectListItem { Text = frota.NmFrota, Value = frota.IdFrota.ToString() });
            }

            PesquisarNotaMIViewModel pesquisarMIVM = new PesquisarNotaMIViewModel();
            pesquisarMIVM.FrotaList = frotaSelect;

            return View("~/Views/MaterialRodante/NotaInspecao/PesquisarMI.cshtml", pesquisarMIVM);
        }

        [HttpGet]
        [Route("GetByFrotaTremCarro")]
        public JsonResult GetByFrotaTremCarro(int idFrota, int idTrem, int idCarro)
        {
            object notas = new NotaServices().GetByFrotaTremCarro(idFrota, idTrem, idCarro);
            object notas_json = new JavaScriptSerializer().Deserialize<object>(notas.ToString());

            return Json(notas_json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetLinhas")]
        public JsonResult GetLinhas()
        {
            List<Linha> linhas = new LinhaServices().GetAll().ToList();
            return Json(linhas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetCentroTrabalho")]
        public JsonResult GetCentroTrabalho()
        {
            List<CentroTrabalho> centros = new CentroTrabalhoServices().GetAll().ToList();
            return Json(centros, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("CentroTrabalhoByLinha")]
        public JsonResult CentroTrabalhoByLinha(int idLinha)
        {
            CentroTrabalho centro = new CentroTrabalhoServices().GetByLinha(idLinha);
            return Json(centro, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LinhaByTrem")]
        public JsonResult LinhaByTrem(int idTrem)
        {
            Linha linha = new LinhaServices().GetByTrem(idTrem);
            return Json(linha, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetStatusUsuario")]
        public JsonResult GetStatusUsuario()
        {
            List<StatusUsuario> listStatus = new StatusUsuarioServices().GetAll();
            return Json(listStatus, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LocalInstalacao")]
        public JsonResult LocalInstalacao(int? idFrota, int? idTrem, int? idCarro)
        {
            List<LocalInstalacao> localInstalacao = new LocalInstalacaoServices().Search(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault()).ToList();
            return Json(localInstalacao, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetData")]
        public JsonResult GetData(int? idFrota = null, int? idTrem = null, int? idCarro = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idNotificador = null, int? rgNotificador = null, int? idStatus = null)
        {
            JsonResult result;

            try
            {
                List<Nota> notas = new NotaServices().PesquisarMI(idFrota, idTrem, idCarro, cdSap, dataInicial, dataFinal, idNotificador, rgNotificador, idStatus).ToList();

                if (notas != null)
                {
                    if (notas.Count > 0)
                    {
                        List<String[]> values = notas.Select(x => new String[] {
                            x.IdNota?.ToString(),
                            x.CdNotaSap,
                            x.TipoNota?.DsTpNota,
                            x.LocalInstalacao?.DsLcInstalacao?.ToString(),
                            x.DsDescricao,
                            x.CodeSintoma?.DsCode?.ToString(),
                            x.Prioridade?.DsPrioridade?.ToString(),
                            x.DtHoraNota?.ToString("MM/dd/yyyy"),
                            x.DtHoraNota?.ToString("HH:mm"),
                            x.Empregado?.NmFuncionario + " " + x.Empregado?.SbFuncionario,
                            String.Join(", ", x.StatusUsuarios.Select(y => y.DsStUsuario)),
                            String.Empty
                        }).ToList();

                        result = FormatJson(values);
                    }
                    else
                    {
                        result = FormatJson(new String[] { });
                    }
                }
                else
                {
                    result = FormatJson(new String[] { });
                }
            }
            catch (Exception e)
            {
                result = FormatJson(new String[] { });
            }

            return result;
        }
    }
}