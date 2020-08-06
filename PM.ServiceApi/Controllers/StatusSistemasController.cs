using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusSistemas")]
    public class StatusSistemasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusSistema))]
        public IHttpActionResult GetById(int id)
        {
            StatusSistema result = new StatusSistemaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusSistema>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusSistemaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(StatusSistema))]
        public IHttpActionResult Add(StatusSistema obj)
        {
            var result = new StatusSistemaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusSistema))]
        public IHttpActionResult Update(StatusSistema obj)
        {
            var result = new StatusSistemaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusSistema))]
        public IHttpActionResult Delete(StatusSistema statusSistema)
        {
            var result = new StatusSistemaService().Delete(statusSistema);
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

