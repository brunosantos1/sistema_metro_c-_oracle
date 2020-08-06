
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PM.Domain.Entities;
using static PM.Web.ApplicationUserManager;

namespace PM.Web.Library
{

    public enum TipoAcao
    {
        Incluir = 110,
        Alterar = 111,
        Deletar = 112,
        Pesquisar = 113
    };

    public struct Resposta
    {
        [Display(Name = "Status")]
        public bool Status { get; private set; }
        [Display(Name = "Mensagem")]
        public string Mensagem { get; private set; }
        
        public Resposta(bool status, string mensagem)
        {
            Status = status;
            Mensagem = mensagem;
        }
    }

    public static class LogApplication
    {
        public static bool RegistraLogLogin(int idAplicacao, string UserId, string UserName)
        {
            WebServices.Models.SistemaLogLogin _retorno = new WebServices.Models.SistemaLogLogin();
            try
            {
                if (bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsLogRegister"].ToString()))
                {
                    WebServices.Models.SistemaLogLogin _ret = new WebServices.Models.SistemaLogLogin(
                                                                                                          
                                                                                                         DateTime.Now
                                                                                                        , IPAddress()
                                                                                                        , Environment.MachineName.ToUpper()
                                                                                                        , UserName.ToString()
                                                                                                        , UserId.ToString()
                                                                                                        , HttpContext.Current.Request.Browser.Id.ToString()
                                                                                                        , HttpContext.Current.Request.Browser.Version.ToString()
                                                                                                        , HttpContext.Current.Request.Browser.Cookies
                                                                                                        , HttpContext.Current.Request.Browser.Platform.ToString()
                                                                                                        , HttpContext.Current.Request.Browser.Win16
                                                                                                        , HttpContext.Current.Request.Browser.Win32
                                                                                                        , HttpContext.Current.Request.Url.ToString()
                                                                                                        , idAplicacao
                                                                                                    );                    
                    _retorno = (new PM.WebServices.Service.SistemaLogLoginServices()).Add(_ret);
                    if(_retorno.BaseModel.MensagemException != null)
                    {
                        Exception MyException = new Exception(_retorno.BaseModel.MensagemException.ToString());
                        //MyException = Newtonsoft.Json.JsonConvert.DeserializeObject<Exception>(_retorno.BaseModel.MensagemException.ToString());
                        //MyException = _retorno.BaseModel.MensagemException.ToString();
                        PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), MyException);
                    }
                }                
            }
            catch(Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }
            return (bool)_retorno.BaseModel.Erro;
        }

