using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Posicoes")]
    public class PosicoesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Posicao))]
        public IHttpActionResult GetById(int id)
        {
            Posicao result = new PosicaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Posicao>))]
        public IHttpActionResult GetAll()
        {
            var result = new PosicaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByComplemento")]
        [ResponseType(typeof(List<Posicao>))]
        public IHttpActionResult GetByComplemento(int idComplemento)
        {
            var result = new PosicaoService().GetByComplemento(idComplemento);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Posicao))]
        public IHttpActionResult Add(Posicao obj)
        {
            var result = new PosicaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Posicao))]
        public IHttpActionResult Update(Posicao obj)
        {
            var result = new PosicaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Posicao))]
        public IHttpActionResult Delete(Posicao posicao)
        {
            var result = new PosicaoService().Delete(posicao);
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

