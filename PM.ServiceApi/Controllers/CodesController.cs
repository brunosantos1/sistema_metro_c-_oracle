using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Codes")]
    public class CodesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Code))]
        public IHttpActionResult GetById(int id)
        {
            Code result = new CodeService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route("GetTipoServico")]
        [ResponseType(typeof(List<Code>))]
        public IHttpActionResult GetTipoServico()
        {
            List<Code> result = new CodeService().GetTipoServico();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route("GetByCdSap")]
        [ResponseType(typeof(Code))]
        public IHttpActionResult GetByCdSap(string cdSap)
        {
            Code result = new CodeService().GetByCdSap(cdSap);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Code>))]
        public IHttpActionResult GetAll()
        {
            var result = new CodeService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Code))]
        public IHttpActionResult Add(Code obj)
        {
            var result = new CodeService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Code))]
        public IHttpActionResult Update(Code obj)
        {
            var result = new CodeService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Code))]
        public IHttpActionResult Delete(Code catalogo)
        {
            var result = new CodeService().Delete(catalogo);
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

