using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/ElementosPEP")]
    public class ElementosPEPController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(ElementoPEP))]
        public IHttpActionResult GetById(int id)
        {
            ElementoPEP result = new ElementoPEPService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<ElementoPEP>))]
        public IHttpActionResult GetAll()
        {
            var result = new ElementoPEPService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(ElementoPEP))]
        public IHttpActionResult Add(ElementoPEP obj)
        {
            var result = new ElementoPEPService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(ElementoPEP))]
        public IHttpActionResult Update(ElementoPEP obj)
        {
            var result = new ElementoPEPService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(ElementoPEP))]
        public IHttpActionResult Delete(ElementoPEP catalogo)
        {
            var result = new ElementoPEPService().Delete(catalogo);
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

