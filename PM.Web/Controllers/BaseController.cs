using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Domain.Entities.Enum;

namespace PM.Web.Controllers
{
    [RoutePrefix("Util")]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // If session exists
            if (filterContext.HttpContext.Session != null)
            {
                //if new session
                if (filterContext.HttpContext.Session.IsNewSession)
                {
                    string cookie = filterContext.HttpContext.Request.Headers["Cookie"];
                    //if cookie exists and sessionid index is greater than zero
                    if ((cookie != null) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        //redirect to desired session 
                        //expiration action and controller
                        //filterContext.Result = RedirectToAction("SessionTimeOut", "Usuarios");                      
                        //filterContext.Result = RedirectToAction("Login", "ContaUsuario");
                        RedirectToAction("Login", "ContaUsuario");
                        //return;
                    }
                }
            }
            //otherwise continue with action
            base.OnActionExecuting(filterContext);
        }

        // GET: Alertas
        [HttpGet]
        public JsonResult GetPatioLinha(int ID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            var patiolinha = new PatioLinhaServices().GetByLinhaID(ID).ToList();

            lst.AddRange(patiolinha.Select(d => new SelectListItem { Value = d.IdPatioFk.ToString(), Text = d.Patio.DsPatio.ToUpper(), Selected = (d.IdPatioFk == ID) }).ToList());
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        // GET: Alertas
        [HttpGet]
        public JsonResult GetLinhaPatioTrem(int idLinha = 0, int idPatio = 0, int idTrem = 0)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            var LinhaPatioTrem = new TremServices().GetByLinhaPatioTrem(idLinha, idPatio, idTrem);

            lst.AddRange(LinhaPatioTrem.Select(d => new SelectListItem { Value = d.IdTrem.ToString(), Text = d.NmTrem.ToUpper(), Selected = (d.IdTrem == idTrem) }).ToList());
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        public byte[] UploadFileInDataBase(System.Web.HttpPostedFile file)
        {
            return ConvertToBytes(file);
        }

        public byte[] ConvertToBytes(System.Web.HttpPostedFile file)
        {
            byte[] fileBytes = null;
            BinaryReader reader = new BinaryReader(file.InputStream);
            fileBytes = reader.ReadBytes((int)file.ContentLength);
            return fileBytes;
        }

        /// <summary>
        /// Rotina Generica de carregar dropdownlist
        /// </summary>
        /// 
        internal List<SelectListItem> CarregaDropDownList(object servicoType, int idSelecionado = 0, bool vazio = false)
        {
            List<SelectListItem> retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Value = "0", Text = "*** SELECIONE ***" });

            if (vazio)
                return retorno;

            try
            {
                switch (servicoType)
                {
                    #region --|A|--
                    #endregion

                    #region --|B|--
                    #endregion

                    #region --|C|--
                    case ServicoType.Carro:
                        var carro = new CarroServices().GetAll();
                        retorno.AddRange(carro.Select(d => new SelectListItem { Value = d.IdCarro.ToString(), Text = d.NmCarro.ToUpper(), Selected = (d.IdCarro == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.CentroTrabalho:
                        var centroTrabalhos = new CentroTrabalhoServices().GetAll();
                        retorno.AddRange(centroTrabalhos.Select(d => new SelectListItem { Value = d.IdCtTrabalho.ToString(), Text = d.DsCtTrabalho.ToUpper(), Selected = (d.IdCtTrabalho == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.CimAcionado:
                        var cimacionados = new CentroTrabalhoServices().GetAll();
                        retorno.AddRange(cimacionados.Select(d => new SelectListItem { Value = d.IdCtTrabalho.ToString(), Text = d.DsCtTrabalho, Selected = (d.IdCtTrabalho == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.Code:
                        retorno.Add(new SelectListItem { Value = "1", Text = "Verificar BaseController" });
                        //var codes = new CodeServices().GetAll();
                        //retorno.AddRange(codes.Select(d => new SelectListItem { Value = d.IdCode.ToString(), Text = d.DsBreveCode, Selected = (d.IdCode == idSelecionado) }).ToList());
                        return retorno;

                    //case ServicoType.Complemento:
                    //    retorno.Add(new SelectListItem { Value = "1", Text = "Verificar BaseController" });
                    //    //var codes = new CodeServices().GetAll();
                    //    //retorno.AddRange(codes.Select(d => new SelectListItem { Value = d.IdCode.ToString(), Text = d.DsBreveCode, Selected = (d.IdCode == idSelecionado) }).ToList());
                    //    return retorno;
                    case ServicoType.Complemento:
                        var complemento = new ComplementoServices().GetAll();
                        retorno.AddRange(complemento.Select(d => new SelectListItem { Value = d.IdComplemento.ToString(), Text = d.DsComplemento.ToUpper(), Selected = (d.IdComplemento == idSelecionado) }).ToList());
                        return retorno;
                    #endregion

                    #region --|D|--
                    #endregion

                    #region --|E|--
                    case ServicoType.ElementoPEP:
                        var elementoPEPs = new ElementoPEPServices().GetAll();
                        retorno.AddRange(elementoPEPs.Select(d => new SelectListItem { Value = d.IdElementoPep.ToString(), Text = d.DsElementoPep.ToUpper(), Selected = (d.IdElementoPep == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.Equipamento:
                        var equipamentos = new EquipamentoServices().GetAll();
                        retorno.AddRange(equipamentos.Select(d => new SelectListItem { Value = d.IdEquipamento.ToString(), Text = d.DsEquipamento.ToUpper(), Selected = (d.IdEquipamento == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.EventoGerador:
                        var evento = new EventoGeradorServices().GetAll();
                        retorno.AddRange(evento.Select(d => new SelectListItem { Value = d.IdEventoGerador.ToString(), Text = d.DsEventoGerador.ToUpper(), Selected = (d.IdEventoGerador == idSelecionado) }).ToList());
                        return retorno;
                    #endregion

                    #region --|F|--
                    case ServicoType.Frota:
                        var frota = new FrotaServices().GetAll();
                        retorno.AddRange(frota.Select(d => new SelectListItem { Value = d.IdFrota.ToString(), Text = d.NmFrota.ToUpper(), Selected = (d.IdFrota == idSelecionado) }).ToList());
                        return retorno;

                    #endregion

                    #region --|G|--
                    case ServicoType.GrupoTrabalho:
                        retorno.Add(new SelectListItem { Value = "1", Text = "Verificar BaseController".ToUpper() });
                        //var equipamentos = new EquipamentoServices().GetAll();
                        //retorno.AddRange(equipamentos.Select(d => new SelectListItem { Value = d.IdEquipamento.ToString(), Text = d.DsEquipamento, Selected = (d.IdEquipamento == idSelecionado) }).ToList());
                        return retorno;
                    #endregion

                    #region --|H|--
                    #endregion

                    #region --|I|--
                    #endregion

                    #region --|J|--
                    #endregion

                #region --|L|--
                //case ServicoType.Linha:
                //    retorno.Add(new SelectListItem { Value = "1", Text = "Verificar BaseController" });
                //    //var tipoNota = new TipoNotaServices().GetAll();
                //    //retorno.AddRange(tipoNota.Select(d => new SelectListItem { Value = d.IdTpNota.ToString(), Text = d.DsTpNota, Selected = (d.IdTpNota == idSelecionado) }).ToList());
                //    return retorno;
                case ServicoType.Linha:
                    var linha = new LinhaServices().GetAll();
                    retorno.AddRange(linha.Select(d => new SelectListItem { Value = d.IdLinha.ToString(), Text = d.NmLinha.ToUpper(), Selected = (d.IdLinha == idSelecionado) }).ToList());
                    return retorno;
                case ServicoType.LocalInstalacao:
                    var localInstalacao = new LocalInstalacaoServices().GetAll();
                    retorno.AddRange(localInstalacao.Select(d => new SelectListItem { Value = d.IdLcInstalacao.ToString(), Text = d.DsLcInstalacao, Selected = (d.IdLcInstalacao == idSelecionado) }).ToList());
                    return retorno;
                #endregion

                    #region --|M|--
                    case ServicoType.Material:
                        var materiais = new MaterialServices().GetAll();
                        retorno.AddRange(materiais.Select(d => new SelectListItem { Value = d.IdMaterial.ToString(), Text = d.DsMaterial.ToUpper(), Selected = (d.IdMaterial == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.MotivoEntrega:
                        retorno = new List<SelectListItem>();
                        retorno.Add(new SelectListItem { Value = "0", Text = "TODOS" });
                        var motivoentrega = new MotivoEntregaServices().GetAll();
                        retorno.AddRange(motivoentrega.Select(d => new SelectListItem { Value = d.IdMotivoEntrega.ToString(), Text = d.DsMotivoEntrega.ToUpper(), Selected = (d.IdMotivoEntrega == idSelecionado) }).ToList());
                        return retorno;
                    #endregion

                    #region --|P|--
                    case ServicoType.Prioridade:
                        var prioridades = new PrioridadeServices().GetAll();
                        retorno.AddRange(prioridades.Select(d => new SelectListItem { Value = d.IdPrioridade.ToString(), Text = d.DsPrioridade.ToUpper(), Selected = (d.IdPrioridade == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.PatioLinha:
                        var patiolinha = new PatioLinhaServices().GetAll();
                        retorno.AddRange(patiolinha.Select(d => new SelectListItem { Value = d.IdPatioFk.ToString(), Text = d.Patio.DsPatio.ToUpper(), Selected = (d.IdPatioFk == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.Patio:
                        var patio = new PatioServices().GetAll();
                        retorno.AddRange(patio.Select(d => new SelectListItem { Value = d.IdPatio.ToString(), Text = d.DsPatio.ToUpper(), Selected = (d.IdPatio == idSelecionado) }).ToList());
                        return retorno;
                    case ServicoType.Posicao:
                        var posicao = new PosicaoServices().GetAll();
                        retorno.AddRange(posicao.Select(d => new SelectListItem { Value = d.IdPosicao.ToString(), Text = d.DsPosicao.ToUpper(), Selected = (d.IdPosicao == idSelecionado) }).ToList());
                        return retorno;
                    #endregion

                    #region --|S|--
                    case ServicoType.Sintoma:
                        var sintoma = new SintomaServices().GetAll();
                        retorno.AddRange(sintoma.Select(d => new SelectListItem { Value = d.IdCode.ToString(), Text = d.DsCode.ToUpper(), Selected = (d.IdCode == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.Sistema:
                        var sistema = new SistemaServices().GetAll();
                        retorno.AddRange(sistema.Select(d => new SelectListItem { Value = d.IdSistema.ToString(), Text = d.NmSistema.ToUpper(), Selected = (d.IdSistema == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.StatusUsuario:
                        var statusUsuarios = new StatusUsuarioServices().GetAll();
                        retorno.AddRange(statusUsuarios.Select(d => new SelectListItem { Value = d.IdStUsuario.ToString(), Text = d.DsStUsuario.ToUpper(), Selected = (d.IdStUsuario == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.Status:
                        var statusTrem = new StatusTremServices().GetAll();
                        retorno.AddRange(statusTrem.Select(d => new SelectListItem { Value = d.IdStTrem.ToString(), Text = d.DsStTrem.ToUpper(), Selected = (d.IdStTrem == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.StatusLiberacaoTrem:
                        var statusLiberacaoTrem = new StatusTremServices().GetAll().Where(c => c.IdStTrem.Equals(1) || c.IdStTrem.Equals(2)).OrderBy(c => c.DsStTrem).ToList();
                        retorno.AddRange(statusLiberacaoTrem.Select(d => new SelectListItem { Value = d.IdStTrem.ToString(), Text = d.DsStTrem.ToUpper(), Selected = (d.IdStTrem == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.StatusPericia:
                        var situacaoPericia = new StatusPericiaServices().GetAll();
                        retorno.AddRange(situacaoPericia.Select(d => new SelectListItem { Value = d.IdStPericia.ToString(), Text = d.DsStPericia.ToUpper(), Selected = (d.IdStPericia == idSelecionado) }).ToList());
                        return retorno;

                    case ServicoType.StatusCopese:
                        var statusCopese = new StatusCopeseServices().GetAll();
                        retorno.AddRange(statusCopese.Select(d => new SelectListItem { Value = d.IdStCopese.ToString(), Text = d.DsStCopese.ToUpper(), Selected = (d.IdStCopese == idSelecionado) }).ToList());
                        return retorno;
                    case ServicoType.StatusProgramacaoTrem:
                        retorno = new List<SelectListItem>();
                        retorno.Add(new SelectListItem { Value = "0", Text = "*** SELECIONE FIXO ***" });
                        retorno.Add(new SelectListItem { Value = "1", Text = "SOLICITADA" });
                        retorno.Add(new SelectListItem { Value = "2", Text = "PROGRAMADA" });
                        retorno.Add(new SelectListItem { Value = "3", Text = "REJEITADA" });
                        retorno.Add(new SelectListItem { Value = "4", Text = "CANCELADA" });
                        retorno.Add(new SelectListItem { Value = "5", Text = "ENTREGUE" });
                        //var statusCopese = new StatusCopeseServices().GetAll();
                        //retorno.AddRange(statusCopese.Select(d => new SelectListItem { Value = d.IdStCopese.ToString(), Text = d.DsStCopese.ToUpper(), Selected = (d.IdStCopese == idSelecionado) }).ToList());
                        return retorno;


                    #endregion

                    #region --|T|--
                    case ServicoType.TipoNota:
                        var tipoNota = new TipoNotaServices().GetAll();
                        retorno.AddRange(tipoNota.Select(d => new SelectListItem { Value = d.IdTpNota.ToString(), Text = d.DsTpNota.ToUpper(), Selected = (d.IdTpNota == idSelecionado) }).ToList());
                        return retorno;

                case ServicoType.Trem:
                    var trem = new TremServices().GetAll();
                    retorno.AddRange(trem.Select(d => new SelectListItem { Value = d.IdTrem.ToString(), Text = d.NmTrem.ToUpper(), Selected = (d.IdTrem == idSelecionado) }).ToList());
                    return retorno;

                case ServicoType.TipoManutencao:
                    //var tipomanutencao = new TremServices().GetAll();
                    //retorno.AddRange(trem.Select(d => new SelectListItem { Value = d.IdTrem.ToString(), Text = d.NmTrem.ToUpper(), Selected = (d.IdTrem == idSelecionado) }).ToList());
                    return retorno;
                case ServicoType.TipoProgramacao:
                    retorno = new List<SelectListItem>();
                    retorno.Add(new SelectListItem { Value = "0", Text = "*** SELECIONE ***" });
                    retorno.Add(new SelectListItem { Value = "1", Text = "Programar Notas MP" });
                    retorno.Add(new SelectListItem { Value = "2", Text = "Programar Notas MD/MS" });
                    return retorno;
                #endregion

                    #region --|Z|--
                    case ServicoType.Zona:
                        var zona = new ZonaServices().GetAll();
                        retorno.AddRange(zona.Select(d => new SelectListItem { Value = d.IdZona.ToString(), Text = d.NmZona.ToUpper(), Selected = (d.IdZona == idSelecionado) }).ToList());
                        return retorno;
                    #endregion

                    default:
                        throw new Exception("Erro ao criar DropDownlist. Verificar se tem o tratamento.");
                }
            }
            catch (Exception)
            {
                return retorno;
            }
        }

        /// <summary>
        /// Busca Centro de Trabalho para sugerir digitacao
        /// </summary>
        /// 
        [Route("BuscarLinha")]
        public JsonResult BuscarLinha(int id_linha)
        {
            Linha linha = new Linha();
            linha = new LinhaServices().GetById(id_linha);
            return Json(linha, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca Nota de Referencia para sugerir digitacao
        /// </summary>
        /// 
        [Route("BuscarNotaRef")]
        public JsonResult BuscarNotaRef(string nr_nota_sap)
        {
            Nota nota = new Nota();

            if (!string.IsNullOrEmpty(nr_nota_sap))
            {
                nota = new NotaServices().GetNotasCodigoSap(nr_nota_sap);
            }

            return Json(nota, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca a Elemento PEP pelo ID
        /// </summary>
        /// 
        [Route("BuscarElementoPEP")]
        public JsonResult BuscarElementoPEP(int id_elemento_pep)
        {
            ElementoPEP elementoPEP = new ElementoPEP();
            //elementoPEP = new ElementoPEPServices().GetById(id_elemento_pep);

            return Json(elementoPEP, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca a Equipamento pelo ID
        /// </summary>
        /// 
        [Route("BuscarEquipamento")]
        public JsonResult BuscarEquipamento(int id_equipamento)
        {
            Equipamento equipamento = new Equipamento();
            //equipamento = new EquipamentoServices().GetById(id_equipamento);

            return Json(equipamento, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca a Equipamento pelo ID
        /// </summary>
        /// 
        [Route("BuscarCentroTrabalho")]
        public JsonResult BuscarCentroTrabalho(string sigla)
        {
            CentroTrabalho centroTrabalho = new CentroTrabalho();
            //centroTrabalho = new CentroTrabalhoServices().GetBySigla(sigla);

            return Json(centroTrabalho, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca a Material pelo ID
        /// </summary>
        /// 
        [Route("BuscarMaterial")]
        public JsonResult BuscarMaterial(int id_material)
        {
            Material material = new Material();
            //material = new MaterialServices().GetById(id_material);

            return Json(material, JsonRequestBehavior.AllowGet);
        }

        /// <summary>   
        /// AutoComplete dos campos da nota fiscal
        /// </summary>
        /// 
        [Route("AutoCompleteDescricaoNota")]
        public JsonResult AutoCompleteDescricaoNota(string term)
        {
            Nota nota = new Nota();
            //nota = new NotaServices().AutoCompleteDescricao(term);

            return Json(nota, JsonRequestBehavior.AllowGet);
        }

        [Route("GetTrem")]
        public JsonResult GetTrem(int id_frota)
        {
            List<Trem> trens = new List<Trem>();
            Trem selecionarTrem = new Trem
            {
                IdTrem = 0,
                NmTrem = "*** SELECIONE ***"
            };
            trens.Add(selecionarTrem);
            trens.AddRange(new TremServices().GetByFrota(id_frota).ToList());
            return Json(trens.Select(d => new SelectListItem { Value = d.IdTrem.ToString(), Text = d.NmTrem }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("GetCarro")]
        public JsonResult GetCarro(int id_trem)
        {
            List<Carro> carros = new List<Carro>();
            Carro selecionarCarro = new Carro
            {
                IdCarro = 0,
                NmCarro = "*** SELECIONE ***"
            };
            carros.Add(selecionarCarro);
            carros.AddRange(new CarroServices().GetByTrem(id_trem).ToList());
            return Json(carros.Select(d => new SelectListItem { Value = d.IdCarro.ToString(), Text = d.NmCarro }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [Route("GetSistema")]
        public JsonResult GetSistema(int id_frota)
        {
            List<Sistema> trens = new List<Sistema>();
            Sistema selecionarTrem = new Sistema
            {
                IdSistema = 0,
                NmSistema = "*** SELECIONE ***"
            };
            trens.Add(selecionarTrem);
            trens.AddRange(new SistemaServices().GetByFrota(id_frota).ToList());
            return Json(trens.Select(d => new SelectListItem { Value = d.IdSistema.ToString(), Text = d.NmSistema }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("SelecionarEmpregado")]
        public ActionResult SelecionarEmpregado()
        {
            return View("~/Views/Shared/SelecionarEmpregado.cshtml");
        }

        [HttpPost]
        [Route("GetEmpregados/{nome_rg?}")]
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

                    result = formatJson(values);
                }
                else
                {
                    result = formatJson(new List<String[]>());
                }
            }
            else
            {
                result = formatJson(new List<String[]>());
            }

            return result;
        }

        private JsonResult formatJson(Object values)
        {
            var _values = new { data = values };
            return Json(_values, JsonRequestBehavior.AllowGet);
        }

        [Route("GetFrota")]
        public JsonResult GetFrota()
        {
            List<Frota> frota = new List<Frota>();
            Frota selecionarFrota = new Frota
            {
                IdFrota = 0,
                NmFrota = "*** SELECIONE ***"
            };
            frota.Add(selecionarFrota);
            frota.AddRange(new FrotaServices().GetAll().ToList());
            return Json(frota.Select(d => new SelectListItem { Value = d.IdFrota.ToString(), Text = d.NmFrota }).ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Alertas
        [Route("GetLinhaPatioTrem")]
        public JsonResult GetLinhaPatioTrem(int idLinha = 0, int idPatio = 0, int idTrem = 0, int? idStatusTrem = 0)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            List<Trem> LinhaPatioTrem = new List<Trem>();
            if (idStatusTrem.Equals(0))
            {
                LinhaPatioTrem = new TremServices().GetByLinhaPatioTrem(idLinha, idPatio, idTrem).ToList();
            }
            else
            {
                if (idStatusTrem == 1 || idStatusTrem == 2)
                {
                    LinhaPatioTrem = new TremServices().GetByLinhaPatioTrem(idLinha, idPatio, idTrem).ToList().Where(c => c.StTrem.Equals(1) || c.StTrem.Equals(2)).ToList();
                }
                else
                {
                    LinhaPatioTrem = new TremServices().GetByLinhaPatioTrem(idLinha, idPatio, idTrem).ToList().Where(c => c.StTrem.Equals(3) || c.StTrem.Equals(4)).ToList();
                }
            }

            lst.AddRange(LinhaPatioTrem.Select(d => new SelectListItem { Value = d.IdTrem.ToString(), Text = d.NmTrem.ToUpper(), Selected = (d.IdTrem == idTrem) }).ToList());
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        // GET: Alertas
        [Route("GetLinhaPatioTrem")]
        public JsonResult GetLocalInstalacaoFromTrem(int idTrem = 0, int? idLocalInstalacao = 0)
        {
            List<SelectListItem> lstResposta = new List<SelectListItem>();
            List<LocalInstalacao> lstDados = new List<LocalInstalacao>();

            lstDados = new LocalInstalacaoServices().GetAll().ToList().Where(c => c.IdTremFk.Equals(idTrem)).ToList();

            lstResposta.AddRange(lstDados.Select(d => new SelectListItem { Value = d.IdLcInstalacao.ToString(), Text = d.DsLcInstalacao.ToUpper(), Selected = (d.IdTremFk == idTrem) }).ToList());
            return Json(lstResposta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>   
        /// AutoComplete
        /// </summary>
        /// 
        [Route("AutoComplete")]
        public JsonResult AutoComplete(string campo, string term)
        {
            switch (campo)
            {
                //case "ds_descricao_nota": return Json(new NotaServices().AutoComplete(campo, term), JsonRequestBehavior.AllowGet);
                //case "cd_sap_equipamento": return Json(new EquipamentoServices().AutoComplete(campo, term), JsonRequestBehavior.AllowGet);
                //case "cd_sap_elementoPEP": return Json(new ElementoPEPServices().AutoComplete(campo, term), JsonRequestBehavior.AllowGet);
                //case "cd_sap_material": return Json(new MaterialServices().AutoComplete(campo, term), JsonRequestBehavior.AllowGet);
                //case "ct_trabalho": return Json(new CentroTrabalhoServices().AutoComplete(campo, term), JsonRequestBehavior.AllowGet);

                case "DsObservacao": return Json(new ProgramacaoServices().AutoComplete(campo, term), JsonRequestBehavior.AllowGet);
                default: return null;
            }
        }

    }
}