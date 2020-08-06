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
    public class EquipamentoFixo : Enumeracao
    {
        public List<Resposta> CriacaoNota(string ambiente, ModelEquipamentoFixo oEquipFixo)
        {
            List<Resposta> _retorno = new List<Resposta>();
            XmlDocument soapEnvelopeXml;

            ValidaDados_CriarNota(oEquipFixo);
            try
            {
                SOAPRequest oSOAPRequest = new SOAPRequest();
                soapEnvelopeXml = CreateSoapEnvelope_CriarNota(ambiente, oEquipFixo);
                _retorno = oSOAPRequest.Processamento("Equipamento Fixo", ambiente, soapEnvelopeXml);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Message [{0}] - Source [{1}] - StackTrace [{2}]", ex.Message, ex.Source, ex.StackTrace);
                DomainException.When(true, msg);
            }
            return _retorno;
        }
        private void ValidaDados_CriarNota(ModelEquipamentoFixo oEquipFixo)
        {
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.TipoNota), "Necessario informar tiponota ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.LocInstalacao), "Necessario informar locinstalacao ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.Code), "Necessario informar code ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.GrpCode), "Necessario informar grpcode ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.Descricao), "Necessario informar descricao ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.Prioridade), "Necessario informar prioridade ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.Notificador), "Necessario informar notificador ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.CentroTrabalho), "Necessario informar centrotrabalho ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.Centro), "Necessario informar centro ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.Observacao), "Necessario informar observacao ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.IncidenteNotavel), "Necessario informar incidentenotavel ");
            DomainException.When(string.IsNullOrEmpty(oEquipFixo.StatusNota), "Necessario informar statusnota ");
            if (!oEquipFixo.DadosLineares.Count.Equals(0))
            {
                foreach (ModelEquipamentoFixoDadosLineares item in oEquipFixo.DadosLineares)
                {
                    DomainException.When(string.IsNullOrEmpty(item.MarcoInicial), "Necessario informar MarcoInicial ");
                    DomainException.When(string.IsNullOrEmpty(item.PontoPartida), string.Format("Necessario informar PontoPartida do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.PontoFinal), string.Format("Necessario informar PontoFinal do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.UniMedLineares), string.Format("Necessario informar UniMedLineares do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.DistMarcoInicial), string.Format("Necessario informar DistMarcoInicial do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.Comprimento), string.Format("Necessario informar Comprimento do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.MarcadorFinal), string.Format("Necessario informar MarcadorFinal do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.DistMarcoFinal), string.Format("Necessario informar DistMarcoFinal do MarcoInicial [{0}]", item.MarcoInicial));
                }
            }

            if (!oEquipFixo.Medida.Count.Equals(0))
            {
                foreach (ModelEquipamentoFixoMedidas item in oEquipFixo.Medida)
                {
                    DomainException.When(string.IsNullOrEmpty(item.ItemMedia), "Necessario informar ItemMedia ");
                    DomainException.When(string.IsNullOrEmpty(item.GrpCodMedidas), string.Format("Necessario informar GrpCodMedidas do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.CodMedidas), string.Format("Necessario informar CodMedidas do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.StatusMedida), string.Format("Necessario informar StatusMedida do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.FuncResposavel), string.Format("Necessario informar FuncResposavel do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.Responsavel), string.Format("Necessario informar Responsavel do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.RGLogado), string.Format("Necessario informar RGLogado do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(DomainException.IsDate(item.DataInicio), string.Format("Necessario informar DataInicio do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.HoraInicio), string.Format("Necessario informar HoraInicio do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(DomainException.IsDate(item.DataProgramanda), string.Format("Necessario informar DataProgramanda do ItemMedia [{0}]", item.ItemMedia));
                    DomainException.When(string.IsNullOrEmpty(item.HoraProgramada), string.Format("Necessario informar HoraProgramada do ItemMedia [{0}]", item.ItemMedia));
                }
            }
        }
        private static XmlDocument CreateSoapEnvelope_CriarNota(string ambiente, ModelEquipamentoFixo oEquipFixo) //string ambiente, string tiponota, string locinstalacao, string code, string grpcode, string descricao, string prioridade, string notificador, string centrotrabalho, string centro, string observacao, string incidentenotavel, string statusnota, string marcoinicial, string pontopartida, string pontofinal, string unimedlineares, string distmarcoinicial, string comprimento, string marcadorfinal, string distmarcofinal, string itemmedia, string grpcodmedidas, string codmedidas, string statusmedida, string funcresposavel, string responsavel, string rglogado, string datainicio, string horainicio, string dataprogramanda, string horaprogramada)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            try
            {
                oStringBuilder.AppendFormat("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:Metro:Portal:Ecc:CriarNotaEquipamentoFixo\">");
                oStringBuilder.AppendFormat("   <soapenv:Header/>");
                oStringBuilder.AppendFormat("   <soapenv:Body>");
                oStringBuilder.AppendFormat("      <urn:MT_CriarNotaPortal_request>");
                oStringBuilder.AppendFormat("         <HEADER>");
                oStringBuilder.AppendFormat("            <TipoNota>{0}</TipoNota>", oEquipFixo.TipoNota);
                oStringBuilder.AppendFormat("            <LocInstalacao>{0}</LocInstalacao>", oEquipFixo.LocInstalacao);
                oStringBuilder.AppendFormat("            <Code>{0}</Code>", oEquipFixo.Code);
                oStringBuilder.AppendFormat("            <GrpCode>{0}</GrpCode>", oEquipFixo.GrpCode);
                oStringBuilder.AppendFormat("            <Descricao>{0}</Descricao>", oEquipFixo.Descricao);
                oStringBuilder.AppendFormat("            <Prioridade>{0}</Prioridade>", oEquipFixo.Prioridade);
                oStringBuilder.AppendFormat("            <Notificador>{0}</Notificador>", oEquipFixo.Notificador);
                oStringBuilder.AppendFormat("            <CentroTrabalho>{0}</CentroTrabalho>", oEquipFixo.CentroTrabalho);
                oStringBuilder.AppendFormat("            <Centro>{0}</Centro>", oEquipFixo.Centro);
                oStringBuilder.AppendFormat("            <Observacao>{0}</Observacao>", oEquipFixo.Observacao);
                oStringBuilder.AppendFormat("            <IncidenteNotavel>{0}</IncidenteNotavel>", oEquipFixo.IncidenteNotavel);
                oStringBuilder.AppendFormat("            <StatusNota>{0}</StatusNota>", oEquipFixo.StatusNota);
                if (oEquipFixo.DadosLineares.Count.Equals(0))
                {
                    oStringBuilder.AppendFormat("            <DADOSLINEARES>");
                    foreach (ModelEquipamentoFixoDadosLineares item in oEquipFixo.DadosLineares)
                    {
                        oStringBuilder.AppendFormat("               <MarcoInicial>{0}</MarcoInicial>", item.MarcoInicial);
                        oStringBuilder.AppendFormat("               <PontoPartida>{0}</PontoPartida>", item.PontoPartida);
                        oStringBuilder.AppendFormat("               <PontoFinal>{0}</PontoFinal>", item.PontoFinal);
                        oStringBuilder.AppendFormat("               <UniMedLineares>{0}</UniMedLineares>", item.UniMedLineares);
                        oStringBuilder.AppendFormat("               <DistMarcoInicial>{0}</DistMarcoInicial>", item.DistMarcoInicial);
                        oStringBuilder.AppendFormat("               <Comprimento>{0}</Comprimento>", item.Comprimento);
                        oStringBuilder.AppendFormat("               <MarcadorFinal>{0}</MarcadorFinal>", item.MarcadorFinal);
                        oStringBuilder.AppendFormat("               <DistMarcoFinal>{0}</DistMarcoFinal>", item.DistMarcoFinal);
                    }
                    oStringBuilder.AppendFormat("            </DADOSLINEARES>");
                }
                if (oEquipFixo.Medida.Count.Equals(0))
                {
                    oStringBuilder.AppendFormat("            <MEDIDAS>");
                    foreach (ModelEquipamentoFixoMedidas item in oEquipFixo.Medida)
                    {
                        oStringBuilder.AppendFormat("               <ItemMedia>{0}</ItemMedia>", item.ItemMedia);
                        oStringBuilder.AppendFormat("               <GrpCodMedidas>{0}</GrpCodMedidas>", item.GrpCodMedidas);
                        oStringBuilder.AppendFormat("               <CodMedidas>{0}</CodMedidas>", item.CodMedidas);
                        oStringBuilder.AppendFormat("               <StatusMedida>{0}</StatusMedida>", item.StatusMedida);
                        oStringBuilder.AppendFormat("               <FuncResposavel>{0}</FuncResposavel>", item.FuncResposavel);
                        oStringBuilder.AppendFormat("               <Responsavel>{0}</Responsavel>", item.Responsavel);
                        oStringBuilder.AppendFormat("               <RGLogado>{0}</RGLogado>", item.RGLogado);
                        oStringBuilder.AppendFormat("               <DataInicio>{0}</DataInicio>", item.DataInicio);
                        oStringBuilder.AppendFormat("               <HoraInicio>{0}</HoraInicio>", item.HoraInicio);
                        oStringBuilder.AppendFormat("               <DataProgramanda>{0}</DataProgramanda>", item.DataProgramanda);
                        oStringBuilder.AppendFormat("               <HoraProgramada>{0}</HoraProgramada>", item.HoraProgramada);
                    }
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