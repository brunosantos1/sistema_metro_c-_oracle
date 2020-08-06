using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/OperacoesOrdem")]
    public class OperacoesOrdemController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(OperacaoOrdem))]
        public IHttpActionResult GetById(int id)
        {
            OperacaoOrdem result = new OperacaoOrdemService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByOrdem")]
        [ResponseType(typeof(List<OperacaoOrdem>))]
        public IHttpActionResult GetByOrdem(int id)
        {
            var result = new OperacaoOrdemService().GetByOrdem(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNavigationPropertiesByOrdem")]
        [ResponseType(typeof(List<OperacaoOrdem>))]
        public IHttpActionResult GetNavigationPropertiesByOrdem(int id)
        {
            var result = new OperacaoOrdemService().GetNavigationPropertiesByOrdem(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<OperacaoOrdem>))]
        public IHttpActionResult GetAll()
        {
            var result = new OperacaoOrdemService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(OperacaoOrdem))]
        public IHttpActionResult Add(OperacaoOrdem obj)
        {
            var result = new OperacaoOrdemService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(OperacaoOrdem))]
        public IHttpActionResult Update(OperacaoOrdem obj)
        {
            var result = new OperacaoOrdemService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(OperacaoOrdem))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new OperacaoOrdemService().DeleteById(id);
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

