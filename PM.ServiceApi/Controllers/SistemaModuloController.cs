using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaModulo")]
    public class SistemaModuloController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaModulo))]
        public IHttpActionResult GetById(int id)
        {
            SistemaModulo result = new SistemaModuloService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaModulo>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaModuloService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaModulo))]
        public IHttpActionResult Add(SistemaModulo obj)
        {
            var result = new SistemaModuloService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaModulo obj)
        {
            var result = new SistemaModuloService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaModulo))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaModuloService().DeleteById(id);
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