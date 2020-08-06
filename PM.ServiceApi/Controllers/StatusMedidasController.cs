using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusMedidas")]
    public class StatusMedidasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusMedida))]
        public IHttpActionResult GetById(int id)
        {
            StatusMedida result = new StatusMedidaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByCdSap")]
        [ResponseType(typeof(StatusMedida))]
        public IHttpActionResult GetByCdSap(string cdSap)
        {
            StatusMedida result = new StatusMedidaService().GetByCdSap(cdSap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusMedida>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusMedidaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(StatusMedida))]
        public IHttpActionResult Add(StatusMedida obj)
        {
            var result = new StatusMedidaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusMedida))]
        public IHttpActionResult Update(StatusMedida obj)
        {
            var result = new StatusMedidaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusMedida))]
        public IHttpActionResult Delete(StatusMedida statusMedida)
        {
            var result = new StatusMedidaService().Delete(statusMedida);
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

