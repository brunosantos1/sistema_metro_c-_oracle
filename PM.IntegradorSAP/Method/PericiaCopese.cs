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
    public class PericiaCopese : Enumeracao
    {
        /// <summary>
        /// Efetua Criação de Nota para meterial rodante
        /// </summary>
        /// <param name="ambiente">Valores possiveis DESENVOLVIMENTO, HOMOLOGAÇÃO, PRODUÇÃO</param>
        /// <param name="credencialuser">Credencial do usuário</param>
        /// <param name="credencialpass"></param>
        /// <param name="tiponota"></param>
        /// <param name="locinstalacao"></param>
        /// <param name="code"></param>
        /// <param name="grpcode"></param>
        /// <param name="descricao"></param>
        /// <param name="prioridade"></param>
        /// <param name="notificador"></param>
        /// <param name="linha"></param>
        /// <param name="local"></param>
        /// <param name="centrotrabalho"></param>
        /// <param name="centro"></param>
        /// <param name="observacao"></param>
        /// <param name="interoperacional"></param>
        /// <param name="incidentenotavel"></param>
        /// <param name="fumaca"></param>
        /// <param name="tipomanutencao"></param>
        /// <param name="statusnota"></param>
        /// <param name="statususuario"></param>
        /// <param name="itemmedia"></param>
        /// <param name="grpcodmedidas"></param>
        /// <param name="codmedidas"></param>
        /// <param name="statusmedida"></param>
        /// <param name="datainicio"></param>
        /// <param name="horainicio"></param>
        /// <param name="funcresposavel"></param>
        /// <param name="responsavel"></param>
        /// <param name="rglogado"></param>
        /// <param name="dataprogramanda"></param>
        /// <param name="horaprogramada"></param>
        /// <returns></returns>
        public List<Resposta> CriacaoNota(string ambiente, ModelPericiaCopese modelPericiaCopese)
        {
            List<Resposta> _retorno = new List<Resposta>();
            XmlDocument soapEnvelopeXml;

            ValidaDados_CriarNota(modelPericiaCopese);
            try
            {
                SOAPRequest oSOAPRequest = new SOAPRequest();
                soapEnvelopeXml = CreateSoapEnvelope_CriarNota(modelPericiaCopese);
                _retorno = oSOAPRequest.Processamento("PericiaCopese", ambiente, soapEnvelopeXml);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Message [{0}] - Source [{1}] - StackTrace [{2}]", ex.Message, ex.Source, ex.StackTrace);
                DomainException.When(true, msg);
            }
            return _retorno;
        }
        private void ValidaDados_CriarNota(ModelPericiaCopese modelPericiaCopese)
        {
            // As linhas comentadas é pq. não são dados obrigatórios
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.Code)				, "Necessario informar code ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.Descricao)			, "Necessario informar descricao ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.GrpCode)			, "Necessario informar grpcode ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.LocInstalacao)     , "Necessario informar locinstalacao ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.Notificador)		, "Necessario informar notificador ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.Observacao)		, "Necessario informar observacao ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.StatusNota)		, "Necessario informar statusnota ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.StatusUsuario)		, "Necessario informar statususuario ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.TipoNota)			, "Necessario informar tiponota ");
            DomainException.When(string.IsNullOrEmpty(modelPericiaCopese.NotaReferencia)	, "Necessario informar notareferencia ");

            if(modelPericiaCopese.Atividade.Count.Equals(0))
            {
                foreach (ModelPericiaCopeseAtividade item in modelPericiaCopese.Atividade)
                {
                    DomainException.When(string.IsNullOrEmpty(item.CodAtividades)   , string.Format("Necessario informar CodAtividades do Item Atividade [{0}]", item.NumeroItem));
                    DomainException.When(string.IsNullOrEmpty(item.DescricaoBO)     , string.Format("Necessario informar DescricaoBO do Item Atividade [{0}]", item.NumeroItem));
                    DomainException.When(string.IsNullOrEmpty(item.GrpCodAtividades), string.Format("Necessario informar GrpCodAtividades do Item Atividade [{0}]", item.NumeroItem));
                    DomainException.When(string.IsNullOrEmpty(item.NumeroBO)        , string.Format("Necessario informar NumeroBO do Item Atividade [{0}]", item.NumeroItem));
                    DomainException.When(string.IsNullOrEmpty(item.NumeroItem)      , string.Format("Necessario informar NumeroItem", item.NumeroItem));
                }
            }

            if (modelPericiaCopese.Causa.Count.Equals(0))
            {
                foreach (ModelPericiaCopeseCausa item in modelPericiaCopese.Causa)
                {
                    DomainException.When(string.IsNullOrEmpty(item.NumeroItem)  , string.Format("Necessario informar NumeroItem"));
                    DomainException.When(string.IsNullOrEmpty(item.CodCausa)    , string.Format("Necessario informar CodCausa do Item Causa [{0}]", item.NumeroItem));
                    DomainException.When(string.IsNullOrEmpty(item.GrpCodCausa) , string.Format("Necessario informar GrpCodCausa do Item Causa [{0}]", item.NumeroItem));                    
                }
            }

            if (modelPericiaCopese.Medida.Count.Equals(0))
            {
                foreach(ModelPericiaCopeseMedida item in modelPericiaCopese.Medida)
                {
                    DomainException.When(string.IsNullOrEmpty(item.ItemMedia)       , string.Format("Necessario informar ItemMedia"));
                    DomainException.When(string.IsNullOrEmpty(item.CodMedidas)      , string.Format("Necessario informar CodMedidas do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.DataMedida)      , string.Format("Necessario informar DataMedida do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(DomainException.IsDate(item.DataMedida)    , string.Format("Necessario informar DataMedida invalida do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.DataProgramanda) , string.Format("Necessario informar DataProgramanda do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(DomainException.IsDate(item.DataProgramanda), string.Format("Necessario informar DataProgramanda invalida do Item Medida [{0}]", item.ItemMedia));
                    
                    DomainException.When(string.IsNullOrEmpty(item.FuncResposavel)  , string.Format("Necessario informar FuncResposavel do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.GrpCodMedidas)   , string.Format("Necessario informar GrpCodMedidas do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.HoraMedida)      , string.Format("Necessario informar HoraMedida do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.HoraProgramada)  , string.Format("Necessario informar HoraProgramada do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.ItemMedia)       , string.Format("Necessario informar ItemMedia do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.Responsavel)     , string.Format("Necessario informar Responsavel do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.RGLogado)        , string.Format("Necessario informar RGLogado do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.StatusMedida)    , string.Format("Necessario informar StatusMedida do Item Medida [{0}]", item.ItemMedia));
                }
            }
        }
        private static XmlDocument CreateSoapEnvelope_CriarNota(ModelPericiaCopese modelPericiaCopese)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            try
            {
                oStringBuilder.AppendFormat("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:Metro:Portal:Ecc:CriarNotaPericiaCopese\">");
                oStringBuilder.AppendFormat("   <soapenv:Header/>");
                oStringBuilder.AppendFormat("   <soapenv:Body>");
                oStringBuilder.AppendFormat("      <urn:MT_CriarNotaPortal_request>");
                oStringBuilder.AppendFormat("         <HEADER>");
                oStringBuilder.AppendFormat("            <TipoNota>{0}</TipoNota>"							, modelPericiaCopese.TipoNota);
                oStringBuilder.AppendFormat("            <NotaReferencia>{0}</NotaReferencia>"				, modelPericiaCopese.NotaReferencia);
                oStringBuilder.AppendFormat("            <LocInstalacao>{0}</LocInstalacao>"				, modelPericiaCopese.LocInstalacao);
                oStringBuilder.AppendFormat("            <Code>{0}</Code>"									, modelPericiaCopese.Code);
                oStringBuilder.AppendFormat("            <GrpCode>{0}</GrpCode>"							, modelPericiaCopese.GrpCode);
                oStringBuilder.AppendFormat("            <Descricao>{0}</Descricao>"						, modelPericiaCopese.Descricao);
                oStringBuilder.AppendFormat("            <Notificador>{0}</Notificador>"					, modelPericiaCopese.Notificador);
                oStringBuilder.AppendFormat("            <Observacao>{0}</Observacao>"						, modelPericiaCopese.Observacao);
                oStringBuilder.AppendFormat("            <StatusNota>{0}</StatusNota>"						, modelPericiaCopese.StatusNota);
                oStringBuilder.AppendFormat("            <StatusUsuario>{0}</StatusUsuario>"				, modelPericiaCopese.StatusUsuario);
                oStringBuilder.AppendFormat("            <!--Zero or more repetitions:-->"					, modelPericiaCopese.TipoNota);
                foreach (ModelPericiaCopeseCausa item in modelPericiaCopese.Causa)
                {
                    oStringBuilder.AppendFormat("            <CAUSA>");
                    oStringBuilder.AppendFormat("               <NumeroItem>{0}</NumeroItem>"   , item.NumeroItem);
                    oStringBuilder.AppendFormat("               <GrpCodCausa>{0}</GrpCodCausa>" , item.GrpCodCausa);
                    oStringBuilder.AppendFormat("               <CodCausa>{0}</CodCausa>"       , item.CodCausa);
                    oStringBuilder.AppendFormat("            </CAUSA>");
                }    
                oStringBuilder.AppendFormat("            <!--Zero or more repetitions:-->");
                foreach(ModelPericiaCopeseAtividade item in modelPericiaCopese.Atividade)
                { 
                    oStringBuilder.AppendFormat("            <ATIVIDADES>");
                    oStringBuilder.AppendFormat("               <NumeroItem>{0}</NumeroItem>"					, item.NumeroItem);
                    oStringBuilder.AppendFormat("               <GrpCodAtividades>{0}</GrpCodAtividades>"		, item.GrpCodAtividades);
                    oStringBuilder.AppendFormat("               <CodAtividades>{0}</CodAtividades>"				, item.CodAtividades);
                    oStringBuilder.AppendFormat("               <NumeroBO>{0}</NumeroBO>"						, item.NumeroBO);
                    oStringBuilder.AppendFormat("               <DescricaoBO>{0}</DescricaoBO>"					, item.DescricaoBO);
                    oStringBuilder.AppendFormat("            </ATIVIDADES>");
                }
                oStringBuilder.AppendFormat("            <!--Zero or more repetitions:-->");
                foreach(ModelPericiaCopeseMedida item in modelPericiaCopese.Medida)
                { 
                    oStringBuilder.AppendFormat("            <MEDIDAS>");
                    oStringBuilder.AppendFormat("               <ItemMedia>{0}</ItemMedia>"						, item.ItemMedia);
                    oStringBuilder.AppendFormat("               <GrpCodMedidas>{0}</GrpCodMedidas>"				, item.GrpCodMedidas);
                    oStringBuilder.AppendFormat("               <CodMedidas>{0}</CodMedidas>"					, item.CodMedidas);
                    oStringBuilder.AppendFormat("               <FuncResposavel>{0}</FuncResposavel>"			, item.FuncResposavel);
                    oStringBuilder.AppendFormat("               <Responsavel>{0}</Responsavel>"					, item.Responsavel);
                    oStringBuilder.AppendFormat("               <StatusMedida>{0}</StatusMedida>"				, item.StatusMedida);
                    oStringBuilder.AppendFormat("               <DataMedida>{0}</DataMedida>"					, item.DataMedida);
                    oStringBuilder.AppendFormat("               <HoraMedida>{0}</HoraMedida>"					, item.HoraMedida);
                    oStringBuilder.AppendFormat("               <RGLogado>{0}</RGLogado>"						, item.RGLogado);
                    oStringBuilder.AppendFormat("               <DataProgramanda>{0}</DataProgramanda>"			, item.DataProgramanda);
                    oStringBuilder.AppendFormat("               <HoraProgramada>{0}</HoraProgramada>"			, item.HoraProgramada);
                    oStringBuilder.AppendFormat("            </MEDIDAS>");
                }
                oStringBuilder.AppendFormat("         </HEADER>");
                oStringBuilder.AppendFormat("      </urn:MT_CriarNotaPortal_request>");
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