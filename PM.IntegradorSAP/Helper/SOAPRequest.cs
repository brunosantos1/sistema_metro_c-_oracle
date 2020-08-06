using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;


namespace PM.IntegradorSAP.Helper
{
    class SOAPRequest
    {
        public enum Ambiente
        {
            Desenvolvimento,
            Produção,
            Homologação,
        }

        #region --|Core|--
        /// <summary>
        /// Cria e retorna objeto HttpWebRequest
        /// </summary>
        /// <param name="url">URI de conexao com servidor</param>
        /// <param name="action">Metodo a ser invocado</param>
        /// <returns></returns>
        private static HttpWebRequest CreateWebRequest(string url, string user, string pass)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                webRequest.Credentials = new NetworkCredential(user, pass);
                webRequest.PreAuthenticate = true;           
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return webRequest;
        }

        /// <summary>
        /// Cria e retorna objeto HttpWebRequest
        /// </summary>
        /// <param name="url">URI de conexao com servidor</param>
        /// <param name="action">Metodo a ser invocado</param>
        /// <returns></returns>
        private static HttpWebRequest CreateWebRequestPesquisa(string url, string user, string pass)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                webRequest.Headers.Add("SOAPAction", "http://sap.com/xi/WebService/soap1.1");
                webRequest.Credentials  = new NetworkCredential(user, pass);
                webRequest.ContentType  = "text/xml;charset=\"utf-8\"";
                webRequest.Accept       = "text/xml";
                webRequest.Method       = "POST";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return webRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="soapEnvelopeXml"></param>
        /// <param name="webRequest"></param>
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            try
            {
                using (Stream stream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soapEnvelopeXml"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public List<Resposta> Processamento(string modulo, string ambiente, XmlDocument soapEnvelopeXml)
        {
            List<Resposta> _retorno = new List<Resposta>();
            
            string result;
            HttpWebRequest webRequest;
            string user = "portalpm";
            string pass = "metropod123";
            try
            {
                string url = URLAmbiente(ambiente, modulo);
                DomainException.When(string.IsNullOrEmpty(url), string.Format("URL do ambiente [{0}] do módulo [{1}] não foi localizada", ambiente, modulo));

                webRequest = CreateWebRequest(url, user, pass);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

                using (WebResponse response = webRequest.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        result = rd.ReadToEnd();
                    }
                }

                if (!result.Trim().Length.Equals(0))
                {
                    XmlDocument oXmlDocument = new XmlDocument();
                    oXmlDocument.LoadXml(result.ToString());
                    XmlNodeList NodeRetorno = oXmlDocument.GetElementsByTagName("Response");
                    Resposta oResposta = new Resposta();
                    foreach (XmlNode Item in NodeRetorno)
                    {
                        //XmlDocument oXmlDocument1 = new XmlDocument(); oXmlDocument1.LoadXml(Item.InnerXml);
                        oResposta               = new Resposta();
                        oResposta._status       = (Item.ChildNodes[0].InnerText.ToUpper().Equals("S")) ? true : false;
                        oResposta._codMensagem  = Item.ChildNodes[1].InnerText;
                        if (Item.ChildNodes.Count > 3)
                        {
                            oResposta._mensagem = string.Format("{0} - {1}", Item.ChildNodes[2].InnerText, Item.ChildNodes[3].InnerText);
                        }
                        else
                        {
                            oResposta._mensagem = Item.ChildNodes[2].InnerText;
                        }

                        _retorno.Add(oResposta);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retorno;
        }

        public List<RespostaNotas> ProcessamentoPesquisa(string modulo, string ambiente, XmlDocument soapEnvelopeXml)
        {
            
            List<RespostaNotas> _retorno = new List<RespostaNotas>();
            string result;
            HttpWebRequest webRequest;
            string user = "portalpm";
            string pass = "metropod123";
            try
            {
                string url = URLAmbiente(ambiente, modulo);
                DomainException.When(string.IsNullOrEmpty(url), string.Format("URL do ambiente [{0}] do módulo [{1}] não foi localizada", ambiente, modulo));                
                webRequest = CreateWebRequestPesquisa(url, user, pass);

                byte[] data = System.Text.Encoding.UTF8.GetBytes(soapEnvelopeXml.InnerXml.ToString());
                webRequest.ContentLength = data.Length;
                Stream stm = webRequest.GetRequestStream();
                stm.Write(data, 0, data.Length);

                try
                {
                    WebResponse webResponse = webRequest.GetResponse();
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        result = rd.ReadToEnd();
                        _retorno = XMLToList(result);
                    }
                }
                catch (WebException webex)
                {
                    WebResponse errResp = webex.Response;   
                    using (Stream respStream = errResp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(respStream);
                        string text = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_ambiente"></param>
        /// <returns></returns>
        protected static string URLAmbiente(string ambiente, string modulo)
        {
            string _retorno = "";
            try
            {
                switch(ambiente.ToUpper())
                {
                    case "DESENVOLVIMENTO":
                        {
                            switch(modulo.ToUpper())
                            {
                                case "MATERIAL RODANTE":
                                    {
                                        _retorno = "http://sa044cld.metroweb.sp.gov.br:50000/XISOAPAdapter/MessageServlet?senderParty=&senderService=BC_PORTAL&receiverParty=&receiverService=&interface=SI_CriarNotaPortal_OUT_SYNC&interfaceNamespace=urn:Metro:Portal:Ecc:CriarNotaMaterialRodante";                                        
                                        break;
                                    }                                
                                case "EQUIPAMENTO FIXO":
                                    {
                                        _retorno = "http://sa044cld.metroweb.sp.gov.br:50000/XISOAPAdapter/MessageServlet?senderParty=&senderService=BC_PORTAL&receiverParty=&receiverService=&interface=SI_CRIARNOTA_OUT_SYNC&interfaceNamespace=urn:Metro:Portal:Ecc:CriarNotaEquipamentoFixo";
                                        break;
                                    }
                                case "PERICIACOPESE":
                                    {
                                        _retorno = "http://sa044cld.metroweb.sp.gov.br:50000/XISOAPAdapter/MessageServlet?senderParty=&senderService=BC_PORTAL&receiverParty=&receiverService=&interface=SI_CriarNotaPortal_OUT_SYNC&interfaceNamespace=urn:Metro:Portal:Ecc:CriarNotaPericiaCopese";
                                        break;
                                    }
                                case "PESQUISA NOTA":
                                    {
                                        _retorno = "http://sa044cld.metroweb.sp.gov.br:50000/XISOAPAdapter/MessageServlet?senderParty=&senderService=BC_PORTAL&receiverParty=&receiverService=&interface=SI_PesquisaNotas_OUT_SYNC&interfaceNamespace=urn:Metro:Portal:Ecc:PesquisaNotas";
                                        break;
                                    }
                            }
                            break;
                        }
                    case "HOMOLOGAÇÃO":
                        {
                            switch (modulo.ToUpper())
                            {
                                case "MATERIAL RODANTE":
                                    {
                                        _retorno = "";
                                        break;
                                    }
                                case "EQUIPAMENTO FIXO":
                                    {
                                        _retorno = "";
                                        break;
                                    }
                                case "OFICINA":
                                    {
                                        _retorno = "";
                                        break;
                                    }
                            }
                            break;
                        }
                    case "PRODUÇÃO":
                        {
                            switch (modulo.ToUpper())
                            {
                                case "MATERIAL RODANTE":
                                    {
                                        _retorno = "";
                                        break;
                                    }
                                case "EQUIPAMENTO FIXO":
                                    {
                                        _retorno = "";
                                        break;
                                    }
                                case "OFICINA":
                                    {
                                        _retorno = "";
                                        break;
                                    }
                            }
                            break;
                        }
                }


                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _retorno;
        }

        private List<RespostaNotas> XMLToList(string result)
        {
            List<RespostaNotas> _retorno = new List<RespostaNotas>();
            RespostaNotas oRespostaNotas = new RespostaNotas();

            XmlDocument oXmlDocument = new XmlDocument();
            oXmlDocument.LoadXml(result.ToString());
            string NODE = "NOTAS";
            XmlNodeList NodeRetorno = oXmlDocument.GetElementsByTagName(NODE);
            if (NodeRetorno.Count > 0)
            {
                foreach(XmlNode itemNode in NodeRetorno)
                {

                    oRespostaNotas                      = new RespostaNotas();
                    oRespostaNotas.CausaRaiz            = string.IsNullOrEmpty(itemNode["CausaRaiz"].InnerText)         ? "" : itemNode["CausaRaiz"].InnerText;
                    oRespostaNotas.Centro               = string.IsNullOrEmpty(itemNode["Centro"].InnerText)            ? "" : itemNode["Centro"].InnerText;
                    oRespostaNotas.CentroTrabalho       = string.IsNullOrEmpty(itemNode["CentroTrabalho"].InnerText)    ? "" : itemNode["CentroTrabalho"].InnerText;
                    oRespostaNotas.Code                 = string.IsNullOrEmpty(itemNode["Code"].InnerText)              ? "" : itemNode["Code"].InnerText;
                    oRespostaNotas.DataDesejada         = string.IsNullOrEmpty(itemNode["DataDesejada"].InnerText)      ? "" : itemNode["DataDesejada"].InnerText;
                    oRespostaNotas.DataNota             = string.IsNullOrEmpty(itemNode["DataNota"].InnerText)          ? "" : itemNode["DataNota"].InnerText;
                    oRespostaNotas.DataProcessamento    = string.IsNullOrEmpty(itemNode["DataProcessamento"].InnerText) ? "" : itemNode["DataProcessamento"].InnerText;
                    oRespostaNotas.DescricaoNota        = string.IsNullOrEmpty(itemNode["DescricaoNota"].InnerText)     ? "" : itemNode["DescricaoNota"].InnerText;
                    oRespostaNotas.Diagnostico          = string.IsNullOrEmpty(itemNode["Diagnostico"].InnerText)       ? "" : itemNode["Diagnostico"].InnerText;
                    oRespostaNotas.Equipamento          = string.IsNullOrEmpty(itemNode["Equipamento"].InnerText)       ? "" : itemNode["Equipamento"].InnerText;
                    oRespostaNotas.GrpCode              = string.IsNullOrEmpty(itemNode["GrpCode"].InnerText)           ? "" : itemNode["GrpCode"].InnerText;
                    oRespostaNotas.HoraNota             = string.IsNullOrEmpty(itemNode["HoraNota"].InnerText)          ? "" : itemNode["HoraNota"].InnerText;
                    oRespostaNotas.HoraProcessamento    = string.IsNullOrEmpty(itemNode["HoraProcessamento"].InnerText) ? "" : itemNode["HoraProcessamento"].InnerText;
                    oRespostaNotas.LocalInstalacao      = string.IsNullOrEmpty(itemNode["LocalInstalacao"].InnerText)   ? "" : itemNode["LocalInstalacao"].InnerText;
                    oRespostaNotas.Material             = string.IsNullOrEmpty(itemNode["Material"].InnerText)          ? "" : itemNode["Material"].InnerText;
                    oRespostaNotas.NotaRerencia         = string.IsNullOrEmpty(itemNode["NotaRerencia"].InnerText)      ? "" : itemNode["NotaRerencia"].InnerText;
                    oRespostaNotas.Notificador          = string.IsNullOrEmpty(itemNode["Notificador"].InnerText)       ? "" : itemNode["Notificador"].InnerText;
                    oRespostaNotas.NumeroNota           = string.IsNullOrEmpty(itemNode["NumeroNota"].InnerText)        ? "" : itemNode["NumeroNota"].InnerText;
                    oRespostaNotas.NumeroOrdem          = string.IsNullOrEmpty(itemNode["NumeroOrdem"].InnerText)       ? "" : itemNode["NumeroOrdem"].InnerText;
                    oRespostaNotas.Prioridade           = string.IsNullOrEmpty(itemNode["Prioridade"].InnerText)        ? "" : itemNode["Prioridade"].InnerText;
                    oRespostaNotas.StatusNota           = string.IsNullOrEmpty(itemNode["StatusNota"].InnerText)        ? "" : itemNode["StatusNota"].InnerText;
                    oRespostaNotas.StatusUsuario        = string.IsNullOrEmpty(itemNode["StatusUsuario"].InnerText)     ? "" : itemNode["StatusUsuario"].InnerText;
                    oRespostaNotas.TipoNota             = string.IsNullOrEmpty(itemNode["CausaRaiz"].InnerText)         ? "" : itemNode["TipoNota"].InnerText;
                    _retorno.Add(oRespostaNotas);
                }                
            }
            return _retorno;
        }
        #endregion
    }
}