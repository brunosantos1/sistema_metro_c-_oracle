using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/MaosDeObra")]
    public class MaosDeObraController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(MaoDeObra))]
        public IHttpActionResult GetById(int id)
        {
            MaoDeObra result = new MaoDeObraService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<MaoDeObra>))]
        public IHttpActionResult GetAll()
        {
            var result = new MaoDeObraService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByOperacaoOrdem")]
        [ResponseType(typeof(List<MaoDeObra>))]
        public IHttpActionResult GetByOperacaoOrdem(int id)
        {
            var result = new MaoDeObraService().GetByOperacaoOrdem(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(MaoDeObra))]
        public IHttpActionResult Add(MaoDeObra obj)
        {
            var result = new MaoDeObraService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(MaoDeObra))]
        public IHttpActionResult Update(MaoDeObra obj)
        {
            var result = new MaoDeObraService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(MaoDeObra))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new MaoDeObraService().DeleteById(id);
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

