using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaTipoLog")]
    public class SistemaTipoLogController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaTipoLog))]
        public IHttpActionResult GetById(int id)
        {
            SistemaTipoLog result = new SistemaTipoLogService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaTipoLog>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaTipoLogService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaTipoLog))]
        public IHttpActionResult Add(SistemaTipoLog obj)
        {
            var result = new SistemaTipoLogService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaTipoLog obj)
        {
            var result = new SistemaTipoLogService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaTipoLog))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaTipoLogService().DeleteById(id);
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