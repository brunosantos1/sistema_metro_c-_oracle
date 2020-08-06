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
    public class MaterialRodante : Enumeracao
    {   
        public List<Resposta> CriacaoNota(string ambiente, ModelMaterialRodante oMaterialRodante)
        {
            List<Resposta> _retorno = new List<Resposta>();
            XmlDocument soapEnvelopeXml;
            try
            {
                SOAPRequest oSOAPRequest = new SOAPRequest();
                ValidaDados_CriarNota(oMaterialRodante);
                soapEnvelopeXml = CreateSoapEnvelope_CriarNota(oMaterialRodante);
                _retorno = oSOAPRequest.Processamento("Material Rodante", ambiente, soapEnvelopeXml);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Message [{0}] - Source [{1}] - StackTrace [{2}]", ex.Message, ex.Source, ex.StackTrace);
                DomainException.When(true, msg);
            }
            return _retorno;
        }

        private void ValidaDados_CriarNota(ModelMaterialRodante oMaterialRodante)
        {
            // As linhas comentadas é pq. não são dados obrigatórios
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.TipoNota), "Necessario informar TipoNota");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.LocInstalacao), "Necessario informar LocInstalacao ");

            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Code)             , "Necessario informar Code ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.GrpCode)          , "Necessario informar GrpCode ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Descricao)        , "Necessario informar Descricao ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Prioridade)       , "Necessario informar Prioridade ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Notificador)      , "Necessario informar Notificador ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Linha)            , "Necessario informar Linha ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Local)            , "Necessario informar Local ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.CentroTrabalho)   , "Necessario informar CentroTrabalho ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Centro)           , "Necessario informar Centro ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Observacao)       , "Necessario informar Observacao ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.InterOperacional) , "Necessario informar InterOperacional ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.IncidenteNotavel) , "Necessario informar IncidenteNotavel ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.Fumaca)           , "Necessario informar Fumaca ");
            //DomainException.When(string.IsNullOrEmpty(oMaterialRodante.TipoManutencao)   , "Necessario informar TipoManutencao ");
            DomainException.When(string.IsNullOrEmpty(oMaterialRodante.StatusNota)       , "Necessario informar StatusNota ");
            //DomainException.When(string.IsNullOrEmpty(oMaterialRodante.StatusUsuario)    , "Necessario informar StatusUsuario ");
            if(!oMaterialRodante.Medida.Count.Equals(0))
            {
                foreach(ModelMaterialRodanteMedida item in oMaterialRodante.Medida)
                { 
                    DomainException.When(string.IsNullOrEmpty(item.ItemMedia)        , "Necessario informar itemmedia ");
                    DomainException.When(string.IsNullOrEmpty(item.GrpCodMedidas)    , string.Format("Necessario informar Grpcodmedidas do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.CodMedidas)       , string.Format("Necessario informar CodMedidas do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.StatusMedida)     , string.Format("Necessario informar StatusMedida do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(DomainException.IsDate(item.DataInicio)     , string.Format("Necessario informar DataInicio ou formato data esta invalido do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.HoraInicio)       , string.Format("Necessario informar HoraInicio do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.FuncResposavel)   , string.Format("Necessario informar FuncResposavel do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.Responsavel)      , string.Format("Necessario informar Responsavel do Item Medida [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.RGLogado)         , string.Format("Necessario informar RgLogado do Item Medida [{0}]", item.ItemMedia));
                    //DomainException.When(string.IsNullOrEmpty(item.DataProgramanda)  , string.Format("Necessario informar DataProgramanda do Item Medida [{0}]", item.ItemMedia));
                    //DomainException.When(string.IsNullOrEmpty(item.HoraProgramada)   , string.Format("Necessario informar HoraProgramada do Item Medida [{0}]", item.ItemMedia));
                }
            }
            DomainException.When(oMaterialRodante.Medida.Count.Equals(0), "Necessario informar Medidas ");
        }

        private XmlDocument CreateSoapEnvelope_CriarNota(ModelMaterialRodante oMaterialRodante)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            try
            {
                oStringBuilder.AppendFormat("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:Metro:Portal:Ecc:CriarNotaMaterialRodante\">");
                oStringBuilder.AppendFormat("   <soapenv:Header/>");
                oStringBuilder.AppendFormat("   <soapenv:Body>");
                oStringBuilder.AppendFormat("      <urn:MT_CriarNotaPortal_request>");
                oStringBuilder.AppendFormat("         <HEADER>");
                oStringBuilder.AppendFormat("            <TipoNota>{0}</TipoNota>"                      , oMaterialRodante.TipoNota);
                oStringBuilder.AppendFormat("            <LocInstalacao>{0}</LocInstalacao>"            , oMaterialRodante.LocInstalacao);
                oStringBuilder.AppendFormat("            <Code>{0}</Code>"                              , oMaterialRodante.Code);
                oStringBuilder.AppendFormat("            <GrpCode>{0}</GrpCode>"                        , oMaterialRodante.GrpCode);
                oStringBuilder.AppendFormat("            <Descricao>{0}</Descricao>"                    , oMaterialRodante.Descricao);
                oStringBuilder.AppendFormat("            <Prioridade>{0}</Prioridade>"                  , oMaterialRodante.Prioridade);
                oStringBuilder.AppendFormat("            <Notificador>{0}</Notificador>"                , oMaterialRodante.Notificador);
                oStringBuilder.AppendFormat("            <Linha>{0}</Linha>"                            , oMaterialRodante.Linha);
                oStringBuilder.AppendFormat("            <Local>{0}</Local>"                            , oMaterialRodante.Local);
                oStringBuilder.AppendFormat("            <CentroTrabalho>{0}</CentroTrabalho>"          , oMaterialRodante.CentroTrabalho);
                oStringBuilder.AppendFormat("            <Centro>{0}</Centro>"                          , oMaterialRodante.Centro);
                oStringBuilder.AppendFormat("            <Observacao>{0}</Observacao>"                  , oMaterialRodante.Observacao);
                oStringBuilder.AppendFormat("            <InterOperacional>{0}</InterOperacional>"      , oMaterialRodante.InterOperacional);
                oStringBuilder.AppendFormat("            <IncidenteNotavel>{0}</IncidenteNotavel>"      , oMaterialRodante.IncidenteNotavel);
                oStringBuilder.AppendFormat("            <Fumaca>{0}</Fumaca>"                          , oMaterialRodante.Fumaca);
                oStringBuilder.AppendFormat("            <TipoManutencao>{0}</TipoManutencao>"          , oMaterialRodante.TipoManutencao);
                oStringBuilder.AppendFormat("            <StatusNota>{0}</StatusNota>"                  , oMaterialRodante.StatusNota);
                oStringBuilder.AppendFormat("            <StatusUsuario>{0}</StatusUsuario>"            , oMaterialRodante.StatusUsuario);
                if (!oMaterialRodante.Medida.Count().Equals(0))
                {
                    
                    foreach (ModelMaterialRodanteMedida item in oMaterialRodante.Medida)
                    {
                        oStringBuilder.AppendFormat("            <MEDIDAS>");
                        oStringBuilder.AppendFormat("               <NumMedida>{0:0000}</NumMedida>", int.Parse(item.ItemMedia));
                        oStringBuilder.AppendFormat("               <GrpCodMedidas>{0}</GrpCodMedidas>"     , item.GrpCodMedidas);
                        oStringBuilder.AppendFormat("               <CodMedidas>{0}</CodMedidas>"           , item.CodMedidas);
                        oStringBuilder.AppendFormat("               <StatusMedida>{0}</StatusMedida>"       , item.StatusMedida);
                        oStringBuilder.AppendFormat("               <DataInicio>{0}</DataInicio>"           , item.DataInicio);
                        oStringBuilder.AppendFormat("               <HoraInicio>{0}</HoraInicio>"           , item.HoraInicio);
                        oStringBuilder.AppendFormat("               <FuncResposavel>{0}</FuncResposavel>"   , item.FuncResposavel);
                        oStringBuilder.AppendFormat("               <Responsavel>{0}</Responsavel>"         , item.Responsavel);
                        oStringBuilder.AppendFormat("               <RGLogado>{0}</RGLogado>"               , item.RGLogado);
                        oStringBuilder.AppendFormat("               <DataProgramanda>{0}</DataProgramanda>" , item.DataProgramanda);
                        oStringBuilder.AppendFormat("               <HoraProgramada>{0}</HoraProgramada>"   , item.HoraProgramada);
                        oStringBuilder.AppendFormat("            </MEDIDAS>");
                    }                    
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