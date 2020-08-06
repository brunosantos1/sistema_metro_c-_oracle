using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using PM.LogAndAlert.Models;
using System.Threading.Tasks;

namespace PM.LogAndAlert.Controllers
{
    public class PerfilAcessoController : Controller
    {
        private static SistemaPerfil _sistemaperfil = new SistemaPerfil();
        // GET: PerfilAcesso
        public ActionResult Index()
        {
            return View(GeraDados().ToList());
        }
        [HttpGet]

        public ActionResult Perfil()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Perfil(int id)
        {   
            return View();
        }

        public ActionResult Copiar(int ID)
        {


            ViewBag.Valor = string.Format("Selecione o perfil a ser copiado para o perfil [{0}]", ID);
            return PartialView();
        }

        public ActionResult Usuario(int ID)
        {
            ViewBag.Valor = string.Format("O Notificador é  [{0}]", ID);
            return PartialView();
        }

        private List<SistemaPerfil> GeraDados()
        {
            List<SistemaPerfil> _retorno = new List<SistemaPerfil>();
            SistemaPerfil oSistemaPerfil = new SistemaPerfil();
            oSistemaPerfil.id_perfil = _retorno.ToList().Count.Equals(0) ? 1 : _retorno.ToList().Count() + 1; oSistemaPerfil.ds_descricao = "Administrador"; oSistemaPerfil.num_Usuarios = 176; oSistemaPerfil.num_Usuarios_logados = 17; _retorno.Add(oSistemaPerfil); oSistemaPerfil = new SistemaPerfil();
            oSistemaPerfil.id_perfil = _retorno.ToList().Count.Equals(0) ? 1 : _retorno.ToList().Count() + 1; oSistemaPerfil.ds_descricao = "operacional"; oSistemaPerfil.num_Usuarios = 3076; oSistemaPerfil.num_Usuarios_logados = 57; _retorno.Add(oSistemaPerfil); oSistemaPerfil = new SistemaPerfil();
            oSistemaPerfil.id_perfil = _retorno.ToList().Count.Equals(0) ? 1 : _retorno.ToList().Count() + 1; oSistemaPerfil.ds_descricao = "Gerente"; oSistemaPerfil.num_Usuarios = 5076; oSistemaPerfil.num_Usuarios_logados = 79; _retorno.Add(oSistemaPerfil); oSistemaPerfil = new SistemaPerfil();
            oSistemaPerfil.id_perfil = _retorno.ToList().Count.Equals(0) ? 1 : _retorno.ToList().Count() + 1; oSistemaPerfil.ds_descricao = "Surpervisor"; oSistemaPerfil.num_Usuarios = 3076; oSistemaPerfil.num_Usuarios_logados = 57; _retorno.Add(oSistemaPerfil); oSistemaPerfil = new SistemaPerfil();


            return _retorno;
        }

        public ActionResult getPerfil()
        {
            return Json(GeraDados().ToList().Select(x => new
            {
                id_perfil = x.id_perfil,
                ds_descricao = x.ds_descricao.ToUpper()
            }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}