using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusTrem")]
    public class StatusTremController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusTrem))]
        public IHttpActionResult GetById(int id)
        {
            StatusTrem result = new StatusTremService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        
        [Route("GetAll")]
        [ResponseType(typeof(List<StatusTrem>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusTremService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(StatusTrem))]
        public IHttpActionResult Add(StatusTrem obj)
        {
            var result = new StatusTremService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusTrem))]
        public IHttpActionResult Update(StatusTrem obj)
        {
            var result = new StatusTremService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusTrem))]
        public IHttpActionResult Delete(StatusTrem obj)
        {
            var result = new StatusTremService().Delete(obj);
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

