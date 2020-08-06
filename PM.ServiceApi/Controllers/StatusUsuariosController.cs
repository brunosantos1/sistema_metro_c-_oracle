using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusUsuarios")]
    public class StatusUsuariosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult GetById(int id)
        {
            StatusUsuario result = new StatusUsuarioService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByCdSap")]
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult GetByCdSap(string cd)
        {
            StatusUsuario result = new StatusUsuarioService().GetByCdSap(cd);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusUsuario>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusUsuarioService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult Add(StatusUsuario obj)
        {
            var result = new StatusUsuarioService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult Update(StatusUsuario obj)
        {
            var result = new StatusUsuarioService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusUsuario))]
        public IHttpActionResult Delete(StatusUsuario catalogo)
        {
            var result = new StatusUsuarioService().Delete(catalogo);
            if (result == null)
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

