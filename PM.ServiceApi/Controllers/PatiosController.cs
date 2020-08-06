using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Patios")]
    public class PatiosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Patio))]
        public IHttpActionResult GetById(int id)
        {
            Patio result = new PatioService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Patio>))]
        public IHttpActionResult GetAll()
        {
            var result = new PatioService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Patio))]
        public IHttpActionResult Add(Patio obj)
        {
            var result = new PatioService().Add_Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Patio))]
        public IHttpActionResult Update(Patio obj)
        {
            var result = new PatioService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Patio))]
        public IHttpActionResult Delete(Patio patio)
        {
            var result = new PatioService().Delete(patio);
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

