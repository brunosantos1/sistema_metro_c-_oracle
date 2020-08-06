using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.WebServices.Service;

namespace PM.LogAndAlert.Controllers
{
    [Authorize]
    public class ModuloController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IList<PM.WebServices.Models.SistemaModulo> _retorno = new List<WebServices.Models.SistemaModulo>();
            try
            {
                ViewBag.EmpresaId = new SelectList
                (
                    (new SistemaEmpresaServices()).GetAll(),
                    "IdEmpresa",
                    "DsDescricao"
                );

                _retorno = (new SistemaModuloServices()).GetAll().OrderBy(c => c.DsDescricao).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(_retorno);
        }

        [HttpPost]
        public ActionResult Index(string IdAplicacao)
        {
            IList<PM.WebServices.Models.SistemaModulo> _retorno = new List<WebServices.Models.SistemaModulo>();
            try
            {

                ViewBag.EmpresaId = new SelectList
                (
                    (new SistemaAplicacaoServices()).GetAll(),
                    "IdAplicacao",
                    "DsDescricao",
                    IdAplicacao
                );
                _retorno = (new SistemaModuloServices()).GetAll().Where(c => c.IdAplicacao.Equals(IdAplicacao.ToString())).OrderBy(c => c.DsDescricao).ToList();
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
            return View();
        }

        [HttpPost]
        public ActionResult edit(int id)
        {
            int ID = id;
            if (ID != 0)
            {
                PM.WebServices.Models.SistemaModulo _retorno = new WebServices.Models.SistemaModulo();
                _retorno = (new SistemaModuloServices()).GetById(ID);
                if (bool.Parse(_retorno.BaseModel.Erro.ToString()))
                {
                    ModelState.AddModelError("", _retorno.BaseModel.MensagemUsuario.ToString());
                    IList<PM.WebServices.Models.SistemaModulo> _ret = new List<WebServices.Models.SistemaModulo>();
                    _ret = (new SistemaModuloServices()).GetAll();
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
        public ActionResult Add(int ID, PM.WebServices.Models.SistemaModulo param)
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
                    param.DsDescricao = param.DsDescricao.ToUpper();
                    var result = (new SistemaModuloServices()).Add(param);
                    if (result != null) { return RedirectToAction("Index"); }
                }
                else
                {
                    param.IdAplicacao = ID;
                    param.DsDescricao = param.DsDescricao.ToUpper();

                    if ((new SistemaModuloServices()).Update(param))
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
                PM.WebServices.Models.SistemaModulo _retorno = new WebServices.Models.SistemaModulo();
                _retorno = (new SistemaModuloServices()).DeleteById(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}