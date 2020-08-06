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
    public class ModificarNota : Enumeracao
    {   
        public List<Resposta> CriacaoNota(string ambiente, ModelModificarNota oModificarNota)
        {
            List<Resposta> _retorno = new List<Resposta>();
            XmlDocument soapEnvelopeXml;
            try
            {
                SOAPRequest oSOAPRequest = new SOAPRequest();
                ValidaDados_CriarNota(oModificarNota);
                soapEnvelopeXml = CreateSoapEnvelope_CriarNota(oModificarNota);
                _retorno = oSOAPRequest.Processamento("Modificar Nota", ambiente, soapEnvelopeXml);
            }
            catch (Exception ex)
            {
                var msg = string.Format("Message [{0}] - Source [{1}] - StackTrace [{2}]", ex.Message, ex.Source, ex.StackTrace);
                DomainException.When(true, msg);
            }
            return _retorno;
        }

        private void ValidaDados_CriarNota(ModelModificarNota oModificarNota)
        {
            DomainException.When(string.IsNullOrEmpty(oModificarNota.TipoNota), "Necessario informar TipoNota");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.NumeroNota), "Necessario informar NumeroNota");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.NumeroOrdem), "Necessario informar NumeroOrdem");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.LocInstalacao), "Necessario informar LocInstalacao");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Descricao), "Necessario informar Descricao");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.GrpCode), "Necessario informar GrpCode");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Code), "Necessario informar Code");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Prioridade), "Necessario informar Prioridade");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Notificador), "Necessario informar Notificador");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.CentroTrabalho), "Necessario informar CentroTrabalho");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Centro), "Necessario informar Centro");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.NotaReferencia), "Necessario informar NotaReferencia");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Linha), "Necessario informar Linha");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Local), "Necessario informar Local");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.CausaRaiz), "Necessario informar CausaRaiz");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.CodDiagnostico), "Necessario informar CodDiagnostico");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.AreaOperacional), "Necessario informar AreaOperacional");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.TipoManutencao), "Necessario informar TipoManutencao");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.IncidenteNotavel), "Necessario informar IncidenteNotavel");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.InterOperacional), "Necessario informar InterOperacional");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Fumaca), "Necessario informar Fumaca");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Reboque), "Necessario informar Reboque");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.StatusNota), "Necessario informar StatusNota");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.StatusUsuario), "Necessario informar StatusUsuario");
            DomainException.When(string.IsNullOrEmpty(oModificarNota.Observacao), "Necessario informar Observacao");
            //public List<ModelModificarNotaDadosItens> Itens)							, "Necessario informar TipoNota");
            //public List<ModelModificarNotaMedidasNota> MedidasNota)						, "Necessario informar TipoNota");

            if (!oModificarNota.DadosLineares.Count.Equals(0))
            {
                foreach (ModelModificarNotaDadosLineares item in oModificarNota.DadosLineares)
                {
                    DomainException.When(string.IsNullOrEmpty(item.MarcoInicial), "Necessario informar MarcoInicial");
                    DomainException.When(string.IsNullOrEmpty(item.PontoPartida), string.Format("Necessario informar PontoPartida do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.PontoFinal), string.Format("Necessario informar PontoFinal do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.UniMedLineares), string.Format("Necessario informar UniMedLineares do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.DistMarcoInicial), string.Format("Necessario informar DistMarcoInicial do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.Comprimento), string.Format("Necessario informar Comprimento do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.MarcadorFinal), string.Format("Necessario informar MarcadorFinal do MarcoInicial [{0}]", item.MarcoInicial));
                    DomainException.When(string.IsNullOrEmpty(item.DistMarcoFinal), string.Format("Necessario informar DistMarcoFinal do MarcoInicial [{0}]", item.MarcoInicial));
                }
            }

            if (!oModificarNota.Itens.Count.Equals(0))
            {
                foreach (ModelModificarNotaDadosItens item in oModificarNota.Itens)
                {
                    DomainException.When(string.IsNullOrEmpty(item.NumItem), string.Format("Necessario informar PontoPartida do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.TextoItem), string.Format("Necessario informar TextoItem do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.GrpParteObjeto), string.Format("Necessario informar GrpParteObjeto do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.CodeParteObjeto), string.Format("Necessario informar CodeParteObjeto do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.GrpProblema), string.Format("Necessario informar GrpProblema do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.CodeProblemaDano), string.Format("Necessario informar CodeProblemaDano do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.NumeroDefeitos), string.Format("Necessario informar NumeroDefeitos do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.Material), string.Format("Necessario informar Material do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.Localinstalacao), string.Format("Necessario informar Localinstalacao do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.Equipamento), string.Format("Necessario informar Equipamento do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.MarcoInicial), string.Format("Necessario informar MarcoInicial do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.PontoPartida), string.Format("Necessario informar PontoPartida do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.PontoFinal), string.Format("Necessario informar PontoFinal do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.UniMedLineares), string.Format("Necessario informar UniMedLineares do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.DistMarcoInicial), string.Format("Necessario informar DistMarcoInicial do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.Comprimento), string.Format("Necessario informar Comprimento do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.MarcadorFinal), string.Format("Necessario informar MarcadorFinal do NumItem [{0}]", item.NumItem));
                    DomainException.When(string.IsNullOrEmpty(item.DistMarcoFinal), string.Format("Necessario informar DistMarcoFinal do NumItem [{0}]", item.NumItem));
                    foreach (ModelModificarNotaCausaItem itemCausa in item.CausaItem)
                    {
                        DomainException.When(string.IsNullOrEmpty(itemCausa.NumItem), string.Format("Necessario informar Causa.NumItem [{1}] do Item [{0}]", item.NumItem, itemCausa.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemCausa.Numcausa), string.Format("Necessario informar Causa.Numcausa [{1}] do Item [{0}]", item.NumItem, itemCausa.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemCausa.GrpCausa), string.Format("Necessario informar Causa.GrpCausa [{1}] do Item [{0}]", item.NumItem, itemCausa.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemCausa.CodeCausa), string.Format("Necessario informar Causa.CodeCausa [{1}] do Item [{0}]", item.NumItem, itemCausa.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemCausa.TextoCausa), string.Format("Necessario informar Causa.TextoCausa [{1}] do Item [{0}]", item.NumItem, itemCausa.NumItem));
                    }

                    foreach (ModelModificarNotaMedidasItem itemMedida in item.MedidasItem)
                    {
                        DomainException.When(string.IsNullOrEmpty(itemMedida.NumItem), string.Format("Necessario informar MedidasItem.NumItem [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.NumMedidasItem), string.Format("Necessario informar MedidasItem.NumMedidasItem [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.GrpMedidasItem), string.Format("Necessario informar MedidasItem.GrpMedidasItem [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.CodeMedidasItem), string.Format("Necessario informar MedidasItem.CodeMedidasItem [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.StatusMedida), string.Format("Necessario informar MedidasItem.StatusMedida [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.TextoMedida), string.Format("Necessario informar MedidasItem.TextoMedida [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.FuncResposavel), string.Format("Necessario informar MedidasItem.FuncResposavel [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.Responsavel), string.Format("Necessario informar MedidasItem.Responsavel [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.RGLogado), string.Format("Necessario informar MedidasItem.RGLogado [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.DataInicio), string.Format("Necessario informar MedidasItem.DataInicio [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.HoraInicio), string.Format("Necessario informar MedidasItem.HoraInicio [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.DataProgramanda), string.Format("Necessario informar MedidasItem.DataProgramanda [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemMedida.HoraProgramada), string.Format("Necessario informar MedidasItem.HoraProgramada [{1}] do Item [{0}]", item.NumItem, itemMedida.NumItem));
                    }

                    foreach (ModelModificarNotaAcaoItem itemAcao in item.AcaoItem)
                    {
                        DomainException.When(string.IsNullOrEmpty(itemAcao.NumItem), string.Format("Necessario informar AcaoItem.NumItem [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.NumAcao), string.Format("Necessario informar AcaoItem.NumAcao [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.GrpAcao), string.Format("Necessario informar AcaoItem.GrpAcao [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.CodeAcao), string.Format("Necessario informar AcaoItem.CodeAcao [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.TextoAtividade), string.Format("Necessario informar AcaoItem.TextoAtividade [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.FatoQuantidade), string.Format("Necessario informar AcaoItem.FatoQuantidade [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.DataInicio), string.Format("Necessario informar AcaoItem.DataInicio [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.HoraInicio), string.Format("Necessario informar AcaoItem.HoraInicio [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.DataFim), string.Format("Necessario informar AcaoItem.DataFim [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                        DomainException.When(string.IsNullOrEmpty(itemAcao.HoraFim), string.Format("Necessario informar AcaoItem.HoraFim [{1}] do Item [{0}]", item.NumItem, itemAcao.NumItem));
                    }
                }
            }
        }

        private XmlDocument CreateSoapEnvelope_CriarNota(ModelModificarNota oModificarNota)
        {
            System.Text.StringBuilder oStringBuilder = new System.Text.StringBuilder();
            XmlDocument soapEnvelopeXml = new XmlDocument();
            try
            {
                oStringBuilder.AppendFormat("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:urn=\"urn:Metro:Portal:Ecc:NotaPM\">");
                oStringBuilder.AppendFormat("   <soapenv:Header/>");
                oStringBuilder.AppendFormat("   <soapenv:Body>");
                oStringBuilder.AppendFormat("      <urn:MT_ModificarNotaPortal_request>");
                oStringBuilder.AppendFormat("         <HEADER>");
                oStringBuilder.AppendFormat("            <TipoNota>{0}</TipoNota>"                      , oModificarNota.TipoNota);
                oStringBuilder.AppendFormat("            <NumeroNota>{0}</NumeroNota>"                  , oModificarNota.NumeroNota);
                oStringBuilder.AppendFormat("            <NumeroOrdem>{0}</NumeroOrdem>"                , oModificarNota.NumeroOrdem);
                oStringBuilder.AppendFormat("            <LocInstalacao>{0}</LocInstalacao>"            , oModificarNota.LocInstalacao);
                oStringBuilder.AppendFormat("            <Descricao>{0}</Descricao>"                    , oModificarNota.Descricao);
                oStringBuilder.AppendFormat("            <GrpCode>{0}</GrpCode>"                        , oModificarNota.GrpCode);
                oStringBuilder.AppendFormat("            <Code>{0}</Code>"                              , oModificarNota.Code);
                oStringBuilder.AppendFormat("            <Prioridade>{0}</Prioridade>"                  , oModificarNota.Prioridade);
                oStringBuilder.AppendFormat("            <Notificador>{0}</Notificador>"                , oModificarNota.Notificador);
                oStringBuilder.AppendFormat("            <CentroTrabalho>{0}</CentroTrabalho>"          , oModificarNota.CentroTrabalho);
                oStringBuilder.AppendFormat("            <Centro>{0}</Centro>"                          , oModificarNota.Centro);
                oStringBuilder.AppendFormat("            <NotaReferencia>{0}</NotaReferencia>"          , oModificarNota.NotaReferencia);
                oStringBuilder.AppendFormat("            <Linha>{0}</Linha>"                            , oModificarNota.Linha);
                oStringBuilder.AppendFormat("            <Local>{0}</Local>"                            , oModificarNota.Local);
                oStringBuilder.AppendFormat("            <CausaRaiz>{0}</CausaRaiz>"                    , oModificarNota.CausaRaiz);
                oStringBuilder.AppendFormat("            <CodDiagnostico>{0}</CodDiagnostico>"          , oModificarNota.CodDiagnostico);
                oStringBuilder.AppendFormat("            <AreaOperacional>{0}</AreaOperacional>"        , oModificarNota.AreaOperacional);
                oStringBuilder.AppendFormat("            <TipoManutencao>{0}</TipoManutencao>"          , oModificarNota.TipoManutencao);
                oStringBuilder.AppendFormat("            <IncidenteNotavel>{0}</IncidenteNotavel>"      , oModificarNota.IncidenteNotavel);
                oStringBuilder.AppendFormat("            <InterOperacional>{0}</InterOperacional>"      , oModificarNota.InterOperacional);
                oStringBuilder.AppendFormat("            <Fumaca>{0}</Fumaca>"                          , oModificarNota.Fumaca);
                oStringBuilder.AppendFormat("            <Reboque>{0}</Reboque>"                        , oModificarNota.Reboque);
                oStringBuilder.AppendFormat("            <StatusNota>{0}</StatusNota>"                  , oModificarNota.StatusNota);
                oStringBuilder.AppendFormat("            <StatusUsuario>{0}</StatusUsuario>"            , oModificarNota.StatusUsuario);
                oStringBuilder.AppendFormat("            <Observacao>{0}</Observacao>"                  , oModificarNota.Observacao);
                foreach (ModelModificarNotaDadosLineares item in oModificarNota.DadosLineares)
                { 
                    oStringBuilder.AppendFormat("            <DADOSLINEARES>");
                    oStringBuilder.AppendFormat("               <MarcoInicial>{0}</MarcoInicial>"           , item.MarcoInicial);
                    oStringBuilder.AppendFormat("               <PontoPartida>{0}</PontoPartida>"           , item.PontoPartida);
                    oStringBuilder.AppendFormat("               <PontoFinal>{0}</PontoFinal>"               , item.PontoFinal);
                    oStringBuilder.AppendFormat("               <UniMedLineares>{0}</UniMedLineares>"       , item.UniMedLineares);
                    oStringBuilder.AppendFormat("               <DistMarcoInicial>{0}</DistMarcoInicial>"   , item.DistMarcoInicial);
                    oStringBuilder.AppendFormat("               <Comprimento>{0}</Comprimento>"             , item.Comprimento);
                    oStringBuilder.AppendFormat("               <MarcadorFinal>{0}</MarcadorFinal>"         , item.MarcadorFinal);
                    oStringBuilder.AppendFormat("               <DistMarcoFinal>{0}</DistMarcoFinal>"       , item.DistMarcoFinal);
                    oStringBuilder.AppendFormat("            </DADOSLINEARES>");
                }
                foreach (ModelModificarNotaDadosItens item in oModificarNota.Itens)
                { 
                    oStringBuilder.AppendFormat("            <ITENS action=\"?\">");
                    oStringBuilder.AppendFormat("               <NumItem>{0}</NumItem>"                     , item.NumItem);
                    oStringBuilder.AppendFormat("               <TextoItem>{0}</TextoItem>"                 , item.TextoItem);
                    oStringBuilder.AppendFormat("               <GrpParteObjeto>{0}</GrpParteObjeto>"       , item.GrpParteObjeto);
                    oStringBuilder.AppendFormat("               <CodeParteObjeto>{0}</CodeParteObjeto>"     , item.CodeParteObjeto);
                    oStringBuilder.AppendFormat("               <GrpProblema>{0}</GrpProblema>"             , item.GrpProblema);
                    oStringBuilder.AppendFormat("               <CodeProblemaDano>{0}</CodeProblemaDano>"   , item.CodeProblemaDano);
                    oStringBuilder.AppendFormat("               <NumeroDefeitos>{0}</NumeroDefeitos>"       , item.NumeroDefeitos);
                    oStringBuilder.AppendFormat("               <Material>{0}</Material>"                   , item.Material);
                    oStringBuilder.AppendFormat("               <Localinstalacao>{0}</Localinstalacao>"     , item.Localinstalacao);
                    oStringBuilder.AppendFormat("               <Equipamento>{0}</Equipamento>"             , item.Equipamento);
                    oStringBuilder.AppendFormat("               <MarcoInicial>{0}</MarcoInicial>"           , item.MarcoInicial);
                    oStringBuilder.AppendFormat("               <PontoPartida>{0}</PontoPartida>"           , item.PontoPartida);
                    oStringBuilder.AppendFormat("               <PontoFinal>{0}</PontoFinal>"               , item.PontoFinal);
                    oStringBuilder.AppendFormat("               <UniMedLineares>{0}</UniMedLineares>"       , item.UniMedLineares);
                    oStringBuilder.AppendFormat("               <DistMarcoInicial>{0}</DistMarcoInicial>"   , item.DistMarcoInicial);
                    oStringBuilder.AppendFormat("               <Comprimento>{0}</Comprimento>"             , item.Comprimento);
                    oStringBuilder.AppendFormat("               <MarcadorFinal>{0}</MarcadorFinal>"         , item.MarcadorFinal);
                    oStringBuilder.AppendFormat("               <DistMarcoFinal>{0}</DistMarcoFinal>"       , item.DistMarcoFinal);
                    foreach (ModelModificarNotaCausaItem itemCausa in item.CausaItem)
                    { 
                        oStringBuilder.AppendFormat("               <CAUSAITEM action=\"?\">");
                        oStringBuilder.AppendFormat("                  <NumItem>{0}</NumItem>"                  , itemCausa.NumItem);
                        oStringBuilder.AppendFormat("                  <Numcausa>{0}</Numcausa>"                , itemCausa.Numcausa);
                        oStringBuilder.AppendFormat("                  <GrpCausa>{0}</GrpCausa>"                , itemCausa.GrpCausa);
                        oStringBuilder.AppendFormat("                  <CodeCausa>{0}</CodeCausa>"              , itemCausa.CodeCausa);
                        oStringBuilder.AppendFormat("                  <TextoCausa>{0}</TextoCausa>"            , itemCausa.TextoCausa);
                        oStringBuilder.AppendFormat("               </CAUSAITEM>");
                    }
                    foreach (ModelModificarNotaMedidasItem itemMedida in item.MedidasItem)
                    { 
                        oStringBuilder.AppendFormat("               <MEDIDASITEM action=\"?\">");
                        oStringBuilder.AppendFormat("                  <NumMedidasItem>{0}</NumMedidasItem>"    , itemMedida.NumMedidasItem);
                        oStringBuilder.AppendFormat("                  <NumItem>{0}</NumItem>"                  , itemMedida.NumItem);
                        oStringBuilder.AppendFormat("                  <GrpMedidasItem>{0}</GrpMedidasItem>"    , itemMedida.GrpMedidasItem);
                        oStringBuilder.AppendFormat("                  <CodeMedidasItem>{0}</CodeMedidasItem>"  , itemMedida.CodeMedidasItem);
                        oStringBuilder.AppendFormat("                  <StatusMedida>{0}</StatusMedida>"        , itemMedida.StatusMedida);
                        oStringBuilder.AppendFormat("                  <TextoMedida>{0}</TextoMedida>"          , itemMedida.TextoMedida);
                        oStringBuilder.AppendFormat("                  <FuncResposavel>{0}</FuncResposavel>"    , itemMedida.FuncResposavel);
                        oStringBuilder.AppendFormat("                  <Responsavel>{0}</Responsavel>"          , itemMedida.Responsavel);
                        oStringBuilder.AppendFormat("                  <RGLogado>{0}</RGLogado>"                , itemMedida.RGLogado);
                        oStringBuilder.AppendFormat("                  <DataInicio>{0}</DataInicio>"            , itemMedida.DataInicio);
                        oStringBuilder.AppendFormat("                  <HoraInicio>{0}</HoraInicio>"            , itemMedida.HoraInicio);
                        oStringBuilder.AppendFormat("                  <DataProgramanda>{0}</DataProgramanda>"  , itemMedida.DataProgramanda);
                        oStringBuilder.AppendFormat("                  <HoraProgramada>{0}</HoraProgramada>"    , itemMedida.HoraProgramada);
                        oStringBuilder.AppendFormat("               </MEDIDASITEM>");
                    }
                    foreach (ModelModificarNotaAcaoItem itemAcao in item.AcaoItem)
                    { 
                        oStringBuilder.AppendFormat("               <ACAOITEM action=\"?\">");
                        oStringBuilder.AppendFormat("                  <Numacao>{0}</Numacao>"                  , itemAcao.NumAcao);
                        oStringBuilder.AppendFormat("                  <NumItem>{0}</NumItem>"                  , itemAcao.NumItem);
                        oStringBuilder.AppendFormat("                  <GrpAcao>{0}</GrpAcao>"                  , itemAcao.GrpAcao);
                        oStringBuilder.AppendFormat("                  <CodeAcao>{0}</CodeAcao>"                , itemAcao.CodeAcao);
                        oStringBuilder.AppendFormat("                  <TextoAtividade>{0}</TextoAtividade>"    , itemAcao.TextoAtividade);
                        oStringBuilder.AppendFormat("                  <FatoQuantidade>{0}</FatoQuantidade>"    , itemAcao.FatoQuantidade);
                        oStringBuilder.AppendFormat("                  <DataInicio>{0}</DataInicio>"            , itemAcao.DataInicio);
                        oStringBuilder.AppendFormat("                  <HoraInicio>{0}</HoraInicio>"            , itemAcao.HoraInicio);
                        oStringBuilder.AppendFormat("                  <DataFim>{0}</DataFim>"                  , itemAcao.DataFim);
                        oStringBuilder.AppendFormat("                  <HoraFim>{0}</HoraFim>"                  , itemAcao.HoraFim);
                        oStringBuilder.AppendFormat("               </ACAOITEM>");
                    }
                    oStringBuilder.AppendFormat("            </ITENS>");
                }
                foreach (ModelModificarNotaMedidasNota itemMedidasNota in oModificarNota.MedidasNota)
                { 
                    oStringBuilder.AppendFormat("            <MEDIDASNOTA action=\"?\">");
                    oStringBuilder.AppendFormat("               <NumMedida>{0}</NumMedida>"                 , itemMedidasNota.NumMedida);
                    oStringBuilder.AppendFormat("               <GrpCodMedidas>{0}</GrpCodMedidas>"         , itemMedidasNota.GrpCodMedidas);
                    oStringBuilder.AppendFormat("               <CodMedidas>{0}</CodMedidas>"               , itemMedidasNota.CodMedidas);
                    oStringBuilder.AppendFormat("               <StatusMedida>{0}</StatusMedida>"           , itemMedidasNota.StatusMedida);
                    oStringBuilder.AppendFormat("               <TextoMedidas>{0}</TextoMedidas>"           , itemMedidasNota.TextoMedidas);
                    oStringBuilder.AppendFormat("               <FuncResposavel>{0}</FuncResposavel>"       , itemMedidasNota.FuncResposavel);
                    oStringBuilder.AppendFormat("               <Responsavel>{0}</Responsavel>"             , itemMedidasNota.Responsavel);
                    oStringBuilder.AppendFormat("               <RGLogado>{0}</RGLogado>"                   , itemMedidasNota.RGLogado);
                    oStringBuilder.AppendFormat("               <DataInicio>{0}</DataInicio>"               , itemMedidasNota.DataInicio);
                    oStringBuilder.AppendFormat("               <HoraInicio>{0}</HoraInicio>"               , itemMedidasNota.HoraInicio);
                    oStringBuilder.AppendFormat("               <DataProgramanda>{0}</DataProgramanda>"     , itemMedidasNota.DataProgramanda);
                    oStringBuilder.AppendFormat("               <HoraProgramada>{0}</HoraProgramada>"       , itemMedidasNota.HoraProgramada);
                    oStringBuilder.AppendFormat("            </MEDIDASNOTA>");
                }
                oStringBuilder.AppendFormat("         </HEADER>");
                oStringBuilder.AppendFormat("      </urn:MT_ModificarNotaPortal_request>");
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