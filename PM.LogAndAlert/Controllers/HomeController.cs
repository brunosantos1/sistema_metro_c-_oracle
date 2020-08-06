using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PM.Domain.Entities;

namespace PM.LogAndAlert.Controllers
{
    [Authorize]
    [RoutePrefix("api/home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MostrarAlerta(int ID)
        {
            ViewBag.Valor = string.Format("Valor Recebido é [{0}]", ID);
            return PartialView();
        }

        public string MontaMenu()
        {
            List<MenuSistema> _retorno = new List<MenuSistema>();
            List<MenuSistema> _retorno1 = new List<MenuSistema>();

            string saida = "";
            if (bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsManagerScaa"].ToString()))
            {
                PM.SCAA.SharpScaa.Resposta oResposta = new PM.SCAA.SharpScaa.Resposta();
                if (User.Identity.IsAuthenticated)
                {
                    if (TempData["_SharpScaaResposta"] == null)
                    {
                        Server.TransferRequest("/account/login");
                    }
                    else
                    {
                        oResposta = TempData["_SharpScaaResposta"] as PM.SCAA.SharpScaa.Resposta;
                        TempData.Keep("_SharpScaaResposta");
                        if (oResposta._status)
                        {
                            saida = Menu.getMontaMenu(Menu.getMenuScaa(oResposta._usuario._aplicacao._modulo.ToList()));
                        }
                    }
                    saida = Menu.getMontaMenu(Menu.GeraDados());
                }
            }
            else
            {
                saida = Menu.getMontaMenu(Menu.GeraDados());
            }
            return saida.ToString();
        }
    }

    public static class Menu
    {
        public static List<SistemaMenu> GeraDados()
        {
            List<SistemaMenu> _retorno = new List<SistemaMenu>();
            SistemaMenu Item = new SistemaMenu();
            try
            {
                string txtLegendaPai = ""; string txtLegenda = ""; string txtURL = ""; string txtTooltip = ""; string txtEstilo = ""; int Ordem = 0;

                /// Geral
                txtLegendaPai = ""; txtLegenda = "Geral"; txtURL = "#"; txtTooltip = "Geral"; Ordem = 1;
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = true; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Inicio
                txtLegendaPai = "Geral"; txtLegenda = "Inicio"; txtURL = "home/index"; txtTooltip = "Tela inicial"; Ordem = 1; txtEstilo = "<i class=\"fa fa-home\"></i>";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);


                #region --|Cadastros|--
                /// Geral - Cadastros
                txtLegendaPai = "Geral"; txtLegenda = "Cadastros"; txtURL = "#"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "<i class=\"fa fa-edit\"></i>";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Empresas
                txtLegendaPai = "Cadastros"; txtLegenda = "Empresas"; txtURL = "empresa/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Aplicação
                txtLegendaPai = "Cadastros"; txtLegenda = "Aplicação"; txtURL = "aplicacao/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                // Geral - Cadastros - Tipos de Log
                txtLegendaPai = "Cadastros"; txtLegenda = "Tipos de Log"; txtURL = "AplicacaoTipoLog/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Alertas
                txtLegendaPai = "Cadastros"; txtLegenda = "Alertas"; txtURL = "#"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Alertas - Grupos
                txtLegendaPai = "Alertas"; txtLegenda = "Grupos"; txtURL = "alertagrupo/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Alertas - Tipos de Alertas
                txtLegendaPai = "Alertas"; txtLegenda = "Tipos de Alertas"; txtURL = "alertatipos/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Alertas - Mensagens
                txtLegendaPai = "Alertas"; txtLegenda = "Mensagens"; txtURL = "alertamensagem/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);
                #endregion


                #region --|Consultas|--
                /// Geral - Consultas
                txtLegendaPai = "Geral"; txtLegenda = "Consultas"; txtURL = "#"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "<i class=\"fa fa-edit\"></i>";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Logs
                txtLegendaPai = "Consultas"; txtLegenda = "Log & Alertas"; txtURL = "ConsultaLog/index"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Clientes
                txtLegendaPai = "Consultas"; txtLegenda = "Empresas"; txtURL = "#"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Fornecedores
                txtLegendaPai = "Consultas"; txtLegenda = "Aplicação"; txtURL = "#"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Cadastros - Alertas
                txtLegendaPai = "Consultas"; txtLegenda = "Alertas"; txtURL = "#"; txtTooltip = string.Format("{0} - {1}", txtLegendaPai, txtLegenda); Ordem = 1; txtEstilo = "";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                #endregion


                #region --|Relatorios|--
                /////// Geral - Relatórios
                ////txtLegendaPai = ""; txtLegenda = "Relatórios"; txtURL = "#"; txtTooltip = "Relatórios"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = true; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /////// Geral - Fiscal
                ////txtLegendaPai = "Relatórios"; txtLegenda = "Produtos."; txtURL = "#"; txtTooltip = "Geral - Fiscal"; Ordem = 1; txtEstilo = "<i class=\"fa fa-print\"></i>";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /////// Geral - Fiscal - Emissão Nota Fiscal
                ////txtLegendaPai = "Produtos."; txtLegenda = "Lista de Preços"; txtURL = "#"; txtTooltip = "Lista de Preços"; Ordem = 1; txtEstilo = "";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                #endregion


                #region --|Administração|--

                /////// Geral - Administração
                ////txtLegendaPai = ""; txtLegenda = "Administração"; txtURL = "#"; txtTooltip = "Administração"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = true; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /////// Geral - Administração - Configuração
                ////txtLegendaPai = "Administração"; txtLegenda = "Configuração"; txtURL = "#"; txtTooltip = "Administração - Configuração"; Ordem = 1; txtEstilo = "<i class=\"fa fa-sitemap\"></i>";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /////// Geral - Administração - Configuração - Perfil de Usuário
                ////txtLegendaPai = "Configuração"; txtLegenda = "Perfil de Usuário"; txtURL = "PerfilAcesso/Index"; txtTooltip = "Configuração - Perfil"; Ordem = 1; txtEstilo = "";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /////// Geral - Administração - Configuração - Parametrização
                ////txtLegendaPai = "Configuração"; txtLegenda = "Parametrização"; txtURL = "Parametros/Index"; txtTooltip = "Configuração - Perfil"; Ordem = 1; txtEstilo = "";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /////// Geral - Administração - Configuração
                ////txtLegendaPai = "Administração"; txtLegenda = "Log"; txtURL = "#"; txtTooltip = "Log"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bug\"></i>";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                ////txtLegendaPai = "Log"; txtLegenda = "Acesso"; txtURL = "SistemaLog/Acesso"; txtTooltip = "Log"; Ordem = 1; txtEstilo = "";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                ////txtLegendaPai = "Log"; txtLegenda = "Operações"; txtURL = "SistemaLog/operacoes"; txtTooltip = "Log"; Ordem = 1; txtEstilo = "";
                ////Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                #endregion


                #region --|Suporte|--
                /// Suporte
                txtLegendaPai = ""; txtLegenda = "Suporte"; txtURL = "#"; txtTooltip = "Suporte"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = true; Item.flg_header = true; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);

                /// Geral - Fiscal
                txtLegendaPai = "Suporte"; txtLegenda = "Chamado Tecnico"; txtURL = "#"; txtTooltip = "Chamado Tecnico"; Ordem = 1; txtEstilo = "<i class=\"fa fa-print\"></i>";
                Item = new SistemaMenu(); Item.ds_legenda = txtLegenda; Item.ds_tooltip = txtTooltip; Item.ds_URL = txtURL; Item.ordem_exibicao = Ordem; Item.nm_estilo = txtEstilo; Item.nm_target = "_Parent"; Item.flg_temfilho = false; Item.flg_header = false; Item.flg_ativo = true; Item.id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1; Item.id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu; _retorno.Add(Item);
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return _retorno.ToList(); // .OrderBy(c => c.IdPai).OrderBy(c => c.Ordem).ToList();

        }
        public static List<SistemaMenu> getMenuScaa(List<PM.SCAA.Listas.Modulo> oResp)
        {
            List<SistemaMenu> _retorno = new List<SistemaMenu>();
            SistemaMenu Item = new SistemaMenu();

            try
            {
                oResp = oResp.OrderBy(C => C._nr_ordem).ToList();

                string txtLegendaPai = ""; string txtLegenda = ""; string txtTooltip = ""; string txtURL = ""; string txtEstilo = ""; int Ordem = 0; string txtControle = ""; string txtAction = ""; bool flgFilho = false; bool flgAtivo = false;
                foreach (PM.SCAA.Listas.Modulo oItem in oResp.ToList())
                {
                    txtLegendaPai = oItem._nr_sub_modulo.Trim().Equals("0") ? "" : oResp.Where(c => c._nr_modulo.Equals(oItem._nr_sub_modulo)).ToList()[0]._nm_modulo;
                    txtLegenda = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oItem._nm_modulo.ToString());
                    txtTooltip = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oItem._ds_modulo.ToString());
                    txtEstilo = oItem._url_imagem.Trim().Length.Equals(0) ? "" : string.Format("<i class=\"{0}\"></i>", oItem._url_imagem);
                    txtURL = oItem._permissao.Count.Equals(0) ? "#" : string.Format("/{0}/{1}", txtControle, txtAction);
                    flgFilho = !oResp.Where(c => int.Parse(c._nr_sub_modulo).Equals(int.Parse(oItem._nr_modulo))).ToList().Count.Equals(0);
                    flgAtivo = oItem._ativo;
                    SistemaMenu Item1 = new SistemaMenu()
                    {
                        ds_legenda = txtLegenda,
                        ds_tooltip = txtTooltip,
                        ds_URL = txtURL,
                        ordem_exibicao = Ordem,
                        nm_estilo = txtEstilo,
                        nm_target = "_Parent",
                        flg_temfilho = flgFilho,
                        flg_header = false,
                        flg_ativo = flgAtivo,
                        id_menu = int.Parse(oItem._nr_modulo.ToString()), //   _retorno.Count().Equals(0) ? int.Parse(oItem._nr_modulo.ToString()) : _retorno.Count() + 1,
                        id_pai = int.Parse(oItem._nr_sub_modulo),
                        //id_pai = _retorno.Where(c => c.ds_legenda.ToUpper().Equals(txtLegendaPai.ToUpper())).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.ToUpper().Equals(txtLegendaPai.ToUpper())).ToList()[0].id_menu,
                    };
                    if (flgFilho.Equals(false) && !oItem._permissao.Count.Equals(0))
                    {
                        Item1.ds_URL = oItem._permissao[0]._acao[0]._valor;
                        _retorno.Add(Item1);
                    }
                    else
                    if (flgFilho.Equals(true))
                    {
                        List<PM.SCAA.Listas.Modulo> _ret = oResp.Where(c => int.Parse(c._nr_sub_modulo).Equals(int.Parse(oItem._nr_modulo))).ToList();
                        bool temPermissao = false;

                        if (txtLegenda.ToUpper().Equals("GERAL")) { temPermissao = true; }
                        else
                        {
                            do
                            {
                                foreach (PM.SCAA.Listas.Modulo Permissao in _ret.ToList())
                                {
                                    var x = oResp.Where(c => int.Parse(c._nr_sub_modulo).Equals(int.Parse(Permissao._nr_modulo))).ToList();
                                    if (!x.ToList().Count.Equals(0))
                                    {
                                        foreach (PM.SCAA.Listas.Modulo PermissaoY in x.ToList())
                                        {
                                            if (!PermissaoY._permissao.Count.Equals(0))
                                            {
                                                temPermissao = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!Permissao._permissao.Count.Equals(0))
                                        {

                                            temPermissao = true;
                                            break;
                                        }
                                    }
                                }
                                break;
                            } while (!temPermissao);
                        }
                        if (temPermissao)
                        {
                            _retorno.Add(Item1);
                        }
                    }

                }

                /// Excluir todos os pais que tenham filhos sem ação
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                //List<SistemaMenu> TodosOsFilhos = _retorno.Where(x => x.id_pai == x.id_menu || x.id_menu.Equals(0)).ToList();


                //_retorno = TodosOsFilhos;
            }


            return _retorno.ToList().OrderBy(c => c.id_pai).OrderBy(c => c.ordem_exibicao).ToList();
        }

        public static string getMontaMenu(List<SistemaMenu> lstMenu)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            bool flgFechaObjetos = false;
            bool flgprimeiro = false;
            //string LegendaAnterior = "";
            try
            {
                oStringBuilder.AppendFormat("<div id=\"sidebar-menu\" class=\"main_menu_side hidden-print main_menu\"> \n");

                foreach (SistemaMenu Nivel_00 in lstMenu.Where(c => c.id_pai.Equals(0)).ToList())
                {
                    flgFechaObjetos = false;
                    oStringBuilder.AppendFormat("   <div class=\"menu_section\"> \n");
                    oStringBuilder.AppendFormat("       <h3>{0}</h3> \n", Nivel_00.ds_legenda.ToString());
                    oStringBuilder.AppendFormat("       <ul class=\"nav side-menu\"> \n");
                    if (Nivel_00.flg_temfilho)
                    {
                        oStringBuilder.AppendFormat(getMontaMenuItem(lstMenu.ToList(), Nivel_00.id_menu));
                    }
                    else
                    {
                        oStringBuilder.AppendFormat("<li><a href=\"/{0}\" target=\"{1}\" title=\"{2}\" class=\"\">{3}</a></li>", Nivel_00.ds_URL, Nivel_00.nm_target, Nivel_00.ds_tooltip, Nivel_00.ds_legenda);
                    }
                    oStringBuilder.AppendFormat("       </ul>\n");
                    oStringBuilder.AppendFormat("   </div> \n");
                    flgprimeiro = true;
                }
                oStringBuilder.AppendFormat("</div> \n");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return oStringBuilder.ToString();
        }

        private static string getMontaMenuItem(List<SistemaMenu> lstMenu, int _IdPai)
        {
            List<SistemaMenu> lstProcessamento = new List<SistemaMenu>();
            lstProcessamento = lstMenu.Where(c => c.id_pai.Equals(_IdPai)).OrderBy(c => c.ordem_exibicao).ToList();

            System.Text.StringBuilder oStringBuilderFilho = new System.Text.StringBuilder();

            foreach (SistemaMenu Item in lstProcessamento.ToList())
            {
                if (Item.flg_temfilho)
                {
                    oStringBuilderFilho.AppendFormat("<li>");
                    oStringBuilderFilho.AppendFormat("  <a> {0} {1}<span class=\"fa fa-chevron-down\"></span></a> \n", Item.nm_estilo, Item.ds_legenda);
                    oStringBuilderFilho.AppendFormat("  <ul class=\"nav child_menu\"> \n");
                    oStringBuilderFilho.AppendFormat(getMontaMenuItem(lstMenu, Item.id_menu));
                    oStringBuilderFilho.AppendFormat("  </ul> \n");
                    oStringBuilderFilho.AppendFormat("</li>");
                }
                else
                {
                    oStringBuilderFilho.AppendFormat("<li><a href=\"/{0}\" target=\"{1}\" title=\"{2}\" class=\"\">{4} {3}</a></li>", Item.ds_URL, Item.nm_target, Item.ds_tooltip, Item.ds_legenda, Item.nm_estilo);
                }
            }
            return oStringBuilderFilho.ToString();
        }
    }
}