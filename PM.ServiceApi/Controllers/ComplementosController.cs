using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Complementos")]
    public class ComplementosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Complemento))]
        public IHttpActionResult GetById(int id)
        {
            Complemento result = new ComplementoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Complemento>))]
        public IHttpActionResult GetAll()
        {
            var result = new ComplementoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetBySistema")]
        [ResponseType(typeof(List<Complemento>))]
        public IHttpActionResult GetBySistema(int idSistema)
        {
            var result = new ComplementoService().GetBySistema(idSistema);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Complemento))]
        public IHttpActionResult Add(Complemento obj)
        {
            var result = new ComplementoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Complemento))]
        public IHttpActionResult Update(Complemento obj)
        {
            var result = new ComplementoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Complemento))]
        public IHttpActionResult Delete(Complemento catalogo)
        {
            var result = new ComplementoService().Delete(catalogo);
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

