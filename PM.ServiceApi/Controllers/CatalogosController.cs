using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Catalogos")]
    public class CatalogosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult GetById(int id)
        {
            Catalogo result = new CatalogoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Catalogo>))]
        public IHttpActionResult GetAll()
        {
            var result = new CatalogoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Catalogo))]
        public IHttpActionResult Add(Catalogo obj)
        {
            var result = new CatalogoService().Add(obj);
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}

