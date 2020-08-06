using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusCopeses")]
    public class StatusCopesesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusCopese))]
        public IHttpActionResult GetById(int id)
        {
            StatusCopese result = new StatusCopeseService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusCopese>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusCopeseService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(StatusCopese))]
        public IHttpActionResult Add(StatusCopese obj)
        {
            var result = new StatusCopeseService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusCopese))]
        public IHttpActionResult Update(StatusCopese obj)
        {
            var result = new StatusCopeseService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusCopese))]
        public IHttpActionResult Delete(StatusCopese statusCopese)
        {
            var result = new StatusCopeseService().Delete(statusCopese);
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

