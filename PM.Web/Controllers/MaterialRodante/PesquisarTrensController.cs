using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.Web.ViewModel;

namespace PM.Web.Controllers.MaterialRodante
{
    public class PesquisarTrensController : Controller
    {
        [HttpGet]        
        public JsonResult PesquisarTrensFiltro(int idLinha, int idPatio, int idStatus, int isManobra )
        {
            JsonResult result;
            List<Trem> lst = (new WebServices.Service.TremServices()).GetByPatioLinhaStatus(idLinha, idPatio, idStatus, isManobra).ToList();
            
            if (lst.Count > 0)
            {
                List<String[]> values = lst.Select(x => new String[] {
                                                        string.Format("<span style='color: {1}'><strong>{0}</strong></span>", x.NmTrem.ToUpper()
                                                                                                           , x.StatusTrem.IdStTrem.Equals(1) ? "#98FB98" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(2) ? "#FFA500" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(3) ? "#FF6347" : "#BA55D3"
                                                                    ),
                                                        string.Format("<span style='color: {1}'><strong>{0}</strong></span>", x.StatusTrem.DsStTrem.ToUpper()
                                                                                                           , x.StatusTrem.IdStTrem.Equals(1) ? "#98FB98" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(2) ? "#FFA500" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(3) ? "#FF6347" : "#BA55D3"
                                                                    ),
                                                        string.Format("<span style='color: {1}'><strong>{0}</strong></span>", x.LinhaOrigem.NmLinha.ToUpper()
                                                                                                           , x.StatusTrem.IdStTrem.Equals(1) ? "#98FB98" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(2) ? "#FFA500" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(3) ? "#FF6347" : "#BA55D3"
                                                                    ),
                                                        string.Format("<span style='color: {1}'><strong>{0}</strong></span>", "ZONA FIXO".ToUpper()
                                                                                                           , x.StatusTrem.IdStTrem.Equals(1) ? "#98FB98" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(2) ? "#FFA500" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(3) ? "#FF6347" : "#BA55D3"
                                                                    ),
                                                        string.Format("<span style='color: {1}'><strong>{0}</strong></span>", x.LinhaAtual.NmLinha.ToUpper()
                                                                                                           , x.StatusTrem.IdStTrem.Equals(1) ? "#98FB98" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(2) ? "#FFA500" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(3) ? "#FF6347" : "#BA55D3"
                                                                    ),
                                                        string.Format("<span style='color: {1}'><strong>{0}</strong></span>", "KM Atual Fixo".ToUpper()
                                                                                                           , x.StatusTrem.IdStTrem.Equals(1) ? "#98FB98" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(2) ? "#FFA500" :
                                                                                                             x.StatusTrem.IdStTrem.Equals(3) ? "#FF6347" : "#BA55D3"
                                                                    ),
                                                        string.Format("<a href='/MaterialRodante/DocumentoMedicao/'?id={2}' data-id='{2}'> <i class=\"material-icons btn_manobratrem\" data-id=\"{0}\" style=\"cursor:pointer;display:inline\" title=\"atualizar km\">directions</i> </a>" +
                                                                      "<a href='/MaterialRodante/SolicitarEntregaTrem?idLinha={0}&idPatio={1}&idTrem={2}' data-id='{2}'> <i class=\"material-icons btn_entregatrem\" data-id=\"{0}\" style=\"cursor:pointer;display:inline\" title=\"entrega de trem\">train</i> </a>" +
                                                                      "<a href='/MaterialRodante/SolicitarManobra/'?id={2}' data-id='{2}'> <i class=\"material-icons btn_atualizarkm\" data-id=\"{0}\" style=\"cursor:pointer;display:inline\" title=\"manobra de trem\">edit</i> </a>"
                                                                      , x.IdLinhaAtualFk //idLinha
                                                                      , x.IdPatioFk // idPatio
                                                                      , x.IdTrem)
                                                    }).ToList();
                var _values = new { data = values };
                result = Json(_values, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<String[]> values = new List<string[]>();
                var _values = new { data = values };
                result = Json(_values, JsonRequestBehavior.AllowGet);
            }
            return result;
        }

        public ActionResult CancelarEntregaTrem(int idEntrega)
        {
            return PartialView("CancelarEntregaTrem");
        }

        public ActionResult MudarLocalEntregaTrem(int idEntrega)
        {
            return PartialView();
        }

        public ActionResult DesvinvularNotaEntregaTrem(int idEntrega)
        {
            return PartialView();
        }

    }
}