using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Materials")]
    public class MaterialsController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Material))]
        public IHttpActionResult GetById(int id)
        {
            Material result = new MaterialService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Material>))]
        public IHttpActionResult GetAll()
        {
            var result = new MaterialService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Material))]
        public IHttpActionResult Add(Material obj)
        {
            var result = new MaterialService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Material))]
        public IHttpActionResult Update(Material obj)
        {
            var result = new MaterialService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Material))]
        public IHttpActionResult Delete(Material catalogo)
        {
            var result = new MaterialService().Delete(catalogo);
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

