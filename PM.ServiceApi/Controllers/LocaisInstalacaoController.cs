using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace PM.ServiceApi.Controllers
{
    [RoutePrefix("api/LocaisInstalacao")]
    public class LocaisInstalacaoController : ApiController
    {
        [Route("GetById")]
        [ResponseType(typeof(LocalInstalacao))]
        public IHttpActionResult GetById(int id)
        {
            LocalInstalacao result = new LocalInstalacaoService().GetByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("GetAll")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult GetAll()
        {
            var result = new LocalInstalacaoService().GetAll();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("ConsultarLCParametros")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult ConsultarLCParametros(LocalInstalacao localInstalacao)
        {
            List<LocalInstalacao> result = new LocalInstalacaoService().ConsultarLCParametros(localInstalacao);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Search")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult Search(int? idFrota, int? idTrem, int? idCarro)
        {
            var result = new LocalInstalacaoService().Search(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault());

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("SearchMS")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult SearchMS(int idFrota, int idTrem, int idCarro, int idSistema, int? idComplemento = null, int? idPosicao = null)
        {
            var result = new LocalInstalacaoService().SearchMS(idFrota, idTrem, idCarro, idSistema, idComplemento, idPosicao);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Search1")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult Search1(int? idFrota, int? idTrem, int? idCarro, int? idLinha)
        {
            var result = new LocalInstalacaoService().Search1(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault(), idLinha.GetValueOrDefault());

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Search3")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult Search3(int? idFrota, int? idTrem, int? idCarro, int? idLinha, int? idSistema, int? idComplmento, int? idPosicao)
        {
            var result = new LocalInstalacaoService().Search3(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault(), idLinha.GetValueOrDefault(), idSistema.GetValueOrDefault(), idComplmento.GetValueOrDefault(), idPosicao.GetValueOrDefault());

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Search4")]
        [ResponseType(typeof(List<LocalInstalacao>))]
        public IHttpActionResult Search4(int? idFrota, int? idTrem, int? idCarro, int? idSistema, int? idComplmento, int? idPosicao)
        {
            var result = new LocalInstalacaoService().Search4(idFrota.GetValueOrDefault(), idTrem.GetValueOrDefault(), idCarro.GetValueOrDefault(), idSistema.GetValueOrDefault(), idComplmento.GetValueOrDefault(), idPosicao.GetValueOrDefault());

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Add")]
        [ResponseType(typeof(LocalInstalacao))]
        public IHttpActionResult Add(LocalInstalacao obj)
        {
            var result = new LocalInstalacaoService().Add(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Update")]
        [ResponseType(typeof(LocalInstalacao))]
        public IHttpActionResult Update(LocalInstalacao obj)
        {
            var result = new LocalInstalacaoService().Update(obj);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Route("Delete")]
        [ResponseType(typeof(LocalInstalacao))]
        public IHttpActionResult Delete(LocalInstalacao localInstalacao)
        {
            var result = new LocalInstalacaoService().Delete(localInstalacao);
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

