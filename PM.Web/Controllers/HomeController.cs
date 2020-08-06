using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace PM.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ViewBag.Title = "Home Page";
                if (1 == 2)
                {
                    PM.IntegradorSAP.Model.ModelEquipamentoFixo modelEquipamentoFixo = new IntegradorSAP.Model.ModelEquipamentoFixo();
                    PM.IntegradorSAP.Model.ModelEquipamentoFixoDadosLineares fixoDadosLineares = new IntegradorSAP.Model.ModelEquipamentoFixoDadosLineares();
                    PM.IntegradorSAP.Model.ModelEquipamentoFixoMedidas equipamentoFixoMedidas = new IntegradorSAP.Model.ModelEquipamentoFixoMedidas();
                    List<PM.IntegradorSAP.Helper.Resposta> respostaEquipamentoFixo;
                    IntegradorSAP.EquipamentoFixo oEquipamentoFixo = new IntegradorSAP.EquipamentoFixo();
                    modelEquipamentoFixo.Centro = "";
                    modelEquipamentoFixo.CentroTrabalho = "";
                    modelEquipamentoFixo.Code = "";
                    modelEquipamentoFixo.DadosLineares.Add(fixoDadosLineares);
                    modelEquipamentoFixo.Descricao = "";
                    modelEquipamentoFixo.GrpCode = "";
                    modelEquipamentoFixo.IncidenteNotavel = "";
                    modelEquipamentoFixo.LocInstalacao = "";
                    modelEquipamentoFixo.Medida.Add(equipamentoFixoMedidas);
                    modelEquipamentoFixo.Notificador = "";
                    modelEquipamentoFixo.Observacao = "";
                    modelEquipamentoFixo.Prioridade = "";
                    modelEquipamentoFixo.StatusNota = "";
                    modelEquipamentoFixo.TipoNota = "";
                    respostaEquipamentoFixo = oEquipamentoFixo.CriacaoNota("desenvolvimento", modelEquipamentoFixo);
                }
                if (1 == 2)
                {
                    PM.IntegradorSAP.Model.ModelMaterialRodante modelMaterialRodante = new IntegradorSAP.Model.ModelMaterialRodante();
                    PM.IntegradorSAP.Model.ModelMaterialRodanteMedida modelMaterialRodanteMedida = new IntegradorSAP.Model.ModelMaterialRodanteMedida();
                    IntegradorSAP.MaterialRodante oMaterialRodante = new IntegradorSAP.MaterialRodante();
                    modelMaterialRodanteMedida = new IntegradorSAP.Model.ModelMaterialRodanteMedida();
                    modelMaterialRodanteMedida.ItemMedia = "0001";
                    modelMaterialRodanteMedida.CodMedidas = "ABER";
                    modelMaterialRodanteMedida.DataInicio = "20190603";
                    modelMaterialRodanteMedida.DataProgramanda = "20190610";
                    modelMaterialRodanteMedida.FuncResposavel = "ZA";
                    modelMaterialRodanteMedida.GrpCodMedidas = "STATUS";
                    modelMaterialRodanteMedida.HoraInicio = "120701";
                    modelMaterialRodanteMedida.HoraProgramada = "083000";
                    modelMaterialRodanteMedida.Responsavel = "MRNC";
                    modelMaterialRodanteMedida.RGLogado = "e008466";
                    modelMaterialRodanteMedida.StatusMedida = "MEDL";

                    modelMaterialRodante.Medida.Add(modelMaterialRodanteMedida);
                    modelMaterialRodanteMedida = new IntegradorSAP.Model.ModelMaterialRodanteMedida();
                    modelMaterialRodanteMedida.ItemMedia = "0002";
                    modelMaterialRodanteMedida.CodMedidas = "ABER";
                    modelMaterialRodanteMedida.DataInicio = "20190606";
                    modelMaterialRodanteMedida.DataProgramanda = "20190616";
                    modelMaterialRodanteMedida.FuncResposavel = "ASILVESTRE";
                    modelMaterialRodanteMedida.GrpCodMedidas = "STATUS";
                    modelMaterialRodanteMedida.HoraInicio = "101501";
                    modelMaterialRodanteMedida.HoraProgramada = "133045";
                    modelMaterialRodanteMedida.Responsavel = "MRNC";
                    modelMaterialRodanteMedida.RGLogado = "e008466";
                    modelMaterialRodanteMedida.StatusMedida = "MEDL";
                    modelMaterialRodante.Medida.Add(modelMaterialRodanteMedida);

                    List<PM.IntegradorSAP.Helper.Resposta> respostaMaterialRodante;
                    modelMaterialRodante.Centro = "PPAT";
                    modelMaterialRodante.CentroTrabalho = "MRNC";
                    modelMaterialRodante.Code = "0107";
                    modelMaterialRodante.Descricao = "Nota Criada - Não apagar esta nota";
                    modelMaterialRodante.Fumaca = "FUMA";
                    modelMaterialRodante.GrpCode = "1FRE";
                    modelMaterialRodante.IncidenteNotavel = "INCN";
                    modelMaterialRodante.InterOperacional = "MKB5";
                    modelMaterialRodante.Linha = "01 - LINHA 1";
                    modelMaterialRodante.Local = "V";
                    modelMaterialRodante.LocInstalacao = "M-F0E-E01-E011";
                    modelMaterialRodante.Notificador = "22022";
                    modelMaterialRodante.Observacao = "Não apagar esta nota - Não apagar esta nota - Não apagar esta nota - Não apagar esta nota";
                    modelMaterialRodante.Prioridade = "A";
                    modelMaterialRodante.StatusNota = "ABER";
                    modelMaterialRodante.StatusUsuario = "";
                    modelMaterialRodante.TipoManutencao = "";
                    modelMaterialRodante.TipoNota = "MC";
                    respostaMaterialRodante = oMaterialRodante.CriacaoNota("DESENVOLVIMENTO", modelMaterialRodante);
                }
                if (1 == 2)
                {
                    PM.IntegradorSAP.Model.ModelPericiaCopese modelPericiaCopese = new IntegradorSAP.Model.ModelPericiaCopese();
                    PM.IntegradorSAP.Model.ModelPericiaCopeseAtividade modelPericiaCopeseAtividade = new IntegradorSAP.Model.ModelPericiaCopeseAtividade();
                    PM.IntegradorSAP.Model.ModelPericiaCopeseCausa modelPericiaCopeseCausa = new IntegradorSAP.Model.ModelPericiaCopeseCausa();
                    PM.IntegradorSAP.Model.ModelPericiaCopeseMedida modelPericiaCopeseMedida = new IntegradorSAP.Model.ModelPericiaCopeseMedida();
                    PM.IntegradorSAP.PericiaCopese oPericiaCopese = new IntegradorSAP.PericiaCopese();
                    List<PM.IntegradorSAP.Helper.Resposta> respostaPericiaCopese;



                    modelPericiaCopeseMedida.CodMedidas = "";
                    modelPericiaCopeseMedida.DataMedida = "";
                    modelPericiaCopeseMedida.DataProgramanda = "";
                    modelPericiaCopeseMedida.FuncResposavel = "";
                    modelPericiaCopeseMedida.GrpCodMedidas = "";
                    modelPericiaCopeseMedida.HoraMedida = "";
                    modelPericiaCopeseMedida.HoraProgramada = "";
                    modelPericiaCopeseMedida.ItemMedia = "";
                    modelPericiaCopeseMedida.Responsavel = "";
                    modelPericiaCopeseMedida.RGLogado = "";
                    modelPericiaCopeseMedida.StatusMedida = "";
                    modelPericiaCopese.Medida.Add(modelPericiaCopeseMedida);

                    modelPericiaCopeseAtividade.CodAtividades = "";
                    modelPericiaCopese.Atividade.Add(modelPericiaCopeseAtividade);




                    modelPericiaCopese.Code = "";
                    modelPericiaCopese.Descricao = "";
                    modelPericiaCopese.GrpCode = "";
                    modelPericiaCopese.LocInstalacao = "";

                    modelPericiaCopese.Causa.Add(modelPericiaCopeseCausa);

                    modelPericiaCopese.NotaReferencia = "";
                    modelPericiaCopese.Notificador = "";
                    modelPericiaCopese.Observacao = "";
                    modelPericiaCopese.StatusNota = "";
                    modelPericiaCopese.StatusUsuario = "";
                    modelPericiaCopese.TipoNota = "";
                    respostaPericiaCopese = oPericiaCopese.CriacaoNota("DESENVOLVIMENTO", modelPericiaCopese);
                    foreach (PM.IntegradorSAP.Helper.Resposta item in respostaPericiaCopese)
                    {
                        if (item._status == true)
                        {
                            string minhanota = item._codMensagem;
                        }
                    }




                }
                if (1 == 2)
                {
                    PM.IntegradorSAP.Model.ModelPesquisarNotas modelPesquisarNota = new IntegradorSAP.Model.ModelPesquisarNotas();
                    PM.IntegradorSAP.PesquisarNota oPesquisarNota = new IntegradorSAP.PesquisarNota();
                    List<PM.IntegradorSAP.Helper.RespostaNotas> respostaPesquisarNota;
                    string Nota = "000150000002";
                    modelPesquisarNota.TipoNota = "MC";
                    //modelPesquisarNota.DataDe       = "20190501";
                    //modelPesquisarNota.DataAte      = "20190522";
                    modelPesquisarNota.NumeroNota = Nota;
                    respostaPesquisarNota = oPesquisarNota.Pesquisar("DESENVOLVIMENTO", modelPesquisarNota);
                }
            }
            catch (Exception ex)
            {
                var retorno = PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }

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

            string saida = String.Empty;

            if (bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsManagerScaa"].ToString()))
            {
                PM.SCAA.SharpScaa.Resposta oResposta = new SCAA.SharpScaa.Resposta();
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
                }
            }
            else
            {
                saida = Menu.getMontaMenu(Menu.GeraDados());
            }

            return saida.ToString();
        }

        public string AdminAlerta()
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            oStringBuilder.AppendFormat(" \n");
            oStringBuilder.AppendFormat("<li class=\"nav-item dropdown\"> \n");
            oStringBuilder.AppendFormat("	<a class=\"nav-link\" href=\"#\" id=\"navbarDropdownMenuLink\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"true\"> \n");
            oStringBuilder.AppendFormat("		<i class=\"material-icons\">notifications</i> \n");
            oStringBuilder.AppendFormat("		<span class=\"notification\">10</span> \n");
            oStringBuilder.AppendFormat("	</a> \n");
            oStringBuilder.AppendFormat("	<div class=\"dropdown-menu dropdown-menu-right \" aria-labelledby=\"navbarDropdownMenuLink\"> \n");

            for (int nCont = 0; nCont <= 10; nCont++)
            {
                oStringBuilder.AppendFormat("		<a href=\"#\" class=\"dropdown-item .alerta-modal\" data-toggle=\"modal\" data-target=\"#alerta-modal\" data-id=\"{0}\" title=\"Alerta enviado em {1}\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nisi nibh, venenatis a urna id.</a> \n", (nCont + 100), "20/05/2019 14:45:38");
            }

            oStringBuilder.AppendFormat("		<hr /> \n");
            oStringBuilder.AppendFormat("		<a href=\"#\" class=\"dropdown-item\">Ver Todos</a> \n");
            oStringBuilder.AppendFormat("	</div> \n");
            oStringBuilder.AppendFormat("</li> \n");
            oStringBuilder.AppendFormat(" \n");

            return oStringBuilder.ToString();
        }
    }

    [Authorize]
    public static class Menu
    {
        public static List<MenuSistema> GeraDados()
        {
            List<MenuSistema> _retorno = new List<MenuSistema>();
            MenuSistema Item = new MenuSistema();
            try
            {
                string txtLegendaPai = ""; string txtLegenda = ""; string txtURL = ""; string txtTooltip = ""; string txtEstilo = ""; int Ordem = 0;

                /// Geral
                txtLegendaPai = ""; txtLegenda = "Geral"; txtURL = "#"; txtTooltip = "Geral"; Ordem = 1;
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = true,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Inicio
                txtLegendaPai = "Geral"; txtLegenda = "Inicio"; txtURL = "home/index"; txtTooltip = "Tela inicial"; Ordem = 1; txtEstilo = "<i class=\"fa fa-home\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Empresas
                txtLegendaPai = "Geral"; txtLegenda = "Empresas"; txtURL = "#"; txtTooltip = "Geral - Empresas"; Ordem = 1; txtEstilo = "<i class=\"fa fa-edit\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Empresas - Clientes
                txtLegendaPai = "Empresas"; txtLegenda = "Clientes"; txtURL = "#"; txtTooltip = "Geral - Empresas"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Empresas - Fornecedores
                txtLegendaPai = "Empresas"; txtLegenda = "Fornecedores"; txtURL = "#"; txtTooltip = "Geral - Fornecedores"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);


                /// Geral - Produtos
                txtLegendaPai = "Geral"; txtLegenda = "Produtos"; txtURL = "#"; txtTooltip = "Geral - Produtos"; Ordem = 1; txtEstilo = "<i class=\"fa fa-shopping-cart\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Produtos - Categorias
                txtLegendaPai = "Produtos"; txtLegenda = "Categorias"; txtURL = "#"; txtTooltip = "Produtos - Categorias"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Produtos - Produtos
                txtLegendaPai = "Produtos"; txtLegenda = "Produtos"; txtURL = "#"; txtTooltip = "Produtos - Categorias"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);


                /// Geral - Movimentação
                txtLegendaPai = "Geral"; txtLegenda = "Movimentação"; txtURL = "#"; txtTooltip = "Geral - Movimentação"; Ordem = 1; txtEstilo = "<i class=\"fa fa-pie-chart\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Movimentação - Orçamentos
                txtLegendaPai = "Movimentação"; txtLegenda = "Orçamentos"; txtURL = "#"; txtTooltip = "Movimentação - Orçamentos"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Movimentação - Estoque
                txtLegendaPai = "Movimentação"; txtLegenda = "Estoque"; txtURL = "#"; txtTooltip = "Movimentação - Estoques"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);


                /// Geral - Financeiro
                txtLegendaPai = "Geral"; txtLegenda = "Financeiro"; txtURL = "#"; txtTooltip = "Geral - Financeiro"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Financeiro - Caixa
                txtLegendaPai = "Financeiro"; txtLegenda = "Caixa"; txtURL = "#"; txtTooltip = "Financeiro - Caixa"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Financeiro - Caixa - Abertura/Fechamento
                txtLegendaPai = "Caixa"; txtLegenda = "Abertura/Fechamento"; txtURL = "#"; txtTooltip = "Financeiro - Abertura Caixa"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Financeiro - Caixa - Sangria
                txtLegendaPai = "Caixa"; txtLegenda = "Sangria"; txtURL = "#"; txtTooltip = "Financeiro - Sangria"; Ordem = 3; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Financeiro - Cotação
                txtLegendaPai = "Caixa"; txtLegenda = "Cotação"; txtURL = "#"; txtTooltip = "Geral - Cotação"; Ordem = 2; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal
                txtLegendaPai = "Geral"; txtLegenda = "Fiscal"; txtURL = "#"; txtTooltip = "Geral - Fiscal"; Ordem = 1; txtEstilo = "<i class=\"fa fa-cogs\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal - Emissão Nota Fiscal
                txtLegendaPai = "Fiscal"; txtLegenda = "Emissão Nota Fiscal"; txtURL = "#"; txtTooltip = "Fiscal - Emissão nota Fiscal"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal - Importacao Nota Fiscal
                txtLegendaPai = "Fiscal"; txtLegenda = "Importar Nota Fiscal"; txtURL = "#"; txtTooltip = "Fiscal - Importar nota Fiscal"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - PDV
                txtLegendaPai = "Geral"; txtLegenda = "PDV"; txtURL = "#"; txtTooltip = "Geral - PDV"; Ordem = 1; txtEstilo = "<i class=\"fa fa-credit-card\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);


                /// Geral - Relatórios
                txtLegendaPai = ""; txtLegenda = "Relatórios"; txtURL = "#"; txtTooltip = "Relatórios"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = true,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal
                txtLegendaPai = "Relatórios"; txtLegenda = "Produtos."; txtURL = "#"; txtTooltip = "Geral - Fiscal"; Ordem = 1; txtEstilo = "<i class=\"fa fa-print\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal - Emissão Nota Fiscal
                txtLegendaPai = "Produtos."; txtLegenda = "Lista de Preços"; txtURL = "#"; txtTooltip = "Lista de Preços"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal - Importacao Nota Fiscal
                txtLegendaPai = "Produtos."; txtLegenda = "Posição de Estoque"; txtURL = "#"; txtTooltip = "Posição de Estoque"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);


                /// Geral - Administração
                txtLegendaPai = ""; txtLegenda = "Administração"; txtURL = "#"; txtTooltip = "Administração"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = true,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Administração - Configuração
                txtLegendaPai = "Administração"; txtLegenda = "Configuração"; txtURL = "#"; txtTooltip = "Administração - Configuração"; Ordem = 1; txtEstilo = "<i class=\"fa fa-sitemap\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Administração - Configuração - Perfil de Usuário
                txtLegendaPai = "Configuração"; txtLegenda = "Perfil de Usuário"; txtURL = "PerfilAcesso/Index"; txtTooltip = "Configuração - Perfil"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Administração - Configuração - Parametrização
                txtLegendaPai = "Configuração"; txtLegenda = "Parametrização"; txtURL = "Parametros/Index"; txtTooltip = "Configuração - Perfil"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Administração - Configuração
                txtLegendaPai = "Administração"; txtLegenda = "Log"; txtURL = "#"; txtTooltip = "Log"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bug\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                txtLegendaPai = "Log"; txtLegenda = "Acesso"; txtURL = "SistemaLog/Acesso"; txtTooltip = "Log"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                txtLegendaPai = "Log"; txtLegenda = "Operações"; txtURL = "SistemaLog/operacoes"; txtTooltip = "Log"; Ordem = 1; txtEstilo = "";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);


                /// Suporte
                txtLegendaPai = ""; txtLegenda = "Suporte"; txtURL = "#"; txtTooltip = "Suporte"; Ordem = 1; txtEstilo = "<i class=\"fa fa-bar-chart-o\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = true,
                    flg_header = true,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);

                /// Geral - Fiscal
                txtLegendaPai = "Suporte"; txtLegenda = "Chamado Tecnico"; txtURL = "#"; txtTooltip = "Chamado Tecnico"; Ordem = 1; txtEstilo = "<i class=\"fa fa-print\"></i>";
                Item = new MenuSistema
                {
                    ds_legenda = txtLegenda,
                    ds_tooltip = txtTooltip,
                    ds_URL = txtURL,
                    ordem_exibicao = Ordem,
                    nm_estilo = txtEstilo,
                    nm_target = "_Parent",
                    flg_temfilho = false,
                    flg_header = false,
                    flg_ativo = true,
                    id_menu = _retorno.Count().Equals(0) ? 1 : _retorno.Count() + 1,
                    id_pai = _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList().Count.Equals(0) ? 0 : _retorno.Where(c => c.ds_legenda.Equals(txtLegendaPai)).ToList()[0].id_menu
                }; _retorno.Add(Item);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _retorno.ToList(); // .OrderBy(c => c.IdPai).OrderBy(c => c.Ordem).ToList();

        }
        public static List<MenuSistema> getMenuScaa(List<PM.SCAA.Listas.Modulo> oResp)
        {
            List<MenuSistema> _retorno = new List<MenuSistema>();
            MenuSistema Item = new MenuSistema();

            try
            {
                oResp = oResp.OrderBy(C => C._nr_ordem).ToList();

                string txtLegendaPai = String.Empty;
                string txtLegenda = String.Empty;
                string txtTooltip = String.Empty;
                string txtURL = String.Empty;
                string txtEstilo = String.Empty;
                string txtControle = String.Empty;
                string txtAction = String.Empty;
                bool flgFilho = false;
                bool flgAtivo = false;
                int Ordem = 0;

                foreach (PM.SCAA.Listas.Modulo oItem in oResp.ToList())
                {
                    txtLegendaPai = oItem._nr_sub_modulo.Trim().Equals("0") ? "" : oResp.Where(c => c._nr_modulo.Equals(oItem._nr_sub_modulo)).ToList()[0]._nm_modulo;
                    txtLegenda = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oItem._nm_modulo.ToString());
                    txtTooltip = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(oItem._ds_modulo.ToString());
                    txtEstilo = oItem._url_imagem.Trim().Length.Equals(0) ? "" : string.Format("<i class=\"{0}\"></i>", oItem._url_imagem);
                    txtURL = oItem._permissao.Count.Equals(0) ? "#" : string.Format("/{0}/{1}", txtControle, txtAction);
                    flgFilho = !oResp.Where(c => int.Parse(c._nr_sub_modulo).Equals(int.Parse(oItem._nr_modulo))).ToList().Count.Equals(0);
                    flgAtivo = oItem._ativo;

                    MenuSistema Item1 = new MenuSistema()
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
                    else if (flgFilho.Equals(true))
                    {
                        List<PM.SCAA.Listas.Modulo> _ret = oResp.Where(c => int.Parse(c._nr_sub_modulo).Equals(int.Parse(oItem._nr_modulo))).ToList();
                        bool temPermissao = false;

                        if (txtLegenda.ToUpper().Equals("GERAL"))
                        {
                            temPermissao = true;
                        }
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

            return _retorno.ToList().OrderBy(c => c.id_pai).OrderBy(c => c.ordem_exibicao).ToList();
        }

        public static string getMontaMenu(List<MenuSistema> lstMenu)
        {
            //Todo: Quando definido corretamente no SCAA, comentar linha abaixo
            lstMenu = (List<MenuSistema>)Util.DeserializeMenu(lstMenu.GetType());

            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();

            try
            {
                if (true)
                {
                    foreach (MenuSistema Nivel_00 in lstMenu.Where(c => c.id_pai.Equals(0)).ToList())
                    {
                        oStringBuilder.AppendFormat("   <div class=\"menu_section\">");
                        oStringBuilder.AppendFormat("       <ul class=\"nav menu-section-body\">");

                        if (Nivel_00.flg_temfilho)
                        {
                            oStringBuilder.AppendFormat(getMontaMenuItem(lstMenu.ToList(), Nivel_00.id_menu));
                        }
                        else
                        {
                            oStringBuilder.AppendFormat("<li><a href=\"/{0}\" target=\"{1}\" title=\"{2}\" class=\"\">{3}</a></li>", Nivel_00.ds_URL, Nivel_00.nm_target, Nivel_00.ds_tooltip, Nivel_00.ds_legenda);
                        }

                        oStringBuilder.AppendFormat("       </ul>");
                        oStringBuilder.AppendFormat("   </div>");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return oStringBuilder.ToString();
        }

        private static string getMontaMenuItem(List<MenuSistema> lstMenu, int _IdPai)
        {
            List<MenuSistema> lstProcessamento = new List<MenuSistema>();
            lstProcessamento = lstMenu.Where(c => c.id_pai.Equals(_IdPai)).OrderBy(c => c.ordem_exibicao).ToList();

            System.Text.StringBuilder oStringBuilderFilho = new System.Text.StringBuilder();

            foreach (MenuSistema Item in lstProcessamento.ToList())
            {
                if (Item.flg_temfilho)
                {
                    oStringBuilderFilho.AppendFormat("<li>");
                    oStringBuilderFilho.AppendFormat("  <a>{0} {1}<span class=\"fa fa-chevron-down\"></span></a>", Item.nm_estilo, Item.ds_legenda);
                    oStringBuilderFilho.AppendFormat("  <ul class=\"nav child_menu\">");
                    oStringBuilderFilho.AppendFormat(getMontaMenuItem(lstMenu, Item.id_menu));
                    oStringBuilderFilho.AppendFormat("  </ul>");
                    oStringBuilderFilho.AppendFormat("</li>");
                }
                else
                {
                    oStringBuilderFilho.AppendFormat("<li><a href=\"/{0}\" target=\"{1}\" title=\"{2}\">{4} {3}</a></li>", Item.ds_URL, Item.nm_target, Item.ds_tooltip, Item.ds_legenda, Item.nm_estilo);
                }
            }

            return oStringBuilderFilho.ToString();
        }
    }

    public class RespostaServico
    {
        public bool _status { get; set; }
        public string _codMensagem { get; set; }
        public string _mensagem { get; set; }
        public RespostaServico()
        {

        }
    }
}
