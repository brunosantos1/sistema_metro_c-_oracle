using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/ChavesControle")]
    public class ChavesControleController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(ChaveControle))]
        public IHttpActionResult GetById(int id)
        {
            ChaveControle result = new ChaveControleService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<ChaveControle>))]
        public IHttpActionResult GetAll()
        {
            var result = new ChaveControleService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(ChaveControle))]
        public IHttpActionResult Add(ChaveControle obj)
        {
            var result = new ChaveControleService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(ChaveControle))]
        public IHttpActionResult Update(ChaveControle obj)
        {
            var result = new ChaveControleService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(ChaveControle))]
        public IHttpActionResult Delete(ChaveControle catalogo)
        {
            var result = new ChaveControleService().Delete(catalogo);
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

