using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaUsuario")]
    public class SistemaUsuarioController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaUsuario))]
        public IHttpActionResult GetById(int id)
        {
            SistemaUsuario result = new SistemaUsuarioService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaUsuario>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaUsuarioService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaUsuario))]
        public IHttpActionResult Add(SistemaUsuario obj)
        {
            var result = new SistemaUsuarioService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaUsuario obj)
        {
            var result = new SistemaUsuarioService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaUsuario))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaUsuarioService().DeleteById(id);
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