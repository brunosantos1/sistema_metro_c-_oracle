using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Marcos")]
    public class MarcosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Marco))]
        public IHttpActionResult GetById(int id)
        {
            Marco result = new MarcoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Marco>))]
        public IHttpActionResult GetAll()
        {
            var result = new MarcoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Marco))]
        public IHttpActionResult Add(Marco obj)
        {
            var result = new MarcoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Marco))]
        public IHttpActionResult Update(Marco obj)
        {
            var result = new MarcoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Marco))]
        public IHttpActionResult Delete(Marco marcos)
        {
            var result = new MarcoService().Delete(marcos);
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

