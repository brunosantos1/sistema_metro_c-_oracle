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
    [RoutePrefix("MR/NotaCorretiva")]
    public class NotaCorretivaController : Controller
    {
        // GET: NotaCorretiva
        [HttpGet]
        [Route("Cadastro/{id?}")]
        public ActionResult Cadastro(int? id, string acao = null)
        {




            NotaMRCorretivaViewModel telaVM;
            if (acao != null && acao == "carregarUltima")
            {
                Nota nota = new NotaServices().CarregarUltima("MC");


                //return View();
                telaVM = new NotaMRCorretivaViewModel();

                ViewBag.Action = "Criar";

                telaVM.id_nota = null;
                telaVM.id_frota_fk = nota.LocalInstalacao.IdFrotaFk;
                telaVM.id_trem_fk = nota.LocalInstalacao.IdTremFk;
                telaVM.id_carro_fk = nota.LocalInstalacao.IdCarroFk;
                telaVM.id_sistema_fk = nota.CodeSintoma?.IdGrCodeFk;

                telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
                telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;

                telaVM.id_sintoma_fk = nota.IdCodeSintomaFk;
                telaVM.ds_descricao = nota.DsDescricao;
                telaVM.id_prioridade_fk = nota.IdPrioridadeFk;

                //telaVM.rg_notificador = nota.RgNotificador;
                telaVM.id_notificador_fk = nota.IdNotificadorFk;
                telaVM.nm_notificador = nota.Empregado.NmFuncionario + " " + nota.Empregado.SbFuncionario;


                //telaVM.id_linha_fk = nota.linha
                telaVM.sg_local = nota.SgLocal;
                telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
                telaVM.ds_centro_trabalho = nota.CentroTrabalho.DsCtTrabalho;

                telaVM.ds_observacao = nota.DsObservacao;
                telaVM.st_if_oper_maior_cinco_min = nota.StIfOperMaiorCincoMin ?? false;
                telaVM.st_in_notavel = nota.StInNotavel ?? false;
                telaVM.st_fumaca = nota.StFumaca ?? false;
                telaVM.st_reboque = nota.StReboque ?? false;
                return View("~/Views/MaterialRodante/NotaCorretiva/NotaMc.cshtml", telaVM);
            }


            //return View();
            telaVM = new NotaMRCorretivaViewModel();

            if (id != null && id > 0)
            {
                ViewBag.Action = "Editar";




                NotaServices notaServices = new NotaServices();
                Nota nota = new Nota();
                nota = notaServices.GetNavigationPropertiesById(id ?? 0);

                telaVM.id_nota = nota.IdNota.GetValueOrDefault();
                telaVM.id_frota_fk = nota.LocalInstalacao.IdFrotaFk;
                telaVM.id_trem_fk = nota.LocalInstalacao.IdTremFk;
                telaVM.id_carro_fk = nota.LocalInstalacao.IdCarroFk;
                telaVM.id_sistema_fk = nota.CodeSintoma?.IdGrCodeFk;

                telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
                telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;

                telaVM.id_sintoma_fk = nota.IdCodeSintomaFk;
                telaVM.ds_descricao = nota.DsDescricao;
                telaVM.id_prioridade_fk = nota.IdPrioridadeFk;

                //telaVM.rg_notificador = nota.RgNotificador;
                telaVM.id_notificador_fk = nota.IdNotificadorFk;
                telaVM.nm_notificador = nota.Empregado.NmFuncionario + " " + nota.Empregado.SbFuncionario;

                //telaVM.id_linha_fk = nota.linha
                telaVM.sg_local = nota.SgLocal;
                telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
                telaVM.ds_centro_trabalho = nota.CentroTrabalho.DsCtTrabalho;

                telaVM.ds_observacao = nota.DsObservacao;
                telaVM.st_if_oper_maior_cinco_min = nota.StIfOperMaiorCincoMin ?? false;
                telaVM.st_in_notavel = nota.StInNotavel ?? false;
                telaVM.st_fumaca = nota.StFumaca ?? false;
                telaVM.st_reboque = nota.StReboque ?? false;


            }
            else
            {
                ViewBag.Action = "Criar";
            }

            return View("~/Views/MaterialRodante/NotaCorretiva/NotaMc.cshtml", telaVM);
        }





        [HttpGet]
        [Route("Consultar/{id}")]
        public ActionResult Consultar(int id)
        {
            //return View();
            NotaMRCorretivaViewModel telaVM = new NotaMRCorretivaViewModel();
            NotaServices notaServices = new NotaServices();
            Nota nota = new Nota();
            nota = notaServices.GetNavigationPropertiesById(id);
            ViewBag.Action = "Consultar";

            telaVM.id_frota_fk = nota.LocalInstalacao.IdFrotaFk;
            telaVM.id_trem_fk = nota.LocalInstalacao.IdTremFk;
            telaVM.id_carro_fk = nota.LocalInstalacao.IdCarroFk;
            telaVM.id_sistema_fk = nota.CodeSintoma?.IdGrCodeFk;

            telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
            telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;

            telaVM.id_sintoma_fk = nota.IdCodeSintomaFk;
            telaVM.ds_descricao = nota.DsDescricao;
            telaVM.id_prioridade_fk = nota.IdPrioridadeFk;

            //telaVM.rg_notificador = nota.RgNotificador;
            telaVM.id_notificador_fk = nota.IdNotificadorFk;
            telaVM.nm_notificador = nota.Empregado.NmFuncionario + " " + nota.Empregado.SbFuncionario;

            //telaVM.id_linha_fk = nota.linha
            telaVM.sg_local = nota.SgLocal;
            telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
            telaVM.ds_centro_trabalho = nota.CentroTrabalho.DsCtTrabalho;

            telaVM.ds_observacao = nota.DsObservacao;
            telaVM.st_if_oper_maior_cinco_min = nota.StIfOperMaiorCincoMin ?? false;
            telaVM.st_in_notavel = nota.StInNotavel ?? false;
            telaVM.st_fumaca = nota.StFumaca ?? false;
            telaVM.st_reboque = nota.StReboque ?? false;


            return View("~/Views/MaterialRodante/NotaCorretiva/NotaMc.cshtml", telaVM);
        }

        [HttpGet]
        [Route("Pesquisar")]
        public ActionResult Pesquisar()
        {
            return View();
        }
        [HttpGet]
        [Route("GetByFrotaTremCarro")]
        public JsonResult GetByFrotaTremCarro(int idFrota, int idTrem, int idCarro)
        {
            object result = new NotaServices().GetByFrotaTremCarro(idFrota, idTrem, idCarro);
            string string1 = result.ToString();
            object newobj = new JavaScriptSerializer().Deserialize<object>(string1);
            return Json(newobj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Frotas")]
        public JsonResult Frotas()
        {
            List<Frota> frotas = new FrotaServices().GetAll().ToList();
            return Json(frotas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Trens")]
        public JsonResult Trens(int id)
        {
            List<Trem> trens = new TremServices().GetByFrota(id).ToList();
            return Json(trens, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Carros")]
        public JsonResult Carros(int id)
        {
            List<Carro> carros = new CarroServices().GetByTrem(id).ToList();
            return Json(carros, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Sistemas")]
        public JsonResult Sistemas(int id)
        {
            List<Sistema> sistemas = new SistemaServices().GetByFrota(id).ToList();
            return Json(sistemas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetSistemas")]
        public JsonResult GetSistemas(int idPerfil)
        {
            List<GrupoCode> grupos = new SistemaServices().GetSistemas(idPerfil).ToList();
            return Json(grupos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetSintomas")]
        public JsonResult GetSintomas(int idSistema)
        {
            List<Code> codes = new SistemaServices().GetSintomas(idSistema).ToList();
            return Json(codes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetPrioridades")]
        public JsonResult GetPrioridades()
        {
            List<Prioridade> prioridades = new PrioridadeServices().GetAll().ToList();
            return Json(prioridades, JsonRequestBehavior.AllowGet);
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
        [Route("PrioridadeBySintoma")]
        public JsonResult PrioridadeBySintoma(int idSintoma)
        {
            Prioridade prioridade = new PrioridadeServices().GetBySintoma(idSintoma);
            List<Prioridade> prioridadesList = new List<Prioridade>();
            if (prioridade != null)
            {

                prioridadesList.Add(prioridade);
            }

            return Json(prioridadesList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LocalInstalacao")]
        public JsonResult LocalInstalacao(int? idFrota, int? idTrem, int? idCarro)
        {
            List<LocalInstalacao> localInstalacao = new LocalInstalacaoServices().Search(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault()).ToList();
            return Json(localInstalacao, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Cadastro/{id?}")]
        public ActionResult Cadastro(NotaMRCorretivaViewModel telaVM)
        {
            bool success = false;
            Nota resultNota;
            NotaMRCorretivaViewModel clearTelaVM = null;

            if (telaVM.id_nota != null && telaVM.id_nota > 0)
            {
                ViewBag.Action = "Editar";
            }
            else
            {
                ViewBag.Action = "Criar";
            }

            NotaServices notaService = new NotaServices();
            if (ModelState.IsValid)
            {
                Nota nota = new Nota();

                TipoNotaServices tpnotaServices = new TipoNotaServices();
                TipoNota tipoNota = tpnotaServices.GetByCodigoSap("MC");

                nota.IdNota = telaVM.id_nota;
                //nota.IdTpNotaFk = tipoNota.IdTpNota.GetValueOrDefault(); // 21; // Setar o tipo de nota mc de material rodante
                nota.IdLocalInstFk = telaVM.id_local_instalacao_fk.GetValueOrDefault();

                nota.SgLocal = telaVM.sg_local;


                //nota.IdLocalInstPrincFk = nota.IdLocalInstFk;
                nota.IdCodeSintomaFk = telaVM.id_sintoma_fk;
                nota.DsDescricao = telaVM.ds_descricao;
                nota.IdPrioridadeFk = telaVM.id_prioridade_fk;

                //nota.RgNotificador = telaVM.rg_notificador;
                nota.IdNotificadorFk = telaVM.id_notificador_fk;

                nota.IdCentroTrabalhoFk = telaVM.id_centro_trabalho_fk.GetValueOrDefault();
                nota.DsObservacao = telaVM.ds_observacao;
                nota.DtHoraNota = DateTime.Now;



                //checks

                nota.StIfOperMaiorCincoMin = telaVM.st_if_oper_maior_cinco_min;
                nota.StInNotavel = telaVM.st_in_notavel;
                nota.StFumaca = telaVM.st_fumaca;
                nota.StReboque = telaVM.st_reboque;


                if (telaVM.id_nota > 0)
                {
                    resultNota = notaService.EditarMC(nota);
                    if (resultNota.BaseModel.Erro == false)
                    {
                        ViewBag.Resultado = "sucesso";
                        ViewBag.ExibirMensagem = "sim";
                        ViewBag.MensagemResultado = resultNota.BaseModel.MensagemUsuario;
                    }
                    else
                    {
                        ViewBag.Resultado = "falha";
                    }
                }
                else
                {
                    // Código SAP fake provisório, quando for adicionado integração com sap alterar esta linha
                    DateTime nx = new DateTime(1970, 1, 1); // UNIX epoch date
                    TimeSpan ts = DateTime.UtcNow - nx; // UtcNow, because timestamp is in GMT
                    String timeStamp1 = ((int)ts.TotalSeconds).ToString();
                    nota.CdNotaSap = "sp" + timeStamp1;

                    resultNota = notaService.CriarMC(nota);
                    if (resultNota.BaseModel.Erro == false)
                    {

                        success = true;
                        //medidaNota.Motivo
                        telaVM.id_nota = null;
                        //telaVM.id_trem_fk = telaVM.id_trem_fk;
                        //telaVM.id_frota_fk = telaVM.id_frota_fk;
                        telaVM.id_carro_fk = null;
                        telaVM.id_sistema_fk = null;
                        telaVM.id_local_instalacao_fk = null;
                        telaVM.ds_local_instalacao = "";
                        telaVM.id_sintoma_fk = 0;
                        telaVM.ds_descricao = "";
                        telaVM.id_prioridade_fk = 0;
                        telaVM.id_linha_fk = 0;
                        telaVM.sg_local = "";
                        //telaVM.rg_notificador = "";
                        telaVM.id_notificador_fk = null;
                        telaVM.nm_notificador = "";
                        telaVM.id_centro_trabalho_fk = 0;
                        telaVM.ds_centro_trabalho = "";
                        telaVM.ds_observacao = "";
                        telaVM.st_if_oper_maior_cinco_min = false;
                        telaVM.st_in_notavel = false;
                        telaVM.st_fumaca = false;
                        telaVM.st_reboque = false;


                        ViewBag.Resultado = "sucesso";
                        ViewBag.ExibirMensagem = "sim";
                        ViewBag.MensagemResultado = resultNota.BaseModel.MensagemUsuario;
                    }
                    else
                    {
                        ViewBag.Resultado = "falha";
                    }
                }
            }
            else
            {
                success = false;
                clearTelaVM = null;
            }

            if (success == true)
            {
                ModelState.Clear();
            }
            return View("~/Views/MaterialRodante/NotaCorretiva/NotaMc.cshtml", telaVM);
        }





        [HttpGet]
        [Route("GetAbertasPendentes")]
        public JsonResult GetAbertasPendentes(int idFrota, int idTrem)
        {
            JsonResult result;
            try
            {
                List<object> notasVM = new List<object>();
                List<Nota> notas = new NotaServices().GetAbertasPendentes(idFrota, idTrem, "MC").ToList();
                if (notas != null)
                {
                    if (notas.Count > 0)
                    {
                        //string joined = string.Join(",", list.Select(x => x.Id));
                        List<String[]> values = notas.Select(x => new String[] {
                            x.IdNota?.ToString()??"",
                            x.CdNotaSap??"",
                            x.TipoNota?.DsTpNota??"",
                            x.LocalInstalacao?.DsLcInstalacao?.ToString()??"",
                            x.DsDescricao??"",
                            x.CodeSintoma?.DsCode?.ToString()??"",
                            x.Prioridade?.DsPrioridade?.ToString()??"",
                            x.DtHoraNota?.ToString("dd/MM/yyyy")??"",
                            x.DtHoraNota?.ToString("hh:mm")??"",
                            x.Empregado?.NmFuncionario?.ToString()??"",
                            string.Join(",",x.StatusUsuarios?.Select(y=>y.DsStUsuario)),
                            ""
                        }).ToList();

                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var _values = new { data = new String[] { } };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var _values = new { data = new String[] { } };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                var _values = new { data = new String[] { } };
                result = Json(_values, JsonRequestBehavior.AllowGet);
            }
            return result;
        }

    }


}