using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaLogError")]
    public class SistemaLogErrorController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaLogError))]
        public IHttpActionResult GetById(int id)
        {
            SistemaLogError result = new SistemaLogErrorService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaLogError>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaLogErrorService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaLogError))]
        public IHttpActionResult Add(SistemaLogError obj)
        {
            var result = new SistemaLogErrorService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaLogError obj)
        {
            var result = new SistemaLogErrorService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaLogError))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaLogErrorService().DeleteById(id);
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

