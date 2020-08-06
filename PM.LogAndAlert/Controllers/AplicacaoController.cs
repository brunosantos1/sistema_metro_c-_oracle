using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Service;
using PM.WebServices.Models;
using System.Threading.Tasks;

namespace PM.LogAndAlert.Controllers
{
    [Authorize]
    public class AplicacaoController : Controller
    {
        // GET: Empresa
        [HttpGet]
        public ActionResult Index()
        {
            IList<PM.WebServices.Models.SistemaAplicacao> _retorno = new List<WebServices.Models.SistemaAplicacao>();
            try
            {
                ViewBag.EmpresaId = new SelectList(ComboEmpresa(), "IdEmpresa", "DsDescricao");
                _retorno = (new SistemaAplicacaoServices()).GetAll().OrderBy(c => c.DsDescricao).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(_retorno);
        }

        [HttpPost]
        public ActionResult Index(string EmpresaId, string ProtocoloId)
        {
            IList<PM.WebServices.Models.SistemaAplicacao> _retorno = new List<WebServices.Models.SistemaAplicacao>();
            try
            {
                TempData["EmpresaId"] = new SelectList(ComboEmpresa(), "IdEmpresa", "DsDescricao", EmpresaId);
                TempData["ProtocoloId"] = new SelectList(ComboProtocolo(), "idProtocolo", "DsDescricao", ProtocoloId);
                _retorno = (new SistemaAplicacaoServices()).GetAll().Where(c => c.IdEmpresa.Equals(EmpresaId.ToString())).OrderBy(c => c.DsDescricao).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(_retorno);
        }

        [HttpGet]
        public ActionResult add()
        {
            TempData["EmpresaId"] = new SelectList(ComboEmpresa(), "IdEmpresa", "DsDescricao");
            TempData["ProtocoloId"] = new SelectList(ComboProtocolo(), "idProtocolo", "DsDescricao");
            return View();
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            int ID = id;
            if (ID != 0)
            {
                PM.WebServices.Models.SistemaAplicacao _retorno = new WebServices.Models.SistemaAplicacao();
                _retorno = (new SistemaAplicacaoServices()).GetById(ID);
                if (bool.Parse(_retorno.BaseModel.Erro.ToString()))
                {
                    ModelState.AddModelError("", _retorno.BaseModel.MensagemUsuario.ToString());
                    IList<PM.WebServices.Models.SistemaAplicacao> _ret = new List<WebServices.Models.SistemaAplicacao>();
                    _ret = (new SistemaAplicacaoServices()).GetAll();
                    return RedirectToAction("Index", _ret);
                }
                else
                {
                    TempData["EmpresaId"]   = new SelectList(ComboEmpresa(), "IdEmpresa", "DsDescricao", _retorno.IdEmpresa);
                    TempData["ProtocoloId"] = new SelectList(ComboProtocolo(), "idProtocolo", "DsDescricao", _retorno.DsBancoprotocolo);
                    return View("add", _retorno);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int ID, PM.WebServices.Models.SistemaAplicacao param)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Necessário preencher todos os campos");
                    return View(param);
                }

                if (ID.Equals(0))
                {
                    param.DsDescricao   = param.DsDescricao.ToUpper();
                    param.DtCadastro    = DateTime.Now;
                    param.DsToken       = Guid.NewGuid();
                    var result          = (new SistemaAplicacaoServices()).Add(param);
                    if (result.BaseModel.MensagemException != null)
                    {
                        if ((bool)result.BaseModel.Erro)
                        {
                            ModelState.AddModelError("", string.Format("{0}", ((System.Exception)result.BaseModel.MensagemException).Message.ToString()));
                        }
                        else
                        {
                            ModelState.AddModelError("", string.Format("{0}", result.BaseModel.MensagemUsuario.ToString()));
                        }
                        return View(param);
                    }
                    if (result != null) { return RedirectToAction("Index"); }
                }
                else
                {
                    var _retorno = (new SistemaAplicacaoServices()).GetById(ID);
                    param.IdAplicacao   = ID;
                    param.DsDescricao   = param.DsDescricao.ToUpper();
                    param.DtCadastro    = _retorno.DtCadastro;
                    param.DsToken       = _retorno.DsToken;

                    if ((new SistemaAplicacaoServices()).Update(param))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não foi possível atualizar registro. Tente novamente mais tarde !!!.");
                        return View(param);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                TempData["EmpresaId"] = new SelectList(ComboEmpresa(), "IdEmpresa", "DsDescricao", param.IdEmpresa);
                TempData["ProtocoloId"] = new SelectList(ComboProtocolo(), "idProtocolo", "DsDescricao", param.DsBancoprotocolo);
            }
            return View(param);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                PM.WebServices.Models.SistemaAplicacao _retorno = new WebServices.Models.SistemaAplicacao();
                _retorno = (new SistemaAplicacaoServices()).DeleteById(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public List<SistemaEmpresa> ComboEmpresa()
        {
            List<SistemaEmpresa> lstEmpresa = new List<SistemaEmpresa>();
            SistemaEmpresa oSistemaEmpresa  = new SistemaEmpresa();
            oSistemaEmpresa.IdEmpresa       = 0;
            oSistemaEmpresa.DsDescricao     = "*** SELECIONE UMA EMPRESA ***";
            lstEmpresa.Add(oSistemaEmpresa);
            lstEmpresa.AddRange((new SistemaEmpresaServices()).GetAll());
            return lstEmpresa.ToList();
        }

        [HttpGet]
        public List<Protocolo> ComboProtocolo()
        {
            return Protocolo.GetAll();
        }

        [HttpPost]
        public bool TestarConexao(string ServerIP, string ServerPort, string DbCatalog, string DbUser, string DbPassword, int DbProtocolo)
        {
            bool _retorno = false;
            try
            {
                if (!string.IsNullOrEmpty(ServerIP) || !string.IsNullOrEmpty(ServerPort) || !string.IsNullOrEmpty(DbCatalog) || !string.IsNullOrEmpty(DbUser) || !string.IsNullOrEmpty(DbPassword))
                {
                    string Connection = "";
                    switch (DbProtocolo)
                    {
                        case 1: // Oracle
                            {
                                if (int.Parse(ServerPort.ToString()).Equals(0))
                                {
                                    Connection = string.Format("USER ID={0};PASSWORD={1};DATA SOURCE={2}:{3};", DbUser, DbPassword, ServerIP, ServerPort);
                                }
                                else
                                {
                                    Connection = string.Format("USER ID={0};PASSWORD={1};DATA SOURCE={2};", DbUser, DbPassword, ServerIP);
                                }
                                using (Oracle.ManagedDataAccess.Client.OracleConnection connection = new Oracle.ManagedDataAccess.Client.OracleConnection(Connection))
                                {
                                    try
                                    {
                                        connection.Open();
                                        _retorno = connection.State.Equals(System.Data.ConnectionState.Open);
                                    }
                                    catch (Exception e)
                                    {
                                        throw e;
                                    }
                                }
                                break;
                            }
                        case 2: // MySQL
                            {
                                break;
                            }
                        case 3: // MS SQL Server
                            {
                                break;
                            }
                    }
                    if (_retorno)
                    {
                        TempData["Shared-connection"]       = true; TempData.Keep("Shared-connection");
                        TempData["Shared-saved"]            = true; TempData.Keep("Shared-saved");
                        TempData["Shared-TokenAplication"]  = true; TempData.Keep("Shared-TokenAplication");
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                TempData["EmpresaId"]   = new SelectList(ComboEmpresa(), "IdEmpresa", "DsDescricao"); TempData.Keep("EmpresaId");
                TempData["ProtocoloId"] = new SelectList(ComboProtocolo(), "idProtocolo", "DsDescricao"); TempData.Keep("ProtocoloId");
            }
            return _retorno;
        }

        [HttpGet]
        public ActionResult Implementacao_Codigo(int ID)
        {
            var result = (new SistemaAplicacaoServices()).GetById(ID);
            if(!result.IdAplicacao.Equals(0))
            {
                ViewBag.Token = ID;
            }
            
            return PartialView((new SistemaTipoLogServices()).GetAll().Where(c => c.IdAplicacao.Equals(ID)));
        }

        [HttpGet]
        public JsonResult GetAplicacao(int IdEmpresa)
        {
            JsonResult result;
            try
            {
                IList<SistemaAplicacao> lst = (new SistemaAplicacaoServices()).GetAll().Where(c => c.IdEmpresa.Equals(IdEmpresa)).ToList().OrderBy(c => c.DsDescricao).ToList();

                /*Converter Lista para formato DataTableGrid*/
                if (lst.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = lst.Select(x => new String[] {
                            x.IsAtivo ? x.DsDescricao.ToUpper() : string.Format("<span style='color: red'>{0}</span>", x.DsDescricao.ToUpper()),
                            x.IsAtivo ? x.NmBancohost.ToUpper() : string.Format("<span style='color: red'>{0}</span>", x.NmBancohost.ToUpper()),
                            x.IsAtivo ? x.NmBanconome.ToUpper() : string.Format("<span style='color: red'>{0}</span>", x.NmBanconome.ToUpper()),
                            x.IsAtivo ? Protocolo.GetById(int.Parse(x.DsBancoprotocolo.ToString())).DsDescricao : string.Format("<span style='color: red'>{0}</span>", Protocolo.GetById(int.Parse(x.DsBancoprotocolo.ToString())).DsDescricao),
                            x.IsAtivo ? string.Format("{0:00000}", x.IdTipoLog.Count) : string.Format("<span style='color: red'>{0}</span>", string.Format("{0:00000}", x.IdTipoLog.Count)),
                            x.IsAtivo ? (x.IsAtivo ? "ATIVO": "INATIVO").ToUpper() : string.Format("<span style='color: red'>{0}</span>", (x.IsAtivo ? "ATIVO": "INATIVO")),                            
                            string.Format("<a href='/aplicacao/edit/?id={0}'         data-id='{0}' class=\"btn btn-primary btn-xs\">Editar</a>" +
                                          "<a href='/aplicacao/delete/?id={0}'       data-id='{0}' class=\"btn btn-primary btn-xs\">Excluir</a>" +
                                          "<a href='/AplicacaoTipoLog/index/?id={0}' data-id='{0}' class=\"btn btn-default btn-xs\">Tipo Log</a>" +
                                          "<a href='#myModal' data-toggle='modal' data-target='#modalpopup' class='btn btn-default btn-xs ' data-id='{0}'>Visualizar</a>"
                                          //"<a href=\"#\" class=\"btn btn-primary btn-xs controler_aplicao_implemetacao_codigo\" data-toggle=\"modal\" data-target=\"#modalpopup\"     data-title=\"Codificação\" data-id=\"{0}\">Visualizar</a>"
                                          , x.IdAplicacao)
                        }).ToList();

                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    List<String[]> values = new List<string[]>();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }

    public class Protocolo
    {
        public int IdProtocolo { get; set; }
        public string DsDescricao { get; set; }

        public static List<Protocolo> GetAll()
        {
            List<Protocolo> lst = new List<Protocolo>();
            Protocolo protocolo = new Protocolo();
            protocolo = new Protocolo(); protocolo.IdProtocolo = 0; protocolo.DsDescricao = "*** SELECIONE ***"; lst.Add(protocolo);
            protocolo = new Protocolo(); protocolo.IdProtocolo = 1; protocolo.DsDescricao = "ORACLE"; lst.Add(protocolo);
            protocolo = new Protocolo(); protocolo.IdProtocolo = 2; protocolo.DsDescricao = "MySQL"; lst.Add(protocolo);
            protocolo = new Protocolo(); protocolo.IdProtocolo = 2; protocolo.DsDescricao = "MS SQL Server"; lst.Add(protocolo);
            return lst;
        }

        public static Protocolo GetById(int Id)
        {
            List<Protocolo> lst = new List<Protocolo>();
            Protocolo protocolo = new Protocolo();
            protocolo = new Protocolo(); protocolo.IdProtocolo = 0; protocolo.DsDescricao = "*** SELECIONE ***"; lst.Add(protocolo);
            protocolo = new Protocolo(); protocolo.IdProtocolo = 1; protocolo.DsDescricao = "ORACLE"; lst.Add(protocolo);
            protocolo = new Protocolo(); protocolo.IdProtocolo = 2; protocolo.DsDescricao = "MySQL"; lst.Add(protocolo);
            protocolo = new Protocolo(); protocolo.IdProtocolo = 2; protocolo.DsDescricao = "MS SQL Server"; lst.Add(protocolo);

            protocolo = lst.FirstOrDefault(c => c.IdProtocolo.Equals(Id));
            return protocolo;
        }
    }
}