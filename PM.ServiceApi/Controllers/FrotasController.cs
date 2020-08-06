using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Frotas")]
    public class FrotasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Frota))]
        public IHttpActionResult GetById(int id)
        {
            Frota result = new FrotaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Frota>))]
        public IHttpActionResult GetAll()
        {
            var result = new FrotaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Frota))]
        public IHttpActionResult Add(Frota obj)
        {
            var result = new FrotaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Frota))]
        public IHttpActionResult Update(Frota obj)
        {
            var result = new FrotaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Frota))]
        public IHttpActionResult Delete(Frota catalogo)
        {
            var result = new FrotaService().Delete(catalogo);
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

