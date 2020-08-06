using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusEntregaTrem")]
    public class StatusEntregaTremController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusEntregaTrem))]
        public IHttpActionResult GetById(int id)
        {
            StatusEntregaTrem result = new StatusEntregaTremService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("GetAll")]
        [ResponseType(typeof(List<StatusEntregaTrem>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusEntregaTremService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(StatusEntregaTrem))]
        public IHttpActionResult Add(StatusEntregaTrem obj)
        {
            var result = new StatusEntregaTremService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusEntregaTrem))]
        public IHttpActionResult Update(StatusEntregaTrem obj)
        {
            var result = new StatusEntregaTremService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusEntregaTrem))]
        public IHttpActionResult Delete(StatusEntregaTrem obj)
        {
            var result = new StatusEntregaTremService().Delete(obj);
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

