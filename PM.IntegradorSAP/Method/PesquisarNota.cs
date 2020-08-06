using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using PM.IntegradorSAP.Helper;
using PM.IntegradorSAP.Model;

namespace PM.IntegradorSAP
{
    public class PesquisarNota : Enumeracao
    {
        public List<RespostaNotas> Pesquisar(string ambiente, ModelPesquisarNotas modelPesquisarNota )
        {
            List<RespostaNotas> _retorno = new List<RespostaNotas>();
            XmlDocument soapEnvelopeXml;

            ValidaDados_CriarNota(modelPesquisarNota); 
            try
            {
                SOAPRequest oSOAPRequest = new SOAPRequest();
                soapEnvelopeXml = CreateSoapEnvelope_CriarNota(ambiente, modelPesquisarNota);
                
                _retorno = oSOAPRequest.ProcessamentoPesquisa("PESQUISA NOTA", ambiente, soapEnvelopeXml);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Message [{0}] - Source [{1}] - StackTrace [{2}]", ex.Message, ex.Source, ex.StackTrace);
                DomainException.When(true, msg);
            }
            return _retorno;
        }
        private void ValidaDados_CriarNota(ModelPesquisarNotas modelPesquisarNota)
        {
            if(false)
            { 
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.TipoNota)			, "Necessario informar tiponota ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.NumeroNota)		, "Necessario informar NumeroNota ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.LocalInstalacao)	, "Necessario informar LocalInstalacao ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Prioridade)		, "Necessario informar Prioridade ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.DataDe)			, "Necessario informar DataDe ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.DataAte)			, "Necessario informar DataAte ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Notificador)		, "Necessario informar Notificador ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.StatusUsuario)		, "Necessario informar StatusUsuario ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.StatusNota)		, "Necessario informar StatusNota ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Solicitante)		, "Necessario informar Solicitante ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.NumeroOrdem)		, "Necessario informar NumeroOrdem ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.CentroTrabalho)	, "Necessario informar CentroTrabalho ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Centro)			, "Necessario informar Centro ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Equipamento)		, "Necessario informar Equipamento ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Material)			, "Necessario informar Material ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Code)			    , "Necessario informar Code ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.GrpCode)			, "Necessario informar GrpCode ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.NotaRerencia)		, "Necessario informar NotaRerencia ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.CausaRaiz)			, "Necessario informar CausaRaiz ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.Diagnostico)		, "Necessario informar Diagnostico ");
                DomainException.When(string.IsNullOrEmpty(modelPesquisarNota.EventoGerador)		, "Necessario informar EventoGerador ");
            }
        }
        private static XmlDocument CreateSoapEnvelope_CriarNota(string ambiente, ModelPesquisarNotas modelPesquisarNota)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            try
            {
                oStringBuilder.AppendFormat("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:Metro:Portal:Ecc:PesquisaNotas\">");
                oStringBuilder.AppendFormat("   <soapenv:Header/>");
                oStringBuilder.AppendFormat("   <soapenv:Body>");
                oStringBuilder.AppendFormat("      <urn:MT_PesquisaNotas_request>");
                oStringBuilder.AppendFormat("         <PESQUISA>");
                oStringBuilder.AppendFormat("            <TipoNota>{0}</TipoNota>"					, modelPesquisarNota.TipoNota);                
                oStringBuilder.AppendFormat("            <NumeroNota>{0}</NumeroNota>"				, modelPesquisarNota.NumeroNota);                
                oStringBuilder.AppendFormat("            <LocalInstalacao>{0}</LocalInstalacao>"	, modelPesquisarNota.LocalInstalacao);                
                oStringBuilder.AppendFormat("            <Prioridade>{0}</Prioridade>"				, modelPesquisarNota.Prioridade);                
                oStringBuilder.AppendFormat("            <DataDe>{0}</DataDe>"						, modelPesquisarNota.DataDe);                
                oStringBuilder.AppendFormat("            <DataAte>{0}</DataAte>"					, modelPesquisarNota.DataAte);                
                oStringBuilder.AppendFormat("            <Notificador>{0}</Notificador>"			, modelPesquisarNota.Notificador);                
                oStringBuilder.AppendFormat("            <StatusUsuario>{0}</StatusUsuario>"		, modelPesquisarNota.StatusUsuario);                
                oStringBuilder.AppendFormat("            <StatusNota>{0}</StatusNota>"				, modelPesquisarNota.StatusNota);                
                oStringBuilder.AppendFormat("            <Solicitante>{0}</Solicitante>"			, modelPesquisarNota.Solicitante);                
                oStringBuilder.AppendFormat("            <NumeroOrdem>{0}</NumeroOrdem>"			, modelPesquisarNota.NumeroOrdem);                
                oStringBuilder.AppendFormat("            <CentroTrabalho>{0}</CentroTrabalho>"		, modelPesquisarNota.CentroTrabalho);                
                oStringBuilder.AppendFormat("            <Centro>{0}</Centro>"						, modelPesquisarNota.Centro);                
                oStringBuilder.AppendFormat("            <Equipamento>{0}</Equipamento>"			, modelPesquisarNota.Equipamento);                
                oStringBuilder.AppendFormat("            <Material>{0}</Material>"					, modelPesquisarNota.Material);                
                oStringBuilder.AppendFormat("            <Code>{0}</Code>"							, modelPesquisarNota.Code);                
                oStringBuilder.AppendFormat("            <GrpCode>{0}</GrpCode>"					, modelPesquisarNota.GrpCode);                
                oStringBuilder.AppendFormat("            <NotaRerencia>{0}</NotaRerencia>"			, modelPesquisarNota.NotaRerencia);                
                oStringBuilder.AppendFormat("            <CausaRaiz>{0}</CausaRaiz>"				, modelPesquisarNota.CausaRaiz);                
                oStringBuilder.AppendFormat("            <Diagnostico>{0}</Diagnostico>"			, modelPesquisarNota.Diagnostico);                
                oStringBuilder.AppendFormat("            <EventoGerador>{0}</EventoGerador>"		, modelPesquisarNota.EventoGerador);
                oStringBuilder.AppendFormat("         </PESQUISA>");
                oStringBuilder.AppendFormat("      </urn:MT_PesquisaNotas_request>");
                oStringBuilder.AppendFormat("   </soapenv:Body>");
                oStringBuilder.AppendFormat("</soapenv:Envelope>");
                soapEnvelopeXml.LoadXml(oStringBuilder.ToString());
            }
            catch (Exception ex)
            {
                var msg = string.Format("Message [{0}] - Source [{1}] - StackTrace [{2}]", ex.Message, ex.Source, ex.StackTrace);
                DomainException.When(true, msg);
            }
            return soapEnvelopeXml;
        }
    }
}