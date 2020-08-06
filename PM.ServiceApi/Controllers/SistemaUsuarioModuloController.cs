using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaUsuarioModulo")]
    public class SistemaUsuarioModuloController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaUsuarioModulo))]
        public IHttpActionResult GetById(int id)
        {
            SistemaUsuarioModulo result = new SistemaUsuarioModuloService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaUsuarioModulo>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaUsuarioModuloService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaUsuarioModulo))]
        public IHttpActionResult Add(SistemaUsuarioModulo obj)
        {
            var result = new SistemaUsuarioModuloService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaUsuarioModulo obj)
        {
            var result = new SistemaUsuarioModuloService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaUsuarioModulo))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaUsuarioModuloService().DeleteById(id);
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