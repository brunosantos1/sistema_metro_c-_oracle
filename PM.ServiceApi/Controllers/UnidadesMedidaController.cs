using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/UnidadesMedida")]
    public class UnidadesMedidaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(UnidadeMedida))]
        public IHttpActionResult GetById(int id)
        {
            UnidadeMedida result = new UnidadeMedidaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<UnidadeMedida>))]
        public IHttpActionResult GetAll()
        {
            var result = new UnidadeMedidaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(UnidadeMedida))]
        public IHttpActionResult Add(UnidadeMedida obj)
        {
            var result = new UnidadeMedidaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(UnidadeMedida))]
        public IHttpActionResult Update(UnidadeMedida obj)
        {
            var result = new UnidadeMedidaService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(UnidadeMedida))]
        public IHttpActionResult Delete(UnidadeMedida unidadeMedida)
        {
            var result = new UnidadeMedidaService().Delete(unidadeMedida);
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

