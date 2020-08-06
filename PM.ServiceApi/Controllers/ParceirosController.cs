using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Parceiro")]
    public class ParceiroController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Parceiro))]
        public IHttpActionResult GetById(int id)
        {
            Parceiro result = new ParceiroService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Parceiro>))]
        public IHttpActionResult GetAll()
        {
            var result = new ParceiroService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Parceiro))]
        public IHttpActionResult Add(Parceiro obj)
        {
            var result = new ParceiroService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Parceiro))]
        public IHttpActionResult Update(Parceiro obj)
        {
            var result = new ParceiroService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Parceiro))]
        public IHttpActionResult Delete(Parceiro Parceiro)
        {
            var result = new ParceiroService().Delete(Parceiro);
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