        public static bool RegistraLogOperacoes(int idAplicacao, int IDAcao, Object ValorOrigem, Object ValorPara = null)
        {
            ValorPara = ValorOrigem;
            WebServices.Models.SistemaLogOperacoes _retorno = new WebServices.Models.SistemaLogOperacoes();
            WebServices.Models.SistemaLogOperacoes _Operacoes = new WebServices.Models.SistemaLogOperacoes();
            List<WebServices.Models.SistemaLogOperacoesItem> _lstItem = new List<WebServices.Models.SistemaLogOperacoesItem>();
            try
            {
                if (bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsLogRegister"].ToString()))
                {

                    WebServices.Models.SistemaLogOperacoesItem oItem = new WebServices.Models.SistemaLogOperacoesItem();

                    string NomeAmigavelPropriedade  = "";
                    string NomePropriedade          = "";
                    string ValorDeOrigem            = "";
                    string ValorDeAlterado          = "";
                    int OrdemExibicao               = 0;
                    var objOrigem                   = ValorOrigem.GetType();
                    var objPara                     = ValorPara == null ? null : ValorPara.GetType();
                    var NomePrefixo                 = "";
                    System.Collections.IList        lstOrigem;
                    System.Collections.IList        lstDestino;
                    #region --|Gerando Valores Itens|--                   
                    // Funciona
                    foreach (var propOrigem in objOrigem.GetProperties())
                    {                        
                        if (propOrigem.GetValue(ValorOrigem).ToString().ToUpper().Contains("SYSTEM.COLLECTIONS.GENERIC.LIST`1[PM.INTEGRADORSAP.MODEL.MATERIALRODANTEMEDIDA]"))
                        {
                            NomePrefixo = propOrigem.GetValue(ValorOrigem).ToString().Replace("]", "").Split('[')[1].Split('.')[3].ToString();
                            lstOrigem   = (System.Collections.IList)propOrigem.GetValue(ValorOrigem);
                            lstDestino  = objPara == null ? null :  (System.Collections.IList)propOrigem.GetValue(ValorPara);

                            foreach (var propOrigemFilho in lstOrigem)
                            {
                                var objOrigemFilho = propOrigemFilho.GetType();
                                foreach (var propFilho in objOrigemFilho.GetProperties())
                                {
                                    NomeAmigavelPropriedade = propFilho.Name.ToString();
                                    NomePropriedade         = string.Format("{0}.{1}", NomePrefixo, propFilho.Name);
                                    ValorDeOrigem           = propFilho.GetValue(propOrigemFilho).ToString();
                                    OrdemExibicao++;
                                    if (lstDestino != null)
                                    {
                                        foreach (var propParaFilho in lstDestino)
                                        {
                                            var objParaFilho = propParaFilho.GetType();
                                            foreach (var propFilhoPara in objOrigemFilho.GetProperties().Where(c => c.Name.Equals(propFilho.Name.ToString())))
                                            {
                                                ValorDeAlterado = propFilhoPara.GetValue(propOrigemFilho).ToString();
                                            }
                                        }
                                    }                                    
                                    foreach (var att in propOrigem.CustomAttributes) { if (att.AttributeType.Name.ToUpper().Equals("DISPLAYATTRIBUTE")) { NomeAmigavelPropriedade = att.NamedArguments[0].TypedValue.ToString().Replace("\"", ""); } }

                                    oItem                       = new WebServices.Models.SistemaLogOperacoesItem();
                                    oItem.DsPropriedade         = NomePropriedade;
                                    oItem.DsValorOrigem         = string.IsNullOrEmpty(ValorDeOrigem.ToString()) ? "** VAZIO **" : ValorDeOrigem.ToString();
                                    oItem.DsValorPara           = ValorDeAlterado.ToString();
                                    oItem.NmAmigavel            = NomeAmigavelPropriedade.ToString();
                                    oItem.NuOrdem               = OrdemExibicao;
                                    oItem.IdLogOperacoes        = 0;
                                    oItem.IdLogOperacoesItem    = 0;
                                    _lstItem.Add(oItem);
                                }
                            }
                        }
                        else
                        {
                            NomeAmigavelPropriedade = propOrigem.Name.ToString();
                            NomePropriedade         = propOrigem.Name;
                            ValorDeOrigem           = propOrigem.GetValue(ValorOrigem).ToString();
                            ValorDeAlterado         = ""; //propOrigem.GetValue(objPara).ToString();
                            OrdemExibicao++;
                            foreach (var att in propOrigem.CustomAttributes) { if (att.AttributeType.Name.ToUpper().Equals("DISPLAYATTRIBUTE")) { NomeAmigavelPropriedade = att.NamedArguments[0].TypedValue.ToString().Replace("\"", ""); } }
                        }

                        oItem                       = new WebServices.Models.SistemaLogOperacoesItem();
                        oItem.DsPropriedade         = NomePropriedade;
                        oItem.DsValorOrigem         = string.IsNullOrEmpty(ValorDeOrigem.ToString()) ? "** VAZIO **" : ValorDeOrigem.ToString();
                        oItem.DsValorPara           = ValorDeAlterado.ToString();
                        oItem.NmAmigavel            = NomeAmigavelPropriedade.ToString();
                        oItem.NuOrdem               = OrdemExibicao;
                        oItem.IdLogOperacoes        = 0;
                        oItem.IdLogOperacoesItem    = 0;
                        _lstItem.Add(oItem);
                    }
                    #endregion

                    WebServices.Models.SistemaLogOperacoes _ret = new WebServices.Models.SistemaLogOperacoes(

                                                                                                         DateTime.Now
                                                                                                        , IDAcao.GetHashCode()
                                                                                                        , IPAddress()
                                                                                                        , Environment.MachineName.ToUpper()
                                                                                                        , System.Web.HttpContext.Current.User.Identity.GetUserName().ToString()
                                                                                                        , System.Web.HttpContext.Current.User.Identity.GetUserId().ToString()
                                                                                                        , System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString()
                                                                                                        , System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString()
                                                                                                        , HttpContext.Current.Request.Url.ToString()
                                                                                                        , "dsJsonOrigem"
                                                                                                        , "dsJsonPara"
                                                                                                        , idAplicacao
                                                                                                        , null
                                                                                                        , _lstItem
                                                                                                    );
                    _retorno = (new PM.WebServices.Service.SistemaLogOperacoesServices()).Add(_ret);

                    if (_retorno.BaseModel.MensagemException != null)
                    {
                        Exception MyException = new Exception();
                        MyException = Newtonsoft.Json.JsonConvert.DeserializeObject<Exception>(_retorno.BaseModel.MensagemException.ToString());
                        PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), MyException);
                    }
                }
            }
            catch (Exception ex)
            {
                PM.Web.Library.LogApplication.RegistraLogError(int.Parse(System.Configuration.ConfigurationManager.AppSettings["ILogAplication"].ToString()), ex);
            }

            return (bool)_retorno.BaseModel.Erro;
        }

        public static bool RegistraLogError(int idAplicacao, Exception exception)
        {
            bool _retorno = false;
            try
            {
                if (bool.Parse(System.Configuration.ConfigurationManager.AppSettings["IsLogRegister"].ToString()))
                {
                    string UserName = "Usuario Não Logado";
                    string GetUserId = "0";
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        UserName = System.Web.HttpContext.Current.User.Identity.GetUserName().ToString();
                        GetUserId = System.Web.HttpContext.Current.User.Identity.GetUserId().ToString();
                    }
                    string NomeController = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
                    string NomeAction = System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
                    string URLFull = HttpContext.Current.Request.Url.ToString();

                    WebServices.Models.SistemaLogError _ret = new WebServices.Models.SistemaLogError(
                                                                                                        DateTime.Now
                                                                                                    , IPAddress()
                                                                                                    , Environment.MachineName
                                                                                                    , UserName
                                                                                                    , GetUserId
                                                                                                    , System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString()
                                                                                                    , System.Web.HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString()
                                                                                                    , HttpContext.Current.Request.Url.ToString()
                                                                                                    , (NomeController == null || NomeController.Trim().Length.Equals(0)) ? exception.GetBaseException().ToString() : exception.GetBaseException().ToString().ToUpper().IndexOf(NomeAction.ToUpper()) < 0 ? exception.GetBaseException().ToString() : exception.GetBaseException().ToString().Substring(exception.GetBaseException().ToString().ToUpper().IndexOf(NomeAction.ToUpper()))
                                                                                                    , exception.GetType().ToString()
                                                                                                    , exception.HResult.ToString()
                                                                                                    , (exception.Message == null) ? "Não identificado" : exception.Message.ToString()
                                                                                                    , (exception.Source == null) ? "Não identificado" : exception.Source.ToString()
                                                                                                    , (exception.StackTrace == null) ? "Não identificado" : exception.StackTrace.ToString()
                                                                                                    , (exception.TargetSite.ToString() == null) ? "Não identificado" : exception.TargetSite.ToString()                                                                                                        
                                                                                                    , idAplicacao
                                                                                                    , 0
                                                                                                    , (exception.HelpLink == null) ? "Não identificado" : exception.HelpLink.ToString()
                                                                                                    , (exception.InnerException == null) ? "Não identificado" : exception.InnerException.ToString()
                                                                                                );
                    (new PM.WebServices.Service.SistemaLogErrorServices()).Add(_ret);
                    
                }
                _retorno = true;
            }
            catch (Exception e)
            {
                e = e;
            }

            return _retorno;
        }

        private static string IPAddress()
        {
            string _IPAddress = "";
            System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            System.Net.IPAddress[] IPaddr = ip.AddressList;
            _IPAddress = (IPaddr.Count() > 1) ? IPaddr[1].ToString() : "Não Identificado";
            return _IPAddress.ToString();
        }
    }
}