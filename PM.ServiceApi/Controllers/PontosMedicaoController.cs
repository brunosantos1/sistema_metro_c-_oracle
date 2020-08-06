using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/PontosMedicao")]
    public class PontosMedicaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(PontoMedicao))]
        public IHttpActionResult GetById(int id)
        {
            PontoMedicao result = new PontoMedicaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<PontoMedicao>))]
        public IHttpActionResult GetAll()
        {
            var result = new PontoMedicaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(PontoMedicao))]
        public IHttpActionResult Add(PontoMedicao obj)
        {
            var result = new PontoMedicaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(PontoMedicao))]
        public IHttpActionResult Update(PontoMedicao obj)
        {
            var result = new PontoMedicaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(PontoMedicao))]
        public IHttpActionResult Delete(PontoMedicao pontoMedicao)
        {
            var result = new PontoMedicaoService().Delete(pontoMedicao);
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

