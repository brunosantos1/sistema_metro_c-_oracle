using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CodigosABC")]
    public class CodigosABCController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CodigoABC))]
        public IHttpActionResult GetById(int id)
        {
            CodigoABC result = new CodigoABCService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CodigoABC>))]
        public IHttpActionResult GetAll()
        {
            var result = new CodigoABCService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(CodigoABC))]
        public IHttpActionResult Add(CodigoABC obj)
        {
            var result = new CodigoABCService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CodigoABC))]
        public IHttpActionResult Update(CodigoABC obj)
        {
            var result = new CodigoABCService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CodigoABC))]
        public IHttpActionResult Delete(CodigoABC catalogo)
        {
            var result = new CodigoABCService().Delete(catalogo);
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

