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
    public class SolicitarEntregaTremController : BaseController
    {
        [HttpGet]        
        public JsonResult PesquisarLinhaPatioTremNota(int idLinha, int idPatio, int idTrem, string cd_sap)
        {
            JsonResult result = new JsonResult();
            try
            {
                List<Nota> lst = (new WebServices.Service.NotaServices()).GetNotaVinculadaTrem(idTrem, cd_sap).ToList();
                List<Nota> lstDestino = new List<Nota>();
                TipoNota tiponota = (new WebServices.Service.TipoNotaServices()).GetByCodigoSap(cd_sap);

                bool flgEdicao = false;
                if (lst.Count > 0)
                {
                    string NomeGrid                 = cd_sap.ToUpper().Equals("MC") ? "Ocorrencia" : cd_sap.ToUpper().Equals("MI") ? "Inspecao" : "Programacao";
                    string NomeDataTemp             = string.Format("TempData_Origem_{0}_NotaTipo_{1}"   , NomeGrid, tiponota.CdSap.ToString().ToLower()).ToUpper();
                    string NomeDestinoDataTemp      = string.Format("TempData_Destino_{0}_NotaTipo_{1}"  , NomeGrid, tiponota.CdSap.ToString().ToLower()).ToUpper();
                    
                    if (TempData[NomeDestinoDataTemp]   != null)
                    {
                        lstDestino = (List<Nota>)TempData[NomeDestinoDataTemp];
                        lst.AddRange(lstDestino);
                        flgEdicao = true;
                    }
                    TempData[NomeDataTemp] = lst;

                    string sCor                     = "#F00";
                    List<String[]> values = lst.Select(x => new String[] {
                                                          string.Format("<input id=\"chk_{3}_{0:000000}\" type=\"checkbox\" {4} onclick=\"fnAtualizaDataTemp(this,{0}, '{1}');\"> <span>{0:000000}</span>", x.IdNota, x.TipoNota.CdSap, NomeGrid, NomeGrid.ToLower(),  flgEdicao ? (lstDestino.Where(c => c.IdNota.Value.Equals(x.IdNota.Value)).ToList().Count.Equals(0) ? "" :   "checked") :  "")
                                                        , (x.LocalInstalacao == null)                   ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.LocalInstalacao.DsLcInstalacao.ToUpper()
                                                        , string.IsNullOrEmpty(x.DsDescricao)           ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.DsDescricao.ToUpper()
                                                        , (x.CodeSintoma == null)                       ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.CodeSintoma.DsCode.ToUpper()
                                                        , (x.Prioridade == null)                        ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.Prioridade.DsPrioridade.ToUpper()
                                                        , string.IsNullOrEmpty(x.DtHoraNota.ToString()) ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Parse(x.DtHoraNota.ToString()))
                                                        , string.IsNullOrEmpty(x.Empregado.RgEmpregado) ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.Empregado.RgEmpregado.ToUpper()
                                                        , (x.CentroTrabalho == null)                    ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.CentroTrabalho.DsCtTrabalho.ToUpper()
                                                        , (x.StatusUsuarios == null)                    ? string.Format("<span style='color:{0}'><strong>NÃO IDENTIFICADO</strong></span>"  , sCor) : x.StatusUsuarios.LastOrDefault().DsStUsuario.ToUpper()
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
            catch (OutOfMemoryException ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return result;
        }
    }
}