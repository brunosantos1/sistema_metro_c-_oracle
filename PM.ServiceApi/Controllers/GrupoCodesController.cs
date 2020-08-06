using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/GrupoCodes")]
    public class GrupoCodesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(GrupoCode))]
        public IHttpActionResult GetById(int id)
        {
            GrupoCode result = new GrupoCodeService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<GrupoCode>))]
        public IHttpActionResult GetAll()
        {
            var result = new GrupoCodeService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(GrupoCode))]
        public IHttpActionResult Add(GrupoCode obj)
        {
            var result = new GrupoCodeService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(GrupoCode))]
        public IHttpActionResult Update(GrupoCode obj)
        {
            var result = new GrupoCodeService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(GrupoCode))]
        public IHttpActionResult Delete(GrupoCode catalogo)
        {
            var result = new GrupoCodeService().Delete(catalogo);
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

