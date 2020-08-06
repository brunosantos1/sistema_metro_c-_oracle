using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/CentrosCusto")]
    public class CentrosCustoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(CentroCusto))]
        public IHttpActionResult GetById(int id)
        {
            CentroCusto result = new CentroCustoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<CentroCusto>))]
        public IHttpActionResult GetAll()
        {
            var result = new CentroCustoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(CentroCusto))]
        public IHttpActionResult Add(CentroCusto obj)
        {
            var result = new CentroCustoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(CentroCusto))]
        public IHttpActionResult Update(CentroCusto obj)
        {
            var result = new CentroCustoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(CentroCusto))]
        public IHttpActionResult Delete(CentroCusto catalogo)
        {
            var result = new CentroCustoService().Delete(catalogo);
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

