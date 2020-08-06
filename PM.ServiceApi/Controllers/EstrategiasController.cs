using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Estrategias")]
    public class EstrategiasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Estrategia))]
        public IHttpActionResult GetById(int id)
        {
            Estrategia result = new EstrategiaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Estrategia>))]
        public IHttpActionResult GetAll()
        {
            var result = new EstrategiaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Estrategia))]
        public IHttpActionResult Add(Estrategia obj)
        {
            var result = new EstrategiaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Estrategia))]
        public IHttpActionResult Update(Estrategia obj)
        {
            var result = new EstrategiaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Estrategia))]
        public IHttpActionResult Delete(Estrategia catalogo)
        {
            var result = new EstrategiaService().Delete(catalogo);
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

