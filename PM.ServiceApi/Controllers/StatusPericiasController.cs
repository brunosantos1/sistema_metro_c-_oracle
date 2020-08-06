using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusPericias")]
    public class StatusPericiasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusPericia))]
        public IHttpActionResult GetById(int id)
        {
            StatusPericia result = new StatusPericiaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusPericia>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusPericiaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(StatusPericia))]
        public IHttpActionResult Add(StatusPericia obj)
        {
            var result = new StatusPericiaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusPericia))]
        public IHttpActionResult Update(StatusPericia obj)
        {
            var result = new StatusPericiaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusPericia))]
        public IHttpActionResult Delete(StatusPericia statusPericia)
        {
            var result = new StatusPericiaService().Delete(statusPericia);
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

