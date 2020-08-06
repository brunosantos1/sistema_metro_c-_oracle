using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/TiposCentroTrabalho")]
    public class TiposCentroTrabalhoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(TipoCentroTrabalho))]
        public IHttpActionResult GetById(int id)
        {
            TipoCentroTrabalho result = new TipoCentroTrabalhoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<TipoCentroTrabalho>))]
        public IHttpActionResult GetAll()
        {
            var result = new TipoCentroTrabalhoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(TipoCentroTrabalho))]
        public IHttpActionResult Add(TipoCentroTrabalho obj)
        {
            var result = new TipoCentroTrabalhoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(TipoCentroTrabalho))]
        public IHttpActionResult Update(TipoCentroTrabalho obj)
        {
            var result = new TipoCentroTrabalhoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(TipoCentroTrabalho))]
        public IHttpActionResult Delete(TipoCentroTrabalho tipoCentroTrabalho)
        {
            var result = new TipoCentroTrabalhoService().Delete(tipoCentroTrabalho);
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

