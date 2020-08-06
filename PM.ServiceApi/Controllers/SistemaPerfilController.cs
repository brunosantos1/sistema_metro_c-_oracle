using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaPerfil")]
    public class SistemaPerfilController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaPerfil))]
        public IHttpActionResult GetById(int id)
        {
            SistemaPerfil result = new SistemaPerfilService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaPerfil>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaPerfilService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaPerfil))]
        public IHttpActionResult Add(SistemaPerfil obj)
        {
            var result = new SistemaPerfilService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaPerfil obj)
        {
            var result = new SistemaPerfilService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaPerfil))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaPerfilService().DeleteById(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}