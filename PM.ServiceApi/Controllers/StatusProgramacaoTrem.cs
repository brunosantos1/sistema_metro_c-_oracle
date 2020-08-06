
using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/StatusProgramacaoTrem")]
    public class StatusProgramacaoTremController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(StatusProgramacaoTrem))]
        public IHttpActionResult GetById(int id)
        {
            StatusProgramacaoTrem result = new StatusProgramacaoTremService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<StatusProgramacaoTrem>))]
        public IHttpActionResult GetAll()
        {
            var result = new StatusProgramacaoTremService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(StatusProgramacaoTrem))]
        public IHttpActionResult Add(StatusProgramacaoTrem obj)
        {
            var result = new StatusProgramacaoTremService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(StatusProgramacaoTrem))]
        public IHttpActionResult Update(StatusProgramacaoTrem obj)
        {
            var result = new StatusProgramacaoTremService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(StatusProgramacaoTrem))]
        public IHttpActionResult Delete(StatusProgramacaoTrem obj)
        {
            var result = new StatusProgramacaoTremService().Delete(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByCdSap")]
        [ResponseType(typeof(StatusProgramacaoTrem))]
        public IHttpActionResult GetByCdSap(string cd)
        {
            StatusProgramacaoTrem result = new StatusProgramacaoTremService().GetByCdSap(cd);
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

