using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/MAPs")]
    public class MAPsController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(MAP))]
        public IHttpActionResult GetById(int id)
        {
            MAP result = new MAPService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<MAP>))]
        public IHttpActionResult GetAll()
        {
            var result = new MAPService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route("GetByOperacaoOrdem")]
        [ResponseType(typeof(List<MAP>))]
        public IHttpActionResult GetByOperacaoOrdem(int id)
        {
            var result = new MAPService().GetByOperacaoOrdem(id);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(MAP))]
        public IHttpActionResult Add(MAP obj)
        {
            var result = new MAPService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(MAP))]
        public IHttpActionResult Update(MAP obj)
        {
            var result = new MAPService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(MAP))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new MAPService().DeleteById(id);
            if (result == false)
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

