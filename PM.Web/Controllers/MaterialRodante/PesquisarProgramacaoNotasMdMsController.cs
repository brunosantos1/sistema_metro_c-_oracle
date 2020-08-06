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
    public class PesquisarProgramacaoNotasMdMsController : BaseController
    {
        public JsonResult BuscarNotas(int idLinha, int idPatio, int idTrem)
        {
            JsonResult result = new JsonResult();
            int idTipo = 21;
            try
            {
                List<Trem> lst = (new WebServices.Service.TremServices()).GetByPatioLinhaStatus(0, 0, 0, 1).ToList();
                lst.AddRange(lst);
                lst.AddRange(lst);
                //if (lst.Count > 0)
                if (true)
                {
                    string NomeGrid = idTipo.Equals(21) ? "Ocorrencia" : idTipo.Equals(23) ? "Inspecao" : "Programacao";
                    //string NomeDataTemp = string.Format("TempData_Origem_{0}_NotaTipo_{1}", NomeGrid, idTipo.ToString());
                    //string NomeDestinoDataTemp = string.Format("TempData_Destino_{0}_NotaTipo_{1}", NomeGrid, idTipo.ToString());
                    //TempData[NomeDestinoDataTemp] = null;
                    //TempData[NomeDataTemp] = lst;


                    string sCor = "#000";
                    List<String[]> values = lst.Select(x => new String[] {
                                                                              string.Format("<input id=\"chk_{3}_{0:000000}\" type=\"checkbox\" onclick=\"fnAtualizaDataTemp(this,{0}, {1});\"> <span>{0:000000}</span>", 0, 1, NomeGrid, NomeGrid.ToLower())
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Ordem")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "10.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "25.000")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "Lorem ipsum dolor sit amet.")
                                                                            , string.Format("<span style='color:{0:dd/MM/yyyy HH:mm:ss}'><strong>{1}</strong></span>"  , sCor, DateTime.Now)
                                                                            , string.Format("<span style='color:{0}'><strong>{1}</strong></span>"  , sCor, "ABERTA")
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