using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PM.Web.ViewModel;

namespace PM.Web.Controllers
{
    public class ApontarNOLsController : BaseController
    {
        public ActionResult Criar()
        {
            ApontarNOLViewModel telaVM = CarregarViewBags(new ApontarNOLViewModel());
            return View(telaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "Salvar", Argument = "Salvar")]
        //public async Task<ActionResult> Editar([Bind(Include = "Imovel")] TelaManutencaoCorretivaViewModel telaVM)
        public ActionResult Criar(ApontarNOLViewModel telaVM)
        {
            //HttpFileCollection uploadedFiles = System.Web.HttpContext.Current.Request.Files;
            //imovelVM.ImovelArquivos = new List<ImovelArquivo>();

            //for (int i = 0; i < uploadedFiles.Count; i++)
            //{
            //    System.Web.HttpPostedFile file = uploadedFiles[i];
            //    if (file != null && file.ContentLength != 0)
            //    {
            //        imovelVM.ImovelArquivos.Add(new ImovelArquivo
            //        {
            //            ImovelID = imovelVM.Imovel.ImovelID,
            //            Sequencia = i + 1,
            //            NomeArquivo = file.FileName,
            //            Extensao = file.FileName.Substring((file.FileName.Length - 4)),
            //            ContentType = file.ContentType,
            //            ArquivoByte = UploadFileInDataBase(file),
            //            UsuarioCriacaoID = UsuarioCookie.UsuarioLogado().UsuarioID.Value,
            //            DataCriacao = DateTime.Now,
            //            UsuarioAlteracaoId = UsuarioCookie.UsuarioLogado().UsuarioID.Value,
            //            DataAlteracao = DateTime.Now
            //        });
            //    }
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        imovelVM.Imovel.UsuarioCriacaoID = UsuarioCookie.UsuarioLogado().UsuarioID.Value;
            //        imovelVM.Imovel.DataCriacao = DateTime.Now;
            //        imovelVM.Imovel.UsuarioAlteracaoId = UsuarioCookie.UsuarioLogado().UsuarioID;
            //        imovelVM.Imovel.DataAlteracao = DateTime.Now;
            //        imovelVM.EmpresaConectadaID = UsuarioCookie.EmpresaLogada().EmpresaID.Value;

            //        if (imovelVM.Imovel.ImovelID == 0)
            //        {
            //            ImovelViewModel serviceImovelVM;
            //            bool erro = true;

            //            serviceImovelVM = await new ImovelServices().PostAsync(imovelVM);
            //            erro = serviceImovelVM.Erro.Value;

            //            if (erro)
            //            {
            //                Danger("Ocorreu um erro na gravação da Imovel. Tente novamente mais tarde, se o erro persistir, contate o responável", true);
            //                return View(imovelVM);
            //            }
            //            else
            //            {
            //                Success("Empresa cadastrada com sucesso.", true);
            //            }
            //        }
            //        else
            //        {
            //            var serviceImovelVM = await new ImovelServices().PostAsync(imovelVM);

            //            if (serviceImovelVM.Erro.Value)
            //            {
            //                Danger("Ocorreu um erro na gravação da Imovel. Tente novamente mais tarde, se o erro persistir, contate o responável", true);
            //                return View(imovelVM);
            //            }
            //            else
            //            {
            //                Success("Imovel alterada com sucesso.", true);
            //            }
            //        }
            //        return RedirectToAction("Lista");
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}

            telaVM = CarregarViewBags(telaVM);

            return View(telaVM);
        }

