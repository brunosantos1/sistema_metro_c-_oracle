using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/Programacao")]
    public class ProgramacaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult GetById(int id)
        {
            Programacao result = new ProgramacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<Programacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new ProgramacaoService().GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetNavigationPropertiesByID")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult GetNavigationPropertiesByID(int id)
        {
            Programacao result = new ProgramacaoService().GetNavigationPropertiesByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetByProgramacao")]
        [ResponseType(typeof(List<Programacao>))]
        public IHttpActionResult GetByProgramacao(int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
        {
            var result = new ProgramacaoService().GetByProgramacao(idLinha, idPatio, idTrem, idMotivo, dtInicio, dtFinal);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult Add(Programacao obj)
        {
            var result = new ProgramacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult Update(Programacao obj)
        {
            var result = new ProgramacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new ProgramacaoService().DeleteById(id);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("LiberarProgramacao")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult LiberarProgramacao(Programacao obj)
        {
            var result = new ProgramacaoService().LiberarProgramacao(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("CancelaProgramacao")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult CancelaProgramacao(Programacao obj)
        {
            var result = new ProgramacaoService().CancelaProgramacao(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("MudarLocalProgramacao")]
        [ResponseType(typeof(Programacao))]
        public IHttpActionResult MudarLocalProgramacao(Programacao obj)
        {
            var result = new ProgramacaoService().MudarLocalProgramacao(obj);
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

        [Route("AutoComplete")]
        [ResponseType(typeof(List<Programacao>))]
        public IHttpActionResult AutoComplete(string campo, string term)
        {
            List<Programacao> result = new ProgramacaoService().AutoComplete(campo, term);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}