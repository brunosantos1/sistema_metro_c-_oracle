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
    /* Controller relativa a tela de Pesquisa de Nota Corretiva (Nota MC) de Material Rodante */
    [RoutePrefix("MR/PesquisarNotaMC")]
    public class PesquisarNotaMCController : Controller
    {

        [HttpGet]
        [Route("Pesquisar")]
        public ActionResult Pesquisar()
        {
            List<Frota> frotas = new FrotaServices().GetAll().ToList();
            List<SelectListItem> frotaSelect = new List<SelectListItem>();

            frotaSelect.Add(new SelectListItem { Text = "", Value = "" });
            foreach (Frota frota in frotas)
            {
                frotaSelect.Add(new SelectListItem { Text = frota.NmFrota, Value = frota.IdFrota.ToString() });
            }
            PesquisarNotaMCViewModel telaVM = new PesquisarNotaMCViewModel();
            telaVM.FrotaList = frotaSelect;
            return View("~/Views/MaterialRodante/NotaCorretiva/PesquisarMC.cshtml", telaVM);
        }

        /*[HttpGet]
        [Route("GetData")]
        public JsonResult GetData(int? idFrota=null,int? idTrem=null,int? idCarro=null,int? idSistema=null,int? idSintoma=null,string cdSap=null, DateTime? dataInicial=null, DateTime? dataFinal=null,int? idPrioridade=null,int? idNotificador=null, int? rgNotificador = null, int ? idStatus=null)
        {
            
            List<Nota> notas = new NotaServices().PesquisarMC(idFrota, idTrem, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus).ToList();
            return Json(notas, JsonRequestBehavior.AllowGet);
        }*/

        // GET: NotaCorretiva
        [HttpGet]
        [Route("Cadastro/{id?}")]
        public ActionResult Cadastro(int? id)
        {
            //return View();
            NotaMRCorretivaViewModel telaVM = new NotaMRCorretivaViewModel();

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
                telaVM.id_sistema_fk = nota.CodeSintoma.IdGrCodeFk;

                telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
                telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;

                telaVM.id_sintoma_fk = nota.IdCodeSintomaFk;
                telaVM.ds_descricao = nota.DsDescricao;
                telaVM.id_prioridade_fk = nota.IdPrioridadeFk;
                //telaVM.rg_notificador = nota.RgNotificador;
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
            telaVM.id_sistema_fk = nota.CodeSintoma.IdGrCodeFk;

            telaVM.id_local_instalacao_fk = nota.IdLocalInstFk;
            telaVM.ds_local_instalacao = nota.LocalInstalacao.DsLcInstalacao;

            telaVM.id_sintoma_fk = nota.IdCodeSintomaFk;
            telaVM.ds_descricao = nota.DsDescricao;
            telaVM.id_prioridade_fk = nota.IdPrioridadeFk;
            //telaVM.rg_notificador = nota.RgNotificador;
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
        [Route("GetByFrotaTremCarro")]
        public JsonResult GetByFrotaTremCarro(int idFrota, int idTrem, int idCarro)
        {
            object result = new NotaServices().GetByFrotaTremCarro(idFrota, idTrem, idCarro);
            string string1 = result.ToString();
            object newobj = new JavaScriptSerializer().Deserialize<object>(string1);
            return Json(newobj, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("Cancelar")]
        public JsonResult Cancelar(int id, string motivo)
        {
            Nota nota = new NotaServices().CancelarMC(id, motivo);
            return Json(nota, JsonRequestBehavior.AllowGet);
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
            return Json(prioridade, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetData(int? idFrota = null, int? idTrem = null, int? idCarro = null, int? idSistema = null, int? idSintoma = null, string cdSap = null, string dataInicial = null, string dataFinal = null, int? idPrioridade = null, int? idNotificador = null, int? rgNotificador = null, int? idStatus = null)
        {



            JsonResult result;
            try
            {

                //List<Nota> notas = new NotaServices().GetAbertasPendentes(idFrota,idTrem).ToList();
                List<Nota> notas = new NotaServices().PesquisarMC(idFrota, idTrem, idCarro, idSistema, idSintoma, cdSap, dataInicial, dataFinal, idPrioridade, idNotificador, rgNotificador, idStatus).ToList();
                if (notas != null)
                {
                    if (notas.Count > 0)
                    {
                        //string joined = string.Join(",", list.Select(x => x.Id));
                        List<String[]> values = notas.Select(x => new String[] {
                            x.IdNota.ToString(),
                            x.CdNotaSap,
                            x.TipoNota?.DsTpNota??"",
                            x.LocalInstalacao?.DsLcInstalacao??"",
                            x.DsDescricao??"",
                            x.CodeSintoma?.DsCode??"",
                            x.Prioridade?.DsPrioridade??"",
                            x.DtHoraNota?.ToString("dd/MM/yyyy") ?? "",
                            x.DtHoraNota?.ToString("hh:mm") ?? "",
                            x.Empregado?.NmFuncionario + " " + x.Empregado?.SbFuncionario,
                            string.Join(", ",x.StatusUsuarios?.Select(y=>y.DsStUsuario)),
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