        private ApontarNOLViewModel CarregarViewBags(ApontarNOLViewModel _telaVM)
        {
            //var garagems = ((SimNaoEnum[])Enum.GetValues(typeof(SimNaoEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.Garagems = new SelectList(garagems, "ID", "Name", imovelVM.Imovel.Garagem);

            //var aguaIndependentes = ((SimNaoEnum[])Enum.GetValues(typeof(SimNaoEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.AguaIndependentes = new SelectList(aguaIndependentes, "ID", "Name", imovelVM.Imovel.AguaIndependente);

            //var luzIndependentes = ((SimNaoEnum[])Enum.GetValues(typeof(SimNaoEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.LuzIndependentes = new SelectList(luzIndependentes, "ID", "Name", imovelVM.Imovel.LuzIndependente);

            //var quintalIndependentes = ((SimNaoEnum[])Enum.GetValues(typeof(SimNaoEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.QuintalIndependentes = new SelectList(quintalIndependentes, "ID", "Name", imovelVM.Imovel.QuintalIndependente);

            //var ocupadas = ((SimNaoEnum[])Enum.GetValues(typeof(SimNaoEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.Ocupadas = new SelectList(ocupadas, "ID", "Name", imovelVM.Imovel.Ocupada);

            //var garantias = ((GarantiaEnum[])Enum.GetValues(typeof(GarantiaEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.Garantias = new SelectList(garantias, "ID", "Name", imovelVM.Imovel.Garantia);

            //var locacaos = ((LocacaoEnum[])Enum.GetValues(typeof(LocacaoEnum))).Select(c => new { ID = (int)c, Name = c.ToString() }).ToList();
            //ViewBag.Locacaos = new SelectList(locacaos, "ID", "Name", imovelVM.Imovel.Locacao);

            //#region Usuario
            //var usuarioVM = await new UsuarioServices().GetAllAsync();
            //Usuario selecionarUsuario = new Usuario { UsuarioID = 0, Nome = "Selecione" };
            //List<Usuario> usuarios = new List<Usuario>();
            //usuarios.Add(selecionarUsuario);
            //usuarios.AddRange(usuarioVM.Usuarios.Where(x => x.Tipo == (int)TipoUsuarioEnum.Locador).OrderBy(x => x.Nome));
            //ViewBag.Usuarios = usuarios.Select(d => new SelectListItem { Value = d.UsuarioID.ToString(), Text = d.Nome, Selected = (d.PaisID == imovelVM.Imovel.UsuarioID.Value) }).ToList();
            //#endregion

            //#region Pais
            //var paisVM = await new PaisServices().GetAllAsync();
            //Pais selecionarPais = new Pais { PaisID = 0, Nome = "Selecione" };
            //List<Pais> paises = new List<Pais>();
            //paises.Add(selecionarPais);
            //paises.AddRange(paisVM.Paiss.OrderBy(x => x.Nome));
            //ViewBag.Paiss = paises.Select(d => new SelectListItem { Value = d.PaisID.ToString(), Text = d.Nome, Selected = (d.PaisID == imovelVM.Imovel.PaisID.Value) }).ToList();
            //#endregion

            //#region UF
            //var ufVM = await new UfServices().GetByPaisAsync(imovelVM.Imovel.PaisID.Value);
            //UF selecionarUF = new UF { PaisID = 0, Nome = "Selecione" };
            //List<UF> ufs = new List<UF>();
            //ufs.Add(selecionarUF);
            //ufs.AddRange(ufVM.UFs.OrderBy(x => x.Nome));
            //ViewBag.Ufs = ufs.Select(d => new SelectListItem { Value = d.UFID.ToString(), Text = d.Nome, Selected = (d.UFID == imovelVM.Imovel.UFID.Value) }).ToList();
            //#endregion

            //#region Regiao
            //var regiaoVM = await new RegiaoServices().GetByPaisAsync(imovelVM.Imovel.PaisID.Value);
            //Regiao selecionarRegiao = new Regiao { RegiaoID = 0, Nome = "Selecione" };
            //List<Regiao> regiaos = new List<Regiao>();
            //regiaos.Add(selecionarRegiao);
            //regiaos.AddRange(regiaoVM.Regiaos.OrderBy(x => x.Nome));
            //ViewBag.Regiaos = regiaos.Select(d => new SelectListItem { Value = d.RegiaoID.ToString(), Text = d.Nome, Selected = (d.RegiaoID == imovelVM.Imovel.RegiaoID.Value) }).ToList();
            //#endregion

            //#region Cidade
            //var cidadeVM = await new CidadeServices().GetByUfAsync(imovelVM.Imovel.UFID.Value);
            //Cidade selecionarCidade = new Cidade { CidadeID = 0, Nome = "Selecione" };
            //List<Cidade> cidades = new List<Cidade>();
            //cidades.Add(selecionarCidade);
            //cidades.AddRange(cidadeVM.Cidades.OrderBy(x => x.Nome));
            //ViewBag.Cidades = cidades.Select(d => new SelectListItem { Value = d.CidadeID.ToString(), Text = d.Nome, Selected = (d.CidadeID == imovelVM.Imovel.CidadeID.Value) }).ToList();
            //#endregion

            //#region Bairro
            //var bairroVM = await new BairroServices().GetByCidadeAsync(imovelVM.Imovel.UFID.Value);
            //Bairro selecionarBairro = new Bairro { CidadeID = 0, Nome = "Selecione" };
            //List<Bairro> bairros = new List<Bairro>();
            //bairros.Add(selecionarBairro);
            //bairros.AddRange(bairroVM.Bairros.OrderBy(x => x.Nome));
            //ViewBag.Bairros = bairros.Select(d => new SelectListItem { Value = d.BairroID.ToString(), Text = d.Nome, Selected = (d.CidadeID == imovelVM.Imovel.BairroID.Value) }).ToList();
            //#endregion

            return _telaVM;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        //public async Task<JsonResult> GetListaUfs(long paisID)
        //{
        //    #region Carregar Combol Ufs

        //    UF selecionarUf = new UF
        //    {
        //        UFID = 0,
        //        Nome = "Selecione"
        //    };

        //    var ufVM = await new UfServices().GetByPaisAsync(paisID);

        //    List<UF> ufs = new List<UF>();
        //    ufs.Add(selecionarUf);
        //    ufs.AddRange(ufVM.UFs.OrderBy(x => x.Nome));

        //    #endregion 

        //    return Json(ufs.Select(d => new SelectListItem { Value = d.UFID.ToString(), Text = d.Nome }).ToList(), JsonRequestBehavior.AllowGet);
        //}

        //public async Task<JsonResult> GetListaRegioes(long paisID)
        //{
        //    #region Carregar Combol GetListaRegioes

        //    Regiao selecionarRegiao = new Regiao
        //    {
        //        RegiaoID = 0,
        //        Nome = "Selecione"
        //    };

        //    var regiaoVM = await new RegiaoServices().GetByPaisAsync(paisID);

        //    List<Regiao> regioes = new List<Regiao>();
        //    regioes.Add(selecionarRegiao);
        //    regioes.AddRange(regiaoVM.Regiaos.OrderBy(x => x.Nome));

        //    #endregion 

        //    return Json(regioes.Select(d => new SelectListItem { Value = d.RegiaoID.ToString(), Text = d.Nome }).ToList(), JsonRequestBehavior.AllowGet);
        //}

        //public async Task<JsonResult> GetListaCidades(long ufID)
        //{
        //    #region Carregar Combol Cidades

        //    Cidade selecionarCidade = new Cidade
        //    {
        //        CidadeID = 0,
        //        Nome = "Selecione"
        //    };

        //    var cidadeVM = await new CidadeServices().GetByUfAsync(ufID);

        //    List<Cidade> cidades = new List<Cidade>();
        //    cidades.Add(selecionarCidade);
        //    cidades.AddRange(cidadeVM.Cidades.OrderBy(x => x.Nome));

        //    #endregion 

        //    return Json(cidades.Select(d => new SelectListItem { Value = d.CidadeID.ToString(), Text = d.Nome }).ToList(), JsonRequestBehavior.AllowGet);
        //}

        //public async Task<JsonResult> GetListaBairros(long regiaoID, long cidadeID)
        //{
        //    #region Carregar Combol Bairros

        //    Bairro selecionarBairro = new Bairro
        //    {
        //        BairroID = 0,
        //        Nome = "Selecione"
        //    };

        //    var bairroVM = await new BairroServices().GetByCidadeAsync(cidadeID);

        //    List<Bairro> bairros = new List<Bairro>();
        //    bairros.Add(selecionarBairro);
        //    bairros.AddRange(bairroVM.Bairros.Where(x => x.RegiaoID == regiaoID).OrderBy(x => x.Nome));

        //    #endregion 

        //    return Json(bairros.Select(d => new SelectListItem { Value = d.BairroID.ToString(), Text = d.Nome }).ToList(), JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult RetrieveImage(long imovelID, int seq)
        //{
        //    var imovelArquivo = new ImovelArquivoServices().GetByImovelIDSequencia(imovelID, seq);
        //    byte[] cover = imovelArquivo.ArquivoByte;

        //    if (cover != null)
        //        return File(cover, "image/jpg");
        //    else
        //        return null;
        //}

        //public async Task<ActionResult> Editar(long? id)
        //{
        //    #region Valida Dados de entrada no metodo
        //    if (UsuarioCookie.UsuarioLogado() == null)
        //        return RedirectToAction("Login", "ContaUsuario");
        //    else
        //        await IniciaMetodo();
        //    #endregion

        //    ImovelViewModel imovelVM;

        //    if (!(id == null || id == 0))
        //    {
        //        imovelVM = await new ImovelServices().GetByIDAsync(id.Value);
        //    }
        //    else
        //    {
        //        imovelVM = new ImovelViewModel();
        //        imovelVM.Imovel = new Imovel();
        //        imovelVM.Imovel.Usuario = new Usuario();
        //        imovelVM.ImovelArquivo = new ImovelArquivo();
        //        imovelVM.Imovel.ImovelArquivos = new List<ImovelArquivo>();

        //        imovelVM.Imovel.Bairro = new Bairro();
        //        imovelVM.Imovel.Bairro.Regiao = new Regiao();
        //        imovelVM.Imovel.Cidade = new Cidade();
        //        imovelVM.Imovel.Cidade.UF = new UF();
        //        imovelVM.Imovel.Cidade.UF.Pais = new Pais();

        //        imovelVM.Imovel.Garagem = (int)GarantiaEnum.Selecione;
        //        imovelVM.Imovel.AguaIndependente = (int)SimNaoEnum.Selecione;
        //        imovelVM.Imovel.LuzIndependente = (int)SimNaoEnum.Selecione;
        //        imovelVM.Imovel.QuintalIndependente = (int)SimNaoEnum.Selecione;
        //        imovelVM.Imovel.Ocupada = (int)SimNaoEnum.Selecione;
        //        imovelVM.Imovel.Garantia = (int)GarantiaEnum.Selecione;
        //        imovelVM.Imovel.Locacao = (int)LocacaoEnum.Selecione;

        //        imovelVM.Imovel.ImovelID = 0;
        //        imovelVM.Imovel.UsuarioID = 0;
        //        imovelVM.Imovel.PaisID = 0;
        //        imovelVM.Imovel.UFID = 0;
        //        imovelVM.Imovel.RegiaoID = 0;
        //        imovelVM.Imovel.CidadeID = 0;
        //        imovelVM.Imovel.BairroID = 0;
        //    }

        //    await CarregarViewBags(imovelVM);

        //    return View(imovelVM);
        //}
        //public async Task<ActionResult> ExcluirAviso(long id)
        //{
        //    #region Valida Dados de entrada no metodo
        //    if (UsuarioCookie.UsuarioLogado() == null)
        //        return RedirectToAction("Login", "ContaUsuario");
        //    else
        //        await IniciaMetodo();
        //    #endregion

        //    Session.SetDataToSession<long>("registroID", id);
        //    Question("Tem certeza que deseja excluir a Imovel?", true);
        //    return RedirectToAction("Lista");
        //}

        //public async Task<ActionResult> Excluir()
        //{
        //    #region Valida Dados de entrada no metodo
        //    if (UsuarioCookie.UsuarioLogado() == null)
        //        return RedirectToAction("Login", "ContaUsuario");
        //    else
        //        await IniciaMetodo();
        //    #endregion

        //    long id = Session.GetDataFromSession<long>("registroID");

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            bool excluir = await new ImovelServices().ExcluirByIDAsync(id, UsuarioCookie.UsuarioLogado().UsuarioID.Value, DateTime.Now);

        //            if (excluir == false)
        //            {
        //                Danger("Ocorreu um erro na gravação da Empresa. Tente novamente mais tarde, se o erro persistir, contate o responável", true);
        //            }
        //            else
        //            {
        //                Success("Imovel excluido com sucesso.", true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //    return RedirectToAction("Lista");
        //}

        //public string URL()
        //{
        //    return UsuarioCookie.URL();
        //}
    }
}
