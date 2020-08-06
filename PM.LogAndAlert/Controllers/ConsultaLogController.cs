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
    public class ConsultaLogController : Controller
    {
        // GET: ConsultaLog
        public ActionResult Index()
        {

            SistemaEmpresa oSistemaEmpresa = new SistemaEmpresa();
            oSistemaEmpresa.IdEmpresa = 0;
            oSistemaEmpresa.IsAtivo = true;
            oSistemaEmpresa.DsDescricao = "*** SELECIONE ***";
            List<SistemaEmpresa> lst = new List<SistemaEmpresa>();
            lst.Add(oSistemaEmpresa);
            lst.AddRange((new SistemaEmpresaServices()).GetAll());
            ViewBag.Empresa = new SelectList(lst.OrderBy(c => c.DsDescricao), "IdEmpresa", "DsDescricao");

            var selectList = new SelectList(
            new List<SelectListItem> { new SelectListItem {Text = "", Value = "*** SELECIONE UMA EMPRESA ***"} }, "Value", "Text");
            ViewBag.Aplicacao = selectList;
            return View();
        }

        [HttpGet]
        public JsonResult GetAcessos(int IdEmpresa, int IdAplicacao, int IdUsuario, int IdModulo, bool isInativo, string DataInicio, string DataTermino)
        {
            JsonResult result;
            try
            {
                IList<SistemaLogLogin> lst = (new SistemaLogLoginServices()).GetAll();
                lst = lst.Where(c => (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) >= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataInicio.ToString()))))
                                  && (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) <= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataTermino.ToString()))))
                                ).ToList();

                
                /*Converter Lista para formato DataTableGrid*/
                if (lst.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = lst.Select(x => new String[] {
                              x.DtOcorrencia.ToString()
                            , x.DsIpaddress.ToString()
                            , x.NmMachine.ToString()
                            , x.NmLogonUserIdentityName.ToString()
                            , string.Format("{0} v.{1}", x.NmBrowserName.ToString(), x.NmBrowserVersion.ToString())
                            , x.NmPlatforma.ToString()
                            , string.Format("{0}", x.IsWin16 ? "16bits" : "32bits")
                            , x.DsUrlFull.ToString()
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

        [HttpGet]
        public JsonResult GetCRUD(int IdEmpresa, int IdAplicacao, int IdUsuario, int IdModulo, bool isInativo, string DataInicio, string DataTermino)
        {
            JsonResult result;
            try
            {
                IList<SistemaLogOperacoes> lst = (new SistemaLogOperacoesServices()).GetAll().ToList();
                lst = lst.Where(c => (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) >= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataInicio.ToString()))))
                                  && (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) <= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataTermino.ToString()))))
                                ).ToList();
                
                /*Converter Lista para formato DataTableGrid*/
                if (lst.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = lst.Select(x => new String[] {
                              x.DtOcorrencia.ToString()
                            , x.DsIpaddress.ToString()
                            , x.NmMachine.ToString()
                            , x.NmLogonUserIdentityName.ToString()
                            , (new SistemaTipoLogServices()).GetById( x.IdTipoLogFk).DsDescricao.ToString() // x.IdTipoLogFk.ToString()
                            , x.NmController.ToString()
                            , x.NmAction.ToString()
                            , x.DsUrlFull.ToString()                            
                            , string.Format("<a href=\"#\" class=\"btn btn-primary btn-xs .consulta-modal\" data-toggle=\"modal\" data-target=\"#consulta-modal\" data-title=\"CRUD\" data-url=\"/ConsultaLog/getcrudbyid/\" data-idempresa=\"{0}\" data-idaplicacao=\"{1}\" data-id=\"{2}\">Visualizar</a>", IdEmpresa, IdAplicacao, x.IdLogOperacoes)
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
        
        [HttpGet]
        public JsonResult GetAlertas(int IdEmpresa, int IdAplicacao, int IdUsuario, int IdModulo, bool isInativo, string DataInicio, string DataTermino)
        {
            JsonResult result;
            try
            {
                IList<SistemaLogLogin> lst = (new SistemaLogLoginServices()).GetAll().ToList();
                lst = lst.Where(c => (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) >= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataInicio.ToString()))))
                                  && (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) <= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataTermino.ToString()))))
                                ).ToList();

                /*Converter Lista para formato DataTableGrid*/
                if (lst.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = lst.Select(x => new String[] {
                              x.DtOcorrencia.ToString()
                            , x.DtOcorrencia.ToString()
                            , "Equipamento Fixo"
                            , "Minha Querida Descricao - fixo em GetAlertas()"
                            , x.NmLogonUserIdentityName.ToString()
                            , x.NmLogonUserIdentityName.ToString()
                            , string.Format("<a href=\"#\" class=\"btn btn-primary btn-xs .consulta-modal\" data-toggle=\"modal\" data-target=\"#consulta-modal\" data-title=\"Alertas\" data-url=\"/ConsultaLog/getalertasbyid/\" data-idempresa=\"{0}\" data-idaplicacao=\"{1}\" data-id=\"{2}\">Visualizar</a>", IdEmpresa, IdAplicacao, x.IdLogLogin)
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

        [HttpGet]
        public JsonResult GetErro(int IdEmpresa, int IdAplicacao, int IdUsuario, int IdModulo, bool isInativo, string DataInicio, string DataTermino)
        {
            JsonResult result;
            try
            {
                IList<SistemaLogError> lst = (new SistemaLogErrorServices()).GetAll().ToList();
                lst = lst.Where(c => (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) >= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataInicio.ToString()))))
                                  && (DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", c.DtOcorrencia)) <= DateTime.Parse(string.Format("{0:yyyy/MM/dd 00:00:00}", DateTime.Parse(DataTermino.ToString()))))
                                ).ToList();
                /*Converter Lista para formato DataTableGrid*/
                if (lst.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = lst.Select(x => new String[] {
                              x.DtOcorrencia.ToString()
                            , string.Format("{0:00000}", x.IdLogError)
                            , x.DsIpaddress.ToString()
                            , x.NmMachine.ToString()
                            , x.NmLogonUserIdentityName.ToString()
                            , x.NmController.ToString()
                            , x.NmAction.ToString()
                            , x.DsTypeError.ToString()
                            , x.DsUrlFull.ToString()
                            , string.Format("<a href=\"#\" class=\"btn btn-primary btn-xs .consulta-modal\" data-toggle=\"modal\" data-target=\"#consulta-modal\" data-title=\"Error\" data-url=\"/ConsultaLog/geterrobyid/\" data-idempresa=\"{0}\" data-idaplicacao=\"{1}\" data-id=\"{2}\">Visualizar</a>", IdEmpresa, IdAplicacao, x.IdLogError)
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

        [HttpGet]
        public ActionResult GetAcessosByID(int IDEmpresa, int IDAplicacao, int ID, string Title)
        {
            ViewBag.Title = Title;
            ViewBag.Empresa = (new SistemaEmpresaServices()).GetById(IDEmpresa).DsDescricao;
            ViewBag.Aplicacao = (new SistemaAplicacaoServices()).GetById(IDAplicacao).DsDescricao;
            ViewBag.Valor = string.Format("Valor Recebido é [{0}]", ID);
            return View();
        }

        [HttpGet]
        public ActionResult GetCRUDByID(int IDEmpresa, int IDAplicacao, int ID, string Title)
        {
            ViewBag.Title = Title;
            ViewBag.Empresa = (new SistemaEmpresaServices()).GetById(IDEmpresa).DsDescricao;
            ViewBag.Aplicacao = (new SistemaAplicacaoServices()).GetById(IDAplicacao).DsDescricao;

            return View((new SistemaLogOperacoesServices()).GetById(ID));
        }

        [HttpGet]
        public ActionResult GetAlertasByID(int IdEmpresa, int IdAplicacao, int Id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetErroByID(int IDEmpresa, int IDAplicacao, int ID, string Title)
        {
            ViewBag.Title       = Title;
            ViewBag.Empresa     = (new SistemaEmpresaServices()).GetById(IDEmpresa).DsDescricao;
            ViewBag.Aplicacao   = (new SistemaAplicacaoServices()).GetById(IDAplicacao).DsDescricao;
            
            return View((new SistemaLogErrorServices()).GetById(ID));
        }
    }
}