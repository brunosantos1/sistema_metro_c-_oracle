using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaPerfilItem")]
    public class SistemaPerfilItemController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaPerfilItem))]
        public IHttpActionResult GetById(int id)
        {
            SistemaPerfilItem result = new SistemaPerfilItemService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaPerfilItem>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaPerfilItemService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaPerfilItem))]
        public IHttpActionResult Add(SistemaPerfilItem obj)
        {
            var result = new SistemaPerfilItemService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaPerfilItem obj)
        {
            var result = new SistemaPerfilItemService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaPerfilItem))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaPerfilItemService().DeleteById(id);
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