using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PM.Web.ViewModel.MaterialRodante;
using System;
using PM.Domain.Entities.Enum;

namespace PM.Web.Controllers.MaterialRodante
{
    [RoutePrefix("MR/NotaInspecao")]
    public class NotaInspecaoController : Controller
    {
        private JsonResult FormatJson(Object values)
        {
            var _values = new { data = values };
            return Json(_values, JsonRequestBehavior.AllowGet);
        }

        private string GenCodSap()
        {
            DateTime nx = new DateTime(1970, 1, 1);
            TimeSpan ts = DateTime.UtcNow - nx;
            String timeStamp1 = ((int)ts.TotalSeconds).ToString();

            return String.Concat("sp", timeStamp1);
        }

        private NotaInspecaoViewModel ModelToViewModel(Nota nota)
        {
            NotaInspecaoViewModel notaInspecaoVM = new NotaInspecaoViewModel();

            notaInspecaoVM.id_nota = nota.IdNota ?? 0;
            notaInspecaoVM.id_frota_fk = nota.LocalInstalacao?.IdFrotaFk;
            notaInspecaoVM.id_trem_fk = nota.LocalInstalacao?.IdTremFk;
            notaInspecaoVM.id_carro_fk = nota.LocalInstalacao?.IdCarroFk;
            notaInspecaoVM.id_sistema_fk = nota.CodeSintoma?.IdGrCodeFk;
            notaInspecaoVM.ds_sistema = nota.CodeSintoma?.GrupoCode?.DsGpCode;
            notaInspecaoVM.id_local_instalacao_fk = nota.IdLocalInstFk;
            notaInspecaoVM.ds_local_instalacao = nota.LocalInstalacao?.DsLcInstalacao;
            notaInspecaoVM.id_sintoma_fk = nota.IdCodeSintomaFk;
            notaInspecaoVM.ds_sintoma = nota.CodeSintoma?.DsCode;
            notaInspecaoVM.ds_descricao = nota.DsDescricao;
            notaInspecaoVM.id_prioridade_fk = nota.IdPrioridadeFk;
            notaInspecaoVM.ds_prioridade = nota.Prioridade?.DsPrioridade;
            notaInspecaoVM.id_notificador_fk = nota.IdNotificadorFk;
            notaInspecaoVM.nm_notificador = String.Concat(nota.Empregado?.NmFuncionario ?? String.Empty, " ", nota.Empregado?.SbFuncionario ?? String.Empty);
            notaInspecaoVM.rg_notificador = nota.Empregado?.RgEmpregado;
            notaInspecaoVM.sg_local = nota.SgLocal;
            notaInspecaoVM.id_linha_fk = nota.IdLinhaFk;
            notaInspecaoVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
            notaInspecaoVM.ds_centro_trabalho_fk = nota.CentroTrabalho?.DsCtTrabalho;
            notaInspecaoVM.ds_observacao = nota.DsObservacao;
            notaInspecaoVM.st_in_notavel = nota.StInNotavel ?? false;
            notaInspecaoVM.st_fumaca = nota.StFumaca ?? false;
            notaInspecaoVM.st_reboque = nota.StReboque ?? false;

            return notaInspecaoVM;
        }

        [HttpGet]
        [Route("Cadastro")]
        public ActionResult NotaMI(int? id, bool copiarUltima = false)
        {
            NotaInspecaoViewModel notaInspecaoVM = new NotaInspecaoViewModel();

            //Nota existente
            if (id > 0)
            {
                Nota nota = new NotaServices().GetNavigationPropertiesById(id.Value);

                //Nota existente
                if (nota?.IdNota != null)
                {
                    ViewBag.Action = "Editar";
                    notaInspecaoVM = ModelToViewModel(nota);
                }
                //Nova nota
                else
                {
                    ViewBag.Action = "Criar";
                }
            }
            //Nova nota
            else
            {
                if (copiarUltima)
                {
                    Nota nota = new NotaServices().CarregarUltima(TipoNotaSelecionarType.MI.ToString());
                    nota.IdNota = null;
                    nota.CdNotaSap = null;

                    notaInspecaoVM = ModelToViewModel(nota);
                }

                ViewBag.Action = "Criar";
            }

            return View("~/Views/MaterialRodante/NotaInspecao/NotaMi.cshtml", notaInspecaoVM);
        }

        [HttpGet]
        [Route("GetFrotas")]
        public JsonResult GetFrotas()
        {
            List<Frota> frotas = new FrotaServices().GetAll().ToList();
            return Json(frotas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetTrens")]
        public JsonResult GetTrens(int? id_frota)
        {
            List<Trem> trens;

            if (id_frota > 0)
            {
                trens = new TremServices().GetByFrota(id_frota.Value).ToList();
            }
            else
            {
                trens = new TremServices().GetAll().ToList();
            }

            return Json(trens, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetTrem")]
        public JsonResult GetTrem(int? id)
        {
            Trem trem;

            if (id > 0)
            {
                trem = new TremServices().GetById(id.Value);
            }
            else
            {
                trem = null;
            }

            return Json(trem, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetCarros")]
        public JsonResult GetCarros(int? id)
        {
            List<Carro> carros;

            if (id > 0)
            {
                carros = new CarroServices().GetByTrem(id.Value).ToList();
            }
            else
            {
                carros = new CarroServices().GetAll().ToList();
            }

            return Json(carros, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetLinhas")]
        public JsonResult GetLinhas()
        {
            List<Linha> linhas = new LinhaServices().GetAll()?.ToList();
            return Json(linhas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetLocalInstalacao")]
        public JsonResult LocalInstalacao(int? idFrota, int? idTrem, int? idCarro)
        {
            List<LocalInstalacao> localInstalacao = new LocalInstalacaoServices()
                .Search(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault()).ToList();

            return Json(localInstalacao, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Notificadores")]
        public ActionResult GetNotificadores()
        {
            return View("~/Views/Shared/SelecionarEmpregado.cshtml");
        }

        [HttpPost]
        [Route("GetEmpregados")]
        public JsonResult GetEmpregados(string nome_rg)
        {
            JsonResult result;

            if (!String.IsNullOrEmpty(nome_rg))
            {
                List<Empregado> empregados = new EmpregadoServices().GetByNomeOrRG(nome_rg).ToList();

                if (empregados != null)
                {
                    List<String[]> values = empregados.Select(x => new String[] {
                            x.IdEmpregado?.ToString(),
                            x.RgEmpregado,
                            String.Concat(x.NmFuncionario, " ", x.SbFuncionario)
                        }).ToList();

                    result = FormatJson(values);
                }
                else
                {
                    result = FormatJson(new List<String[]>());
                }
            }
            else
            {
                result = FormatJson(new List<String[]>());
            }

            return result;
        }

        [HttpGet]
        [Route("GetCentroTrabalho")]
        public JsonResult GetCentroTrabalho(int? linha_id)
        {
            CentroTrabalho centro = new CentroTrabalhoServices().GetByLinha(linha_id.Value);
            return Json(centro, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Cadastro")]
        public ActionResult Cadastro(NotaInspecaoViewModel notaInspecaoVM)
        {
            Nota resultNota;
            NotaServices notaService = new NotaServices();

            ViewBag.Action = "Criar";

            if (ModelState.IsValid)
            {
                int id_tp_nota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.MI.ToString()).IdTpNota ?? 0;

                Nota nota = new Nota();
                nota.IdNota = notaInspecaoVM.id_nota;
                nota.IdTpNotaFk = id_tp_nota;
                nota.IdLocalInstFk = notaInspecaoVM.id_local_instalacao_fk;
                nota.IdLocalInstPrincFk = nota.IdLocalInstFk;
                nota.IdCodeSintomaFk = notaInspecaoVM.id_sintoma_fk;
                nota.DsDescricao = notaInspecaoVM.ds_descricao;
                nota.IdPrioridadeFk = notaInspecaoVM.id_prioridade_fk;
                nota.IdNotificadorFk = notaInspecaoVM.id_notificador_fk;
                nota.SgLocal = notaInspecaoVM.sg_local;
                nota.IdLinhaFk = notaInspecaoVM.id_linha_fk;
                nota.IdCentroTrabalhoFk = notaInspecaoVM.id_centro_trabalho_fk.GetValueOrDefault();
                nota.DsObservacao = notaInspecaoVM.ds_observacao;
                nota.StInNotavel = notaInspecaoVM.st_in_notavel;
                nota.StFumaca = notaInspecaoVM.st_fumaca;
                nota.StReboque = notaInspecaoVM.st_reboque;
                nota.DtHoraNota = DateTime.Now;

                //Edição Nota existente
                if (notaInspecaoVM.id_nota > 0)
                {
                    ViewBag.Action = "Editar";
                    resultNota = notaService.EditarMI(nota);

                    if (resultNota.BaseModel.Erro == false)
                    {
                        ViewBag.Mensagem = "Nota atualizada com sucesso.";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Mensagem = "Falha ao atualizar nota.";
                    }
                }
                //Criação nova Nota
                else
                {
                    ViewBag.Action = "Criar";
                    nota.CdNotaSap = GenCodSap();
                    resultNota = notaService.CriarMI(nota);

                    if (resultNota.BaseModel.Erro == false)
                    {
                        ViewBag.Mensagem = String.Concat("Nota cadastrada com sucesso. Cód: ", resultNota.CdNotaSap, " Id: ", resultNota.IdNota);
                        ModelState.Clear();
                        notaInspecaoVM = new NotaInspecaoViewModel();
                    }
                    else
                    {
                        ViewBag.Mensagem = "Falha ao gravar nota.";
                    }
                }
            }

            return View("~/Views/MaterialRodante/NotaInspecao/NotaMi.cshtml", notaInspecaoVM);
        }

        [HttpGet]
        [Route("GetNotasAbertasPendentes")]
        public JsonResult GetAbertasPendentes(int? idFrota, int? idTrem)
        {
            JsonResult result;

            try
            {
                if (idFrota > 0 && idTrem > 0)
                {
                    List<Nota> notas = new NotaServices().GetAbertasPendentes(idFrota.Value, idTrem.Value, TipoNotaSelecionarType.MI.ToString()).ToList();

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
                else
                {
                    result = FormatJson(new String[] { });
                }
            }
            catch (Exception ex)
            {
                result = FormatJson(new String[] { });
            }

            return result;
        }

        [HttpGet]
        [Route("Consultar")]
        public ActionResult Consultar(int? id)
        {
            NotaInspecaoViewModel notaInspecaoVM = new NotaInspecaoViewModel();

            if (id > 0)
            {
                Nota nota = new NotaServices().GetNavigationPropertiesById(id.Value);

                if (nota?.IdNota != null)
                {
                    ViewBag.Action = "Consultar";
                    notaInspecaoVM = ModelToViewModel(nota);
                }
            }

            return View("~/Views/MaterialRodante/NotaInspecao/NotaMi.cshtml", notaInspecaoVM);
        }

        [HttpPost]
        [Route("Cancelar")]
        public JsonResult Cancelar(int? id, string motivo)
        {
            JsonResult result;
            PesquisarNotaMIViewModel pesquisarNotaMIVM = new PesquisarNotaMIViewModel();

            if (id > 0)
            {
                Nota nota = new NotaServices().CancelarMI(id.Value, motivo);
                result = Json(nota, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = Json(String.Empty, JsonRequestBehavior.AllowGet);
            }

            return result;
        }
    }
}