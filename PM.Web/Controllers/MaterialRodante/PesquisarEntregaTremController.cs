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
    public class PesquisarEntregaTremController : Controller
    {
        // GET: PesquisarEntregaTrem
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PesquisarEntrega(int idLinha, int idPatio, int idTrem, int idMotivo, string dtInicio, string dtFinal)
        {
            JsonResult result = new JsonResult();
            try
            {
                List<EntregaTrem> lst = (new WebServices.Service.EntregaTremServices()).GetByEntrega(idLinha, idPatio, idTrem, idMotivo, DateTime.Parse(dtInicio), DateTime.Parse(dtFinal)).OrderByDescending(c => c.DtEntrega).ToList();
                //List<Nota> lstNota = (new WebServices.Service.NotaServices()).GetNotasVinculadasEntregaTrem(idEntrega, idTipo).ToList();
                if (lst.Count > 0)
                {   
                    List<String[]> values = lst.Select(x => new String[] {
                                                         //string.Format("<input id=\"opt_{0}\" type=\"radio\" onclick=\"alert(this);fnAtualizaDataTemp(this,{0});\"> <span>{0:000000}</span>", x.IdEntrega )
                                                          string.Format("<a href=\"#\" data-id=\"{0}\" title=\"Nota [{0:00000}]\" onclick=\"fnCarregaHeaderEntrega('spNotas_','{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaNotasVinculadas(this,{0});\"><strong>{0:00000}</strong></a> \n",x.IdEntrega, x.Linha.NmLinha.ToUpper(), x.Patio.DsPatio.ToUpper(), x.Trem.NmTrem.ToUpper(), x.DtEntrega, DateTime.Parse(lst[0].DtLiberacao.ToString()).Year.Equals(1)      ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtLiberacao), DateTime.Parse(lst[0].DtCancelamento.ToString()).Year.Equals(1)   ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtCancelamento), x.Trem.StatusTrem == null ? "NÃO IDENTIFICADO"  : x.Trem.StatusTrem.DsStTrem.ToUpper())
                                                        , x.Trem.NmTrem == null ? "NÃO IDENTIFICADO"  : x.Trem.NmTrem.ToUpper()
                                                        , x.RespEntrega == null ? "NÃO IDENTIFICADO"  : x.RespEntrega.NmFuncionario.ToUpper()
                                                        , x.Patio       == null ? "NÃO IDENTIFICADO"  : x.Patio.DsPatio.ToUpper()
                                                        , x.Trem.LinhaAtual == null ? "NÃO IDENTIFICADO"  : x.Trem.LinhaAtual.NmLinha.ToUpper()
                                                        , DateTime.Parse(x.DtEntrega.ToString()).Year.Equals(1)        ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtEntrega)
                                                        , DateTime.Parse(x.DtLiberacao.ToString()).Year.Equals(1)      ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtLiberacao)
                                                        , DateTime.Parse(x.DtCancelamento.ToString()).Year.Equals(1)   ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtCancelamento)
                                                        , x.Trem.StatusTrem == null ? "NÃO IDENTIFICADO"  : x.Trem.StatusTrem.DsStTrem.ToUpper()
                                                        , x.RespLiberacao   == null ? "NÃO IDENTIFICADO"  : x.RespLiberacao.NmFuncionario.ToUpper()
                                                        , !DateTime.Parse(x.DtLiberacao.ToString()).Year.Equals(1) ? " " : 
                                                          string.Format("<a href=\"#\" class=\"popup-liberar-entrega-trem\"                data-toggle=\"modal\" data-id=\"{0}\" data-target=\"#popup-liberar-entrega-trem\"          onclick=\"fnCarregaHeaderEntrega('spNotas_'     ,'{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaHeaderEntrega('spLiberar_'     ,'{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaNotasVinculadas(this,{0});\"><i class=\"material-icons btn_manobratrem\" style=\"cursor:pointer;display:inline\" title=\"Liberar Entrega do Trem [{3}]\">touch_app</i> </a>" +
                                                                        "<a href=\"#\" class=\"popup-cancelamento-entrega-trem\"           data-toggle=\"modal\" data-id=\"{0}\" data-target=\"#popup-cancelamento-entrega-trem\"     onclick=\"fnCarregaHeaderEntrega('spNotas_'     ,'{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaHeaderEntrega('spCancelamento_','{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaNotasVinculadas(this,{0});\"><i class=\"material-icons btn_manobratrem\" style=\"cursor:pointer;display:inline\" title=\"Cancelar Entrega do Trem [{3}]\">rv_hookup</i> </a>" +
                                                                        "<a href=\"#\" class=\"popup-local-entrega-entrega-trem\"          data-toggle=\"modal\" data-id=\"{0}\" data-target=\"#popup-local-entrega-entrega-trem\"    onclick=\"fnCarregaHeaderEntrega('spNotas_'     ,'{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaHeaderEntrega('spMudarLocal_'  ,'{0:00000}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}'); fnCarregaNotasVinculadas(this,{0});\"><i class=\"material-icons btn_manobratrem\" style=\"cursor:pointer;display:inline\" title=\"Alterar local de Entrega do Trem [{3}]\">merge_type</i> </a>" +
                                                                        "<a href=\"/MaterialRodante/SolicitarEntregaTrem?idEntrega={0}\"  ><i class=\"material-icons btn_manobratrem\" style=\"cursor:pointer;display:inline\" title=\"Desvincular notas da Entrega do Trem [{3}]\">build</i> </a>"
                                                                        , x.IdEntrega
                                                                        , x.Linha.NmLinha.ToUpper()
                                                                        , x.Patio.DsPatio.ToUpper()
                                                                        , x.Trem.NmTrem.ToUpper()
                                                                        , x.DtEntrega
                                                                        , DateTime.Parse(lst[0].DtLiberacao.ToString()).Year.Equals(1)      ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtLiberacao)
                                                                        , DateTime.Parse(lst[0].DtCancelamento.ToString()).Year.Equals(1)   ? "" : string.Format("{0:dd/MM/yyyy HH:mm:ss}", x.DtCancelamento)
                                                                        , x.Trem.StatusTrem == null ? "NÃO IDENTIFICADO"  : x.Trem.StatusTrem.DsStTrem.ToUpper()                                                                        
                                                                      )
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

            }
            catch(Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }

        public JsonResult BuscarNotas(int idEntrega, int idTipo)
        {
            JsonResult result = new JsonResult();
            try
            {   
                List<Nota> lst = (new WebServices.Service.NotaServices()).GetNotasVinculadasEntregaTrem(idEntrega, idTipo).ToList();
                if (lst.Count > 0)
                {
                    string sCor = "#F00";
                    List<String[]> values = lst.Select(x => new String[] {
                                                          string.Format("<strong>{0:000000}</strong>", x.IdNota)
                                                        , (x.LocalInstalacao == null)                   ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.LocalInstalacao.DsLcInstalacao.ToUpper()
                                                        , string.IsNullOrEmpty(x.DsDescricao)           ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.DsDescricao.ToUpper()
                                                        , (x.CodeSintoma == null)                       ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.CodeSintoma.DsCode.ToUpper()
                                                        , (x.Prioridade == null)                        ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.Prioridade.DsPrioridade.ToUpper()
                                                        , string.IsNullOrEmpty(x.DtHoraNota.ToString()) ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Parse(x.DtHoraNota.ToString()))
                                                        , string.IsNullOrEmpty(x.Empregado.RgEmpregado) ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.Empregado.RgEmpregado.ToUpper()
                                                        , (x.CentroTrabalho == null)                    ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.CentroTrabalho.DsCtTrabalho
                                                        , (x.StatusSistema == null)                     ? string.Format("<span style='color:{0}'><strong>ABERTA</strong></span>"            , sCor) : x.StatusSistema.DsStSistema
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
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }
       
    }
}