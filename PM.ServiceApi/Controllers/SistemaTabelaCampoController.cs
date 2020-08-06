using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaTabelaCampo")]
    public class SistemaTabelaCampoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaTabelaCampo))]
        public IHttpActionResult GetById(int id)
        {
            SistemaTabelaCampo result = new SistemaTabelaCampoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaTabelaCampo>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaTabelaCampoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaTabelaCampo))]
        public IHttpActionResult Add(SistemaTabelaCampo obj)
        {
            var result = new SistemaTabelaCampoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaTabelaCampo obj)
        {
            var result = new SistemaTabelaCampoService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaTabelaCampo))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaTabelaCampoService().DeleteById(id);
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