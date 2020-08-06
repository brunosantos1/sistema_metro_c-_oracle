using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Service;

namespace PM.LogAndAlert.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        
        // GET: Empresa
        [HttpGet]
        public ActionResult Index()
        {
            IList<PM.WebServices.Models.SistemaEmpresa> _retorno = new List<WebServices.Models.SistemaEmpresa>();
            try
            {   
                _retorno = (new SistemaEmpresaServices()).GetAll().OrderBy(c => c.DsDescricao).ToList();                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(_retorno);
        }

        [HttpGet]
        public ActionResult add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult edit(int id)
        {
            int ID = ((id == null) ? 0 : int.Parse(id.ToString()));
            if (ID != 0)
            {
                PM.WebServices.Models.SistemaEmpresa _retorno = new WebServices.Models.SistemaEmpresa();
                _retorno = (new SistemaEmpresaServices()).GetById(ID);
                if (bool.Parse(_retorno.BaseModel.Erro.ToString()))
                {
                    ModelState.AddModelError("", _retorno.BaseModel.MensagemUsuario.ToString());
                    IList<PM.WebServices.Models.SistemaEmpresa> _ret = new List<WebServices.Models.SistemaEmpresa>();
                    _ret = (new SistemaEmpresaServices()).GetAll();
                    return RedirectToAction("Index", _ret);
                }
                else
                {   
                    return View("add", _retorno);
                }
            }
            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Add(int ID, PM.WebServices.Models.SistemaEmpresa param)
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
                    param.DsDescricao= param.DsDescricao.ToUpper();
                    param.DtCadastro= DateTime.Now;
                    var result          = (new SistemaEmpresaServices()).Add(param);
                    if(result != null) { return RedirectToAction("Index"); }                    
                }
                else
                {
                    param.IdEmpresa     = ID;
                    param.DsDescricao   = param.DsDescricao.ToUpper();

                    if ((new SistemaEmpresaServices()).Update(param))
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
            return View(param);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                PM.WebServices.Models.SistemaEmpresa _retorno = new WebServices.Models.SistemaEmpresa();
                _retorno = (new SistemaEmpresaServices()).DeleteById(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}