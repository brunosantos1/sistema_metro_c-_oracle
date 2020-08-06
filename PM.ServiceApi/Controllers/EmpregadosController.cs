using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Empregados")]
    public class EmpregadosController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Empregado))]
        public IHttpActionResult GetById(int id)
        {
            Empregado result = new EmpregadoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByNomeOrRG")]
        [ResponseType(typeof(List<Empregado>))]
        public IHttpActionResult GetByNomeOrRG(string nome_rg)
        {
            var result = new EmpregadoService().GetByNomeOrRG(nome_rg);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Empregado>))]
        public IHttpActionResult GetAll()
        {
            var result = new EmpregadoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [Route("Add")]
        [ResponseType(typeof(Empregado))]
        public IHttpActionResult Add(Empregado obj)
        {
            var result = new EmpregadoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Empregado))]
        public IHttpActionResult Update(Empregado obj)
        {
            var result = new EmpregadoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(Empregado))]
        public IHttpActionResult Delete(Empregado catalogo)
        {
            var result = new EmpregadoService().Delete(catalogo);
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

