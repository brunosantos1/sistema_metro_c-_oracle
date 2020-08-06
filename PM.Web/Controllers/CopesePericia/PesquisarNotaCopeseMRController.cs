using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Web.ViewModel.Copese;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PM.Domain.Entities.Enum;

namespace PM.Web.Controllers
{
    [RoutePrefix("CopesePericia")]
    public class PesquisarNotaCopeseMRController : BaseController
    {
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }


        [Route("PesquisarNotaCopeseMR")]
        public ActionResult PesquisarNotaCopeseMR()
        {
            try
            {
                PesquisaNotaCopeseEFMRViewModel telaVM = new PesquisaNotaCopeseEFMRViewModel();
                #region Carregar DropDownList
                telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
                telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, 0, true);
                telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, 0, true);
                telaVM.SelecionarSintoma = base.CarregaDropDownList(ServicoType.Sintoma);
                telaVM.SelecionarStatusCopese = base.CarregaDropDownList(ServicoType.StatusCopese);
                #endregion

                ViewBag.Action = "Pesquisar";


                return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", new PesquisaNotaCopeseEFMRViewModel());
            }
        }

        [HttpPost]
        [Route("FiltrarNotaCopeseMR")]
        public ActionResult FiltrarNotaCopeseMR(PesquisaNotaCopeseEFMRViewModel telaVM)
        {

            try
            {

                if (telaVM.id_frota_fk <= 0 && telaVM.id_trem_fk <= 0 && telaVM.id_carro <= 0
                    && String.IsNullOrEmpty(telaVM.nr_copese) && String.IsNullOrEmpty(telaVM.nr_nota_ref)
                    && telaVM.dt_inicio == null && telaVM.dt_fim == null && telaVM.id_st_copese_fk <= 0 && telaVM.id_sintoma <= 0)
                    ModelState.AddModelError("CampoRequerido", "Informe ao menos um filtro de pesquisa.");
                else if ((telaVM.dt_fim != null && telaVM.dt_fim != null) && Convert.ToDateTime(telaVM.dt_fim) < Convert.ToDateTime(telaVM.dt_inicio))
                    ModelState.AddModelError("CampoRequerido", "Data Final deve ser maior que a Data Inicial.");

                if (ModelState.IsValid)
                {
                    telaVM = CarregaTelaVM(telaVM);

                    if (telaVM.gridNotaCopese.Count <= 0)
                        ViewBag.NaoEncontrado = "Não há registro retornado na pesquisa.";
                }
                else
                {
                    var model = ModelState;
                    ViewBag.NaoEncontrado = ModelState["CampoRequerido"].Errors[0].ErrorMessage;
                }
                return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", telaVM);
            }
        }

        [Route("LimparNotaCopeseMR")]
        public ActionResult LimparNotaCopeseMR(PesquisaNotaCopeseEFMRViewModel telaVM)
        {
            try
            {
                #region Carregar DropDownList
                telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
                telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, 0, true);
                telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, 0, true);
                telaVM.SelecionarSintoma = base.CarregaDropDownList(ServicoType.Sintoma);
                telaVM.SelecionarStatusCopese = base.CarregaDropDownList(ServicoType.StatusCopese);
                #endregion

                return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", telaVM);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", telaVM);
            }
        }

        [Route("NotaRefFrotaTremCarro")]
        public JsonResult NotaRefFrotaTremCarro(string nr_nota_sap)
        {
            try
            {
                Nota nota = new Nota();
                LocalInstRef retorno = new LocalInstRef();

                if (!string.IsNullOrEmpty(nr_nota_sap))
                {
                    nota = new NotaServices().GetNotasCodigoSapMRRef(nr_nota_sap);
                    var frota = new FrotaServices().GetById(nota.LocalInstalacao.IdFrotaFk.Value);
                    var trem = new TremServices().GetById(nota.LocalInstalacao.IdTremFk.Value);
                    var carro = new CarroServices().GetById(nota.LocalInstalacao.IdCarroFk.Value);

                    retorno = new LocalInstRef
                    {
                        id_local_inst = nota.IdLocalInstFk.Value,
                        id_frota = nota.LocalInstalacao.IdFrotaFk.Value,
                        nm_frota = frota.NmFrota,
                        id_trem = nota.LocalInstalacao.IdTremFk.Value,
                        nm_trem = trem.NmTrem,
                        id_carro = nota.LocalInstalacao.IdTremFk.Value,
                        nm_carro = carro.NmCarro,
                    };
                }
                else
                {
                    retorno = new LocalInstRef
                    {
                        id_local_inst = 0,
                        id_frota = 0,
                        nm_frota = "",
                        id_trem = 0,
                        nm_trem = "*** SELECIONE ***",
                        id_carro = 0,
                        nm_carro = "*** SELECIONE ***",
                        listaFrota = base.CarregaDropDownList(ServicoType.Frota).ToList()
                    };
                }

                return Json(retorno, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
                return Json(new LocalInstRef(), JsonRequestBehavior.AllowGet);
            }
        }

        public struct LocalInstRef
        {
            public int id_local_inst { get; set; }
            public int id_frota { get; set; }
            public string nm_frota { get; set; }
            public int id_trem { get; set; }
            public string nm_trem { get; set; }
            public int id_carro { get; set; }
            public string nm_carro { get; set; }
            public List<SelectListItem> listaFrota { get; set; }
        }

        //[HttpGet]
        [Route("ExportToExcelMR")]
        public ActionResult ExportToExcelMR(PesquisaNotaCopeseEFMRViewModel telaVM)
        {
            telaVM = CarregaTelaVM(telaVM);

            var gv = new GridView();

            gv.DataSource = telaVM.gridNotaCopese;

            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;

            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = "application/ms-excel";
            Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
            Response.AddHeader("Content-Disposition", "attachment;filename=NotaCopeseMR.xls");

            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");

            StringBuilder sb = new StringBuilder();

            sb.Append("<font Style='font-size:13px; font-family:sans-serif;'>");
            sb.Append("<Table border='0px none'>");
            sb.Append("<TR>");
            //Aplica o estilo a coluna
            string sTH = "<Td Style=\"color:#FFFFFF; font-size:13px; font-family:sans-serif;\" bgColor='#6495ED' color='#DEE2E6' border='1px solid #DEE2E6' cellSpacing='0' cellPadding='0'>";
            //Criar as colunas
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Nota de Ref"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Nota COPESE"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Local de Instala&ccedil;&atilde;o"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Descri&ccedil;&atilde;o do Local de Instala&ccedil;&atilde;o"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Descri&ccedil;&atilde;o da Nota"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Sintoma"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Data"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Hora"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Notificador"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Centro de Trabalho"));
            sb.Append(string.Format("{0}<B>{1}</B></Td>", sTH, "Status da COPESE"));

            sb.Append("</TR>");

            bool alternate = true;
            string sTD;
            foreach (GridViewRow row in gv.Rows)
            {

                sb.Append("<TR>");
                //Aplica o estilo alternativo para as linhas nas colunas
                if (alternate)
                    sTD = "<Td Style=\"font-size:13px; font-family:sans-serif; \" bgColor='#F2F2F2'>";
                else
                    sTD = "<Td Style=\"font-size:13px; font-family:sans-serif; \" bgColor='transparent'>";

                alternate = !alternate;

                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[1].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[0].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[3].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[5].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[4].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[7].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, Convert.ToDateTime(row.Cells[9].Text.ToString()).ToString("dd/MM/yyyy"));
                sb.AppendFormat("{0}{1}</Td>", sTD, Convert.ToDateTime(row.Cells[9].Text.ToString()).ToString("hh:mm"));
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[2].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[6].Text.ToString());
                sb.AppendFormat("{0}{1}</Td>", sTD, row.Cells[10].Text.ToString());

                sb.Append("</TR>");
            }
            sb.Append("</Table>");
            sb.Append("</font>");

            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();

            return View("~/Views/CopesePericia/PesquisarNotaCopeseMR.cshtml", telaVM);
        }

        private PesquisaNotaCopeseEFMRViewModel CarregaTelaVM(PesquisaNotaCopeseEFMRViewModel telaVM)
        {
            #region Carregar DropDownList
            telaVM.SelecionarFrota = base.CarregaDropDownList(ServicoType.Frota);
            telaVM.SelecionarTrem = base.CarregaDropDownList(ServicoType.Trem, (telaVM.id_trem_fk != null) ? telaVM.id_trem_fk.Value : 0, false);
            telaVM.SelecionarCarro = base.CarregaDropDownList(ServicoType.Carro, telaVM.id_carro, false);
            telaVM.SelecionarSintoma = base.CarregaDropDownList(ServicoType.Sintoma);
            telaVM.SelecionarStatusCopese = base.CarregaDropDownList(ServicoType.StatusCopese);
            #endregion

            #region  CarregarGrid

            NotaServices notaService = new NotaServices();
            LocalInstalacaoServices localInstalacaoServices = new LocalInstalacaoServices();

            Nota nota = new Nota();
            LocalInstalacao localInstalacao = new LocalInstalacao();

            IList<Nota> listNota = new List<Nota>();
            Nota nota_ref = new Nota();
            IList<LocalInstalacao> listLocalInstalacao = new List<LocalInstalacao>();

            localInstalacao.IdFrotaFk = telaVM.id_frota_fk;
            localInstalacao.IdTremFk = telaVM.id_trem_fk;
            localInstalacao.IdCarroFk = telaVM.id_carro;

            listLocalInstalacao = localInstalacaoServices.ConsultarLCParametros(localInstalacao);

            int IdNotaRef = 0;
            if (!string.IsNullOrEmpty(telaVM.nr_nota_ref))
            {
                var notaRef = notaService.GetNotasCodigoSap(telaVM.nr_nota_ref);
                IdNotaRef = notaRef.IdNota.Value;
            }

            if (listLocalInstalacao.Count > 0 || localInstalacao.IdFrotaFk > 0)
            {
                foreach (var itemLC in listLocalInstalacao)
                {
                    TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PC.ToString());
                    nota.IdTpNotaFk = tipoNota.IdTpNota.Value;
                    nota.IdCodeSintomaFk = telaVM.id_sintoma;
                    nota.CdNotaSap = telaVM.nr_copese;

                    nota.IdStCopeseFk = telaVM.id_st_copese_fk;
                    nota.IdLocalInstFk = itemLC.IdLcInstalacao;
                    nota.IdNotaReferenciaFk = IdNotaRef;

                    DateTime dtIni = (telaVM.dt_inicio != null) ? DateTime.Parse(telaVM.dt_inicio) : new DateTime();
                    DateTime dtFim = (telaVM.dt_fim != null) ? DateTime.Parse(telaVM.dt_fim) : new DateTime();

                    var retorno = notaService.ConsultarNotaCopeseEFMRParametros(nota, dtIni, dtFim);
                    foreach (var item in retorno)
                    {
                        listNota.Add(item);
                    }
                }
            }
            else
            {
                TipoNota tipoNota = new TipoNotaServices().GetByCodigoSap(TipoNotaSelecionarType.PC.ToString());
                nota.IdTpNotaFk = tipoNota.IdTpNota.Value;
                nota.IdCodeSintomaFk = telaVM.id_sintoma;
                nota.CdNotaSap = telaVM.nr_copese;
                nota.IdStCopeseFk = telaVM.id_st_copese_fk;

                //nota.IdStCopeseFk = telaVM.id_st_copese_fk;
                nota.IdNotaReferenciaFk = IdNotaRef;

                DateTime dtIni = (telaVM.dt_inicio != null) ? DateTime.Parse(telaVM.dt_inicio) : new DateTime();
                DateTime dtFim = (telaVM.dt_fim != null) ? DateTime.Parse(telaVM.dt_fim) : new DateTime();

                listNota = notaService.ConsultarNotaCopeseEFMRParametros(nota, dtIni, dtFim);
            }

            GridNotaCopeseViewModel gridNotaCopeseViewModels = new GridNotaCopeseViewModel();
            foreach (var item in listNota)
            {
                gridNotaCopeseViewModels = new GridNotaCopeseViewModel();
                gridNotaCopeseViewModels.nr_copese = item.CdNotaSap;
                gridNotaCopeseViewModels.id_copese = item.IdNota.Value.ToString();
                gridNotaCopeseViewModels.ds_nota = item.DsDescricao;
                if (item.DtHoraNota != null)
                    gridNotaCopeseViewModels.dt_abertura_nota_copese = item.DtHoraNota.Value;

                if (item.IdCodeSintomaFk != null)
                {
                    Code code = new SintomaServices().GetAll().ToList().Find(c => c.IdCode == item.IdCodeSintomaFk.Value);
                    gridNotaCopeseViewModels.ds_sintoma = code.DsCode;
                }

                if (item.IdNotificadorFk != null)
                {
                    Empregado empregado = new EmpregadoServices().GetById(item.IdNotificadorFk.Value);
                    gridNotaCopeseViewModels.nr_notificador = (empregado != null) ? empregado.RgEmpregado : null;
                }

                if (item.IdStCopeseFk > 0)
                {
                    StatusCopese statusCopese = new StatusCopeseServices().GetAll().ToList().Find(s => s.IdStCopese == item.IdStCopeseFk);
                    gridNotaCopeseViewModels.ds_st_copese = statusCopese.DsStCopese;
                }

                if (item.IdNotaReferenciaFk != null)
                {
                    nota_ref = notaService.GetById(item.IdNotaReferenciaFk.Value);
                    if (nota_ref != null)
                    {
                        gridNotaCopeseViewModels.nr_nota_ref = nota_ref.CdNotaSap;

                        if (nota_ref.IdLocalInstFk != null)
                            nota_ref.LocalInstalacao = localInstalacaoServices.GetById(nota_ref.IdLocalInstFk.Value);
                        if (nota_ref.LocalInstalacao != null)
                        {
                            gridNotaCopeseViewModels.ds_lc_inst = nota_ref.LocalInstalacao.DsLcInstalacao;
                            gridNotaCopeseViewModels.nr_lc_inst = nota_ref.LocalInstalacao.CdSap;
                        }

                        if (nota_ref.IdCentroTrabalhoFk > 0)
                            nota_ref.CentroTrabalho = new CentroTrabalhoServices().GetAll().Find(c => c.IdCtTrabalho == nota_ref.IdCentroTrabalhoFk);
                        if (nota_ref.CentroTrabalho != null)
                            gridNotaCopeseViewModels.ds_ct_trabalho = nota_ref.CentroTrabalho.DsCtTrabalho;

                        gridNotaCopeseViewModels.dt_abertura_nota_ref = nota_ref.DtHoraNota.Value;
                    }
                }

                telaVM.gridNotaCopese.Add(gridNotaCopeseViewModels);

            }
            #endregion
            return telaVM;
        }


        [Route("FiltrarNotaCopeseMRjson")]
        public JsonResult FiltrarNotaCopeseMRjson(PesquisaNotaCopeseEFMRViewModel telaVM)
        {
            JsonResult result;
            try
            {
                if ((telaVM.id_frota_fk == null || telaVM.id_frota_fk <= 0) && telaVM.id_trem_fk <= 0 && telaVM.id_carro <= 0
                 && String.IsNullOrEmpty(telaVM.nr_copese) && String.IsNullOrEmpty(telaVM.nr_nota_ref)
                 && telaVM.dt_inicio == null && telaVM.dt_fim == null && telaVM.id_st_copese_fk <= 0 && telaVM.id_sintoma <= 0)
                    ModelState.AddModelError("CampoRequerido", "Informe ao menos um filtro de pesquisa.");
                else if ((telaVM.dt_inicio != null && telaVM.dt_fim != null) && Convert.ToDateTime(Convert.ToDateTime(telaVM.dt_fim).ToString("dd/MM/yyyy")) < Convert.ToDateTime(Convert.ToDateTime(telaVM.dt_inicio).ToString("dd/MM/yyyy")))
                    ModelState.AddModelError("CampoRequerido", "Data Final deve ser maior que a Data Inicial.");

                if (ModelState.IsValid)
                {
                    PesquisaNotaCopeseEFMRViewModel telaVMReturn = new PesquisaNotaCopeseEFMRViewModel();

                    //Carregamento dos Documentos Vinculados
                    telaVMReturn = CarregaTelaVM(telaVM);

                    if (telaVMReturn != null)
                    {
                        if (telaVMReturn.gridNotaCopese.Count > 0)
                        {
                            //Conversão de ViewModel para Json compatível com o plugin dataTable
                            List<String[]> values = telaVMReturn.gridNotaCopese.Select(x => new String[] {
                            (x.nr_nota_ref != null) ? x.nr_nota_ref.ToString():string.Empty,
                            (x.nr_copese != null) ? x.nr_copese:string.Empty,
                            (x.nr_lc_inst != null) ? x.nr_lc_inst:string.Empty,
                            (x.ds_lc_inst != null) ? x.ds_lc_inst.ToString():string.Empty,
                            (x.ds_nota != null) ? x.ds_nota.ToString():string.Empty,
                            (x.ds_sintoma != null) ? x.ds_sintoma.ToString():string.Empty,
                            (x.dt_abertura_nota_copese != null) ? Convert.ToDateTime(x.dt_abertura_nota_copese.ToString()).ToString("dd/MM/yyyy"):string.Empty,
                            (x.dt_abertura_nota_copese != null) ? Convert.ToDateTime(x.dt_abertura_nota_copese.ToString()).ToString("HH:mm"):string.Empty,
                            (x.nr_notificador != null) ? x.nr_notificador.ToString():string.Empty,
                            (x.ds_ct_trabalho != null) ? x.ds_ct_trabalho.ToString():string.Empty,
                            (x.ds_st_copese != null) ? x.ds_st_copese.ToString():string.Empty,
                            string.Format(@"<a href='#' data-id='{0}' class='btn_details'><i class='material-icons'>search</i></a>" +
                                        "<a href='#' data-id='{0}' class='btn_edit'><i class='material-icons'>edit</i></a>"+
                                        "<a href='#' data-id='{0}' class='btn_descaracterizar'><i class='material-icons'>close</i></a>"+
                                        "<a href='#' data-id='{0}' class='btn_encerrar'><i class='material-icons' style='color:#FF0000'>close</i></a>",(x.id_copese != null) ? x.id_copese.ToString():string.Empty)
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
                    else
                    {
                        List<String[]> values = new List<string[]>();
                        var _values = new { data = values };
                        result = Json(_values, JsonRequestBehavior.AllowGet);
                    }

                    if (telaVM.gridNotaCopese.Count <= 0)
                        ViewBag.NaoEncontrado = "Não há registro retornado na pesquisa.";
                }
                else
                {
                    var model = ModelState;
                    ViewBag.NaoEncontrado = ModelState["CampoRequerido"].Errors[0].ErrorMessage;
                    List<String[]> values = new List<string[]>();
                    var _values = new { data = values };
                    result = Json(_values, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                List<String[]> values = new List<string[]>();
                var _values = new { data = values };
                result = Json(_values, JsonRequestBehavior.AllowGet);
            }

            return result;

        }
    }
}