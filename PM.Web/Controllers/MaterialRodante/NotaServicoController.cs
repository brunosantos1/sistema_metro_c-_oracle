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
    [RoutePrefix("MR/NotaServico")]
    public class NotaServicoController : Controller
    {
        // GET: NotaServico
        [HttpGet]
        [Route("Cadastro/{id?}")]
        public ActionResult Cadastro(int? id, string acao = null)
        {
            NotaMsViewModel telaVM = new NotaMsViewModel();

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
                telaVM.id_sistema_fk = nota.LocalInstalacao.IdSistemaFk;
                telaVM.id_complemento_fk = nota.LocalInstalacao.IdComplementoFk;
                telaVM.id_posicao_fk = nota.LocalInstalacao.IdPosicaoFk;
                telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
                telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;
                telaVM.id_code_tp_servico_fk = nota.IdCodeTpServicoFk;
                telaVM.ds_descricao = nota.DsDescricao;
                telaVM.id_solicitante_fk = nota.IdSolicitanteFk;
                telaVM.nm_solicitante = nota.Solicitante.NmFuncionario + " " + nota.Solicitante.SbFuncionario;
                telaVM.id_linha_fk = nota.IdLinhaFk;
                telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
                if (nota.DtHoraProgramada != null)
                {
                    telaVM.dt_programada = nota.DtHoraProgramada.GetValueOrDefault().ToString("dd/MM/yyyy");
                    telaVM.hr_programada = nota.DtHoraProgramada.GetValueOrDefault().ToString("hh:mm");
                    telaVM.dt_hora_programada = nota.DtHoraProgramada.GetValueOrDefault().ToString("dd/MM/yyyy hh:mm");
                }
                else
                {
                    telaVM.dt_programada = "";
                    telaVM.hr_programada = "";
                    telaVM.dt_hora_programada = "";
                }
                telaVM.ds_observacao = nota.DsObservacao;

            }
            else
            {
                ViewBag.Action = "Criar";
            }


            return View("~/Views/MaterialRodante/NotaServico/NotaMs.cshtml", telaVM);
        }

        [HttpGet]
        [Route("Consultar/{id}")]
        public ActionResult Consultar(int id)
        {
            //return View();
            NotaMsViewModel telaVM = new NotaMsViewModel();
            NotaServices notaServices = new NotaServices();
            Nota nota = new Nota();
            nota = notaServices.GetNavigationPropertiesById(id);
            ViewBag.Action = "Consultar";

            telaVM.id_frota_fk = nota.LocalInstalacao.IdFrotaFk;
            telaVM.id_trem_fk = nota.LocalInstalacao.IdTremFk;
            telaVM.id_carro_fk = nota.LocalInstalacao.IdCarroFk;
            telaVM.id_sistema_fk = nota.LocalInstalacao.IdSistemaFk;
            telaVM.id_complemento_fk = nota.LocalInstalacao.IdComplementoFk;
            telaVM.id_posicao_fk = nota.LocalInstalacao.IdPosicaoFk;
            telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
            telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;
            telaVM.id_code_tp_servico_fk = nota.IdCodeTpServicoFk;
            telaVM.ds_descricao = nota.DsDescricao;
            telaVM.id_solicitante_fk = nota.IdSolicitanteFk;
            telaVM.nm_solicitante = nota.Solicitante.NmFuncionario + " " + nota.Solicitante.SbFuncionario;
            telaVM.id_linha_fk = nota.IdLinhaFk;
            telaVM.id_centro_trabalho_fk = nota.IdCentroTrabalhoFk;
            if (nota.DtHoraProgramada != null)
            {
                telaVM.dt_programada = nota.DtHoraProgramada.GetValueOrDefault().ToString("dd/MM/yyyy");
                telaVM.hr_programada = nota.DtHoraProgramada.GetValueOrDefault().ToString("hh:mm");
                telaVM.dt_hora_programada = nota.DtHoraProgramada.GetValueOrDefault().ToString("dd/MM/yyyy hh:mm");
            }
            else
            {
                telaVM.dt_programada = "";
                telaVM.hr_programada = "";
                telaVM.dt_hora_programada = "";
            }
            telaVM.ds_observacao = nota.DsObservacao;


            return View("~/Views/MaterialRodante/NotaServico/NotaMs.cshtml", telaVM);
        }

        [HttpPost]
        [Route("Cadastro/{id?}")]
        public ActionResult Cadastro(NotaMsViewModel telaVM)
        {
            bool success = false;
            Nota resultNota;
            NotaMsViewModel clearTelaVM = null;

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



                nota.IdNota = telaVM.id_nota;
                //nota.IdTpNotaFk = tipoNota.IdTpNota.GetValueOrDefault(); // 21; // Setar o tipo de nota mc de material rodante
                nota.IdLocalInstFk = telaVM.id_local_instalacao_fk.GetValueOrDefault();
                nota.IdCodeTpServicoFk = telaVM.id_code_tp_servico_fk;
                nota.DsDescricao = telaVM.ds_descricao;
                nota.IdSolicitanteFk = telaVM.id_solicitante_fk;
                nota.IdLinhaFk = telaVM.id_linha_fk;
                nota.IdCentroTrabalhoFk = telaVM.id_centro_trabalho_fk.GetValueOrDefault();
                nota.DsObservacao = telaVM.ds_observacao;
                nota.DtHoraProgramada = DateTime.Parse(telaVM.dt_hora_programada);

                nota.DtHoraNota = DateTime.Now;


                if (telaVM.id_nota > 0)
                {
                    resultNota = notaService.EditarMS(nota);
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

                    resultNota = notaService.CriarMS(nota);
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
                        telaVM.id_code_tp_servico_fk = 0;
                        telaVM.ds_descricao = "";
                        telaVM.id_solicitante_fk = 0;
                        telaVM.id_linha_fk = 0;

                        //telaVM.rg_notificador = "";
                        telaVM.id_solicitante_fk = null;
                        telaVM.nm_solicitante = "";
                        telaVM.id_centro_trabalho_fk = 0;

                        telaVM.ds_observacao = "";

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
            return View("~/Views/MaterialRodante/NotaServico/NotaMs.cshtml", telaVM);
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
        [Route("GetComplementosBySistema")]
        public JsonResult GetComplementosBySistema(int idSistema)
        {
            List<Complemento> complementos = new ComplementoServices().GetBySistema(idSistema).ToList();
            return Json(complementos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetPosicoesByComplemento")]
        public JsonResult GetPosicoesByComplemento(int idComplemento)
        {
            List<Posicao> posicoes = new PosicaoServices().GetByComplemento(idComplemento).ToList();
            return Json(posicoes, JsonRequestBehavior.AllowGet);
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
        [Route("GetTipoServico")]
        public JsonResult GetTipoServico()
        {
            List<Code> tipos = new CodeServices().GetTipoServico().ToList();
            return Json(tipos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LocalInstalacao")]
        public JsonResult LocalInstalacao(int? idFrota, int? idTrem, int? idCarro)
        {
            List<LocalInstalacao> localInstalacao = new LocalInstalacaoServices().Search(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault()).ToList();
            return Json(localInstalacao, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("LocalInstalacaoMS")]
        public JsonResult LocalInstalacaoMS(int idFrota, int idTrem, int idCarro, int idSistema, int? idComplemento = null, int? idPosicao = null)
        {
            List<LocalInstalacao> localInstalacao = new LocalInstalacaoServices().SearchMS(idFrota, idTrem, idCarro, idSistema, idComplemento, idPosicao).ToList();
            return Json(localInstalacao, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("GetAbertasPendentes")]
        public JsonResult GetAbertasPendentes(int idFrota, int idTrem)
        {
            JsonResult result;
            try
            {
                List<object> notasVM = new List<object>();
                List<Nota> notas = new NotaServices().GetAbertasPendentes(idFrota, idTrem, "MS").ToList();
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
                            x.CodeTpServico?.DsCode?.ToString()??"",
                            x.DtHoraNota?.ToString()??"",
                            x.DtHoraProgramada?.ToString()??"",
                            x.Solicitante?.NmFuncionario?.ToString()??"",
                            x.CentroTrabalho?.DsCtTrabalho?.ToString()??"",
                            string.Join(",",x.StatusUsuarios?.Select(y=>y.DsStUsuario)??new List<string>()),
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