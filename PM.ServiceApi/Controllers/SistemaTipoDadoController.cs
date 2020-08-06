using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaTipoDado")]
    public class SistemaTipoDadoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaTipoDado))]
        public IHttpActionResult GetById(int id)
        {
            SistemaTipoDado result = new SistemaTipoDadoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaTipoDado>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaTipoDadoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaTipoDado))]
        public IHttpActionResult Add(SistemaTipoDado obj)
        {
            var result = new SistemaTipoDadoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaTipoDado obj)
        {
            var result = new SistemaTipoDadoService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaTipoDado))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaTipoDadoService().DeleteById(id);
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