using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/SistemaLogOperacoes")]
    public class SistemaLogOperacoesController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(SistemaLogOperacoes))]
        public IHttpActionResult GetById(int id)
        {
            SistemaLogOperacoes result = new SistemaLogOperacoesService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<SistemaLogOperacoes>))]
        public IHttpActionResult GetAll()
        {
            var result = new SistemaLogOperacoesService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(SistemaLogOperacoes))]
        public IHttpActionResult Add(SistemaLogOperacoes obj)
        {
            var result = new SistemaLogOperacoesService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Update(SistemaLogOperacoes obj)
        {
            var result = new SistemaLogOperacoesService().Update(obj);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("DeleteById")]
        [ResponseType(typeof(SistemaLogOperacoes))]
        public IHttpActionResult DeleteById(int id)
        {
            var result = new SistemaLogOperacoesService().DeleteById(id);
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

