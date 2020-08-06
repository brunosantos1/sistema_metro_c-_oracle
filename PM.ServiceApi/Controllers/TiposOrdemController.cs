using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/TiposOrdem")]
    public class TiposOrdemController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(TipoOrdem))]
        public IHttpActionResult GetById(int id)
        {
            TipoOrdem result = new TipoOrdemService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<TipoOrdem>))]
        public IHttpActionResult GetAll()
        {
            var result = new TipoOrdemService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(TipoOrdem))]
        public IHttpActionResult Add(TipoOrdem obj)
        {
            var result = new TipoOrdemService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(TipoOrdem))]
        public IHttpActionResult Update(TipoOrdem obj)
        {
            var result = new TipoOrdemService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(TipoOrdem))]
        public IHttpActionResult Delete(TipoOrdem tipoOrdem)
        {
            var result = new TipoOrdemService().Delete(tipoOrdem);
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

