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
    public class AplicacaoTipoLogController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SistemaEmpresa oSistemaEmpresa = new SistemaEmpresa();
            oSistemaEmpresa.IdEmpresa = 0;
            //oSistemaEmpresa.IdAplicacao.Add(new SistemaAplicacao());
            oSistemaEmpresa.IsAtivo = true;
            oSistemaEmpresa.DsDescricao = "*** SELECIONE ***";
            List<SistemaEmpresa> lst = new List<SistemaEmpresa>();
            lst.Add(oSistemaEmpresa);
            lst.AddRange((new SistemaEmpresaServices()).GetAll());
            ViewBag.Empresa   = new SelectList(lst.OrderBy(c => c.DsDescricao), "IdEmpresa", "DsDescricao");
            ViewBag.Aplicacao = new SelectList((new SistemaAplicacaoServices()).GetAll().Where(c => c.IdAplicacao.Equals(0)), "IdAplicacao", "DsDescricao");
            IList<PM.WebServices.Models.SistemaTipoLog> _retorno = new List<WebServices.Models.SistemaTipoLog>();            
            return View(_retorno);
        }

        [HttpGet]
        public JsonResult GetAplicacao(int ID)
        {
            IList<SistemaAplicacao> lst= (new SistemaAplicacaoServices()).GetAll().Where(c => c.IdEmpresa.Equals(ID)).ToList().OrderBy(c => c.DsDescricao).ToList();            
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTipoLog(int IdAplicacao)
        {
            JsonResult result;            
            try
            {   
                IList<SistemaTipoLog> lst = (new SistemaTipoLogServices()).GetAll().Where(c => c.IdAplicacao.Equals(IdAplicacao)).ToList().OrderBy(c => c.DsDescricao).ToList();

                /*Converter Lista para formato DataTableGrid*/
                if (lst.Count > 0)
                {
                    //Conversão de ViewModel para Json compatível com o plugin dataTable
                    List<String[]> values = lst.Select(x => new String[] {
                            x.IsAtivo ? x.DsDescricao.ToUpper() : string.Format("<span style='color: red'>{0}</span>", x.DsDescricao.ToUpper()),
                            x.IsAtivo ? (x.IsAtivo ? "ATIVO": "INATIVO").ToUpper() : string.Format("<span style='color: red'>{0}</span>", (x.IsAtivo ? "ATIVO": "INATIVO")),
                            string.Format("<a href='/aplicacaotipolog/edit/?id={0}' data-id='{0}' class=\"btn btn-primary btn-xs\">Editar</a>" +
                                          "<a href='/aplicacaotipolog/Delete/?id={0}' data-id='{0}' class=\"btn btn-default btn-xs\">Excluir</a>"
                                          , x.IdTipoLog)
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
            catch(Exception ex)
            {
                throw ex;
            }
            return result;
        }
        
        [HttpGet]
        public ActionResult add()
        {
            ViewBag.Empresa = new SelectList((new SistemaEmpresaServices()).GetAll(), "IdEmpresa", "DsDescricao");
            ViewBag.Aplicacao = new SelectList((new SistemaAplicacaoServices()).GetAll().Where(c => c.IdAplicacao.Equals(0)), "IdAplicacao", "DsDescricao");
            return View("add");
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            int ID = id;
            if (ID != 0)
            {
                PM.WebServices.Models.SistemaTipoLog _retorno = new WebServices.Models.SistemaTipoLog();
                _retorno = (new SistemaTipoLogServices()).GetById(ID);
                if (bool.Parse(_retorno.BaseModel.Erro.ToString()))
                {
                    ModelState.AddModelError("", _retorno.BaseModel.MensagemUsuario.ToString());
                    IList<PM.WebServices.Models.SistemaTipoLog> _ret = new List<WebServices.Models.SistemaTipoLog>();
                    _ret = (new SistemaTipoLogServices()).GetAll();
                    return RedirectToAction("Index", _ret);
                }
                else
                {
                    var aplicacao = (new SistemaAplicacaoServices()).GetById(_retorno.IdAplicacao);
                    //ViewBag.Empresa = new SelectList((new SistemaEmpresaServices()).GetAll(), "IdEmpresa", "DsDescricao", (new SistemaAplicacaoServices()).GetById(_retorno.IdAplicacao).IdEmpresa);
                    ViewBag.Empresa = new SelectList((new SistemaEmpresaServices()).GetAll().Where(c => c.IdEmpresa.Equals(aplicacao.IdEmpresa)) , "IdEmpresa", "DsDescricao", aplicacao.IdEmpresa);
                    ViewBag.Aplicacao = new SelectList((new SistemaAplicacaoServices()).GetAll().Where(c => c.IdAplicacao.Equals(_retorno.IdAplicacao)), "IdAplicacao", "DsDescricao", _retorno.IdAplicacao);
                    return View("add", _retorno);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int ID, PM.WebServices.Models.SistemaTipoLog param)
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
                    if(!(new SistemaTipoLogServices()).GetAll().Where(c => c.DsDescricao.ToUpper().Equals(param.DsDescricao.ToUpper())).Count().Equals(0))
                    {
                        ModelState.AddModelError("", string.Format("O registro [{0}], já existe na base de dados. Impossível concluir operação", param.DsDescricao.ToString()));
                        return View(param);
                    }
                    param.DsDescricao  = param.DsDescricao.ToUpper();
                    param.DtOcorrencia = DateTime.Now;

                    var result = (new SistemaTipoLogServices()).Add(param);
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
                    var _retorno = (new SistemaTipoLogServices()).GetById(ID);
                    param.IdTipoLog     = ID;
                    param.IdAplicacao   = _retorno.IdAplicacao;
                    param.DtOcorrencia  = _retorno.DtOcorrencia;
                    param.DsDescricao   = param.DsDescricao.ToUpper();
                    ViewBag.Aplicacao = new SelectList((new SistemaAplicacaoServices()).GetAll().Where(c => c.IdAplicacao.Equals(_retorno.IdAplicacao)), "IdAplicacao", "DsDescricao");
                    if ((new SistemaTipoLogServices()).Update(param))
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
                ViewBag.Empresa = new SelectList((new SistemaEmpresaServices()).GetAll(), "IdEmpresa", "DsDescricao", (new SistemaAplicacaoServices()).GetById(param.IdAplicacao).IdEmpresa);
                ViewBag.Aplicacao = new SelectList((new SistemaAplicacaoServices()).GetAll().Where(c => c.IdAplicacao.Equals(0)), "IdAplicacao", "DsDescricao", param.IdAplicacao);
            }
            return View(param);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                PM.WebServices.Models.SistemaAplicacao _retorno = new WebServices.Models.SistemaAplicacao();

                // Validar de existe log com este id, se existir nao deve permitir exclusão do registro

                _retorno = (new SistemaAplicacaoServices()).DeleteById(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}