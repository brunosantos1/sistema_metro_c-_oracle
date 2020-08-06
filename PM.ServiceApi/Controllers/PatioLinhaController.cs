using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/PatioLinha")]
    public class PatioLinhaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(PatioLinha))]
        public IHttpActionResult GetById(int id)
        {
            PatioLinha result = new PatioLinhaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByLinhaId")]
        [ResponseType(typeof(List<PatioLinha>))]
        public IHttpActionResult GetByLinhaId(int id)
        {
            var result = new PatioLinhaService().GetByLinhaID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<PatioLinha>))]
        public IHttpActionResult GetAll()
        {
            var result = new PatioLinhaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Patio))]
        public IHttpActionResult Add(PatioLinha obj)
        {
            var result = new PatioLinhaService().Add_Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(PatioLinha))]
        public IHttpActionResult Update(PatioLinha obj)
        {
            var result = new PatioLinhaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(PatioLinha))]
        public IHttpActionResult Delete(PatioLinha obj)
        {
            var result = new PatioLinhaService().Delete(obj);
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
