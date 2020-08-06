using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/IntervencoesOperacao")]
    public class IntervencoesOperacaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(IntervencaoOperacao))]
        public IHttpActionResult GetById(int id)
        {
            IntervencaoOperacao result = new IntervencaoOperacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByOperacaoOrdem")]
        [ResponseType(typeof(List<IntervencaoOperacao>))]
        public IHttpActionResult GetByOperacaoOrdem(int id)
        {
            var result = new IntervencaoOperacaoService().GetByOperacaoOrdem(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<IntervencaoOperacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new IntervencaoOperacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(IntervencaoOperacao))]
        public IHttpActionResult Add(IntervencaoOperacao obj)
        {
            var result = new IntervencaoOperacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(IntervencaoOperacao))]
        public IHttpActionResult Update(IntervencaoOperacao obj)
        {
            var result = new IntervencaoOperacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(IntervencaoOperacao))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new IntervencaoOperacaoService().DeleteById(id);
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

