using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/LogLogins")]
    public class LogLoginsController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult GetById(int id)
        {
            Nota result = new NotaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Nota>))]
        public IHttpActionResult GetAll()
        {
            var result = new NotaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult Update(Catalogo obj)
        {
            var result = new CatalogoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult Delete(Catalogo catalogo)
        {
            var result = new CatalogoService().Delete(catalogo);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Nota))]
        public IHttpActionResult Add_Update(Nota obj)
        {
            var result = new NotaService().Add(obj);
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
