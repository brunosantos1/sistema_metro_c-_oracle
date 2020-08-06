using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaEmpresa")]
    public class SistemaEmpresaController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaEmpresa))]
        public IHttpActionResult GetById(int id)
        {
            SistemaEmpresa result = new SistemaEmpresaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaEmpresa>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaEmpresaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaEmpresa))]
        public IHttpActionResult Add(SistemaEmpresa obj)
        {
            var result = new SistemaEmpresaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaEmpresa obj)
        {
            var result = new SistemaEmpresaService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaEmpresa))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaEmpresaService().DeleteById(id);
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