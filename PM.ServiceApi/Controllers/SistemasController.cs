using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Sistemas")]
    public class SistemasController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Sistema))]
        public IHttpActionResult GetById(int id)
        {
            Sistema result = new SistemaService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Sistema>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [Route("GetByFrota")]
        [ResponseType(typeof(List<Sistema>))]
        public IHttpActionResult GetByFrota(int id)
        {
            var result = new SistemaService().GetByFrota(id);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetSintomas")]
        [ResponseType(typeof(List<Code>))]
        public IHttpActionResult GetSintomas(int idSistema)
        {
            var result = new SistemaService().GetSintomas(idSistema);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetSistemas")]
        [ResponseType(typeof(List<GrupoCode>))]
        public IHttpActionResult GetSistemas(int idPerfil)
        {
            var result = new SistemaService().GetSistemas(idPerfil);

            if (result == null)
            {
                return NotFound();
            }
            //List<GrupoCode> newGrupo
            foreach(GrupoCode grupo in result)
            {
                grupo.Catalogos = null;
            }

            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Sistema))]
        public IHttpActionResult Add(Sistema obj)
        {
            var result = new SistemaService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
       
        [Route("Delete")]
        [ResponseType(typeof(Sistema ))]
        public IHttpActionResult Delete(Sistema obj)
        {
            var result = new SistemaService().Delete(obj);
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

