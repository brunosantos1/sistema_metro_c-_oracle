using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.IntegradorSAP.Model
{
    public class ModelModificarNota
    {
        public string TipoNota { get; set; }
        public string NumeroNota { get; set; }
        public string NumeroOrdem { get; set; }
        public string LocInstalacao { get; set; }
        public string Descricao { get; set; }
        public string GrpCode { get; set; }
        public string Code { get; set; }
        public string Prioridade { get; set; }
        public string Notificador { get; set; }
        public string CentroTrabalho { get; set; }
        public string Centro { get; set; }
        public string NotaReferencia { get; set; }
        public string Linha { get; set; }
        public string Local { get; set; }
        public string CausaRaiz { get; set; }
        public string CodDiagnostico { get; set; }
        public string AreaOperacional { get; set; }
        public string TipoManutencao { get; set; }
        public string IncidenteNotavel { get; set; }
        public string InterOperacional { get; set; }
        public string Fumaca { get; set; }
        public string Reboque { get; set; }
        public string StatusNota { get; set; }
        public string StatusUsuario { get; set; }
        public string Observacao { get; set; }
        public List<ModelModificarNotaDadosLineares> DadosLineares { get; set; }
        public List<ModelModificarNotaDadosItens> Itens { get; set; }
        public List<ModelModificarNotaMedidasNota> MedidasNota { get; set; }
    }
    public class ModelModificarNotaDadosLineares
    {
        public string MarcoInicial { get; set; }
        public string PontoPartida { get; set; }
        public string PontoFinal { get; set; }
        public string UniMedLineares { get; set; }
        public string DistMarcoInicial { get; set; }
        public string Comprimento { get; set; }
        public string MarcadorFinal { get; set; }
        public string DistMarcoFinal { get; set; }

    }
    public class ModelModificarNotaDadosItens
    {
        public string NumItem { get; set; }
        public string TextoItem { get; set; }
        public string GrpParteObjeto { get; set; }
        public string CodeParteObjeto { get; set; }
        public string GrpProblema { get; set; }
        public string CodeProblemaDano { get; set; }
        public string NumeroDefeitos { get; set; }
        public string Material { get; set; }
        public string Localinstalacao { get; set; }
        public string Equipamento { get; set; }
        public string MarcoInicial { get; set; }
        public string PontoPartida { get; set; }
        public string PontoFinal { get; set; }
        public string UniMedLineares { get; set; }
        public string DistMarcoInicial { get; set; }
        public string Comprimento { get; set; }
        public string MarcadorFinal { get; set; }
        public string DistMarcoFinal { get; set; }
        public List<ModelModificarNotaCausaItem> CausaItem { get; set; }
        public List<ModelModificarNotaMedidasItem> MedidasItem { get; set; }
        public List<ModelModificarNotaAcaoItem> AcaoItem { get; set; }
    }
    public class ModelModificarNotaCausaItem
    {
        public string NumItem { get; set; }
        public string Numcausa { get; set; }
        public string GrpCausa { get; set; }
        public string CodeCausa { get; set; }
        public string TextoCausa { get; set; }
    }
    public class ModelModificarNotaMedidasItem
    {
        public string NumMedidasItem { get; set; }
        public string NumItem { get; set; }
        public string GrpMedidasItem { get; set; }
        public string CodeMedidasItem { get; set; }
        public string StatusMedida { get; set; }
        public string TextoMedida { get; set; }
        public string FuncResposavel { get; set; }
        public string Responsavel { get; set; }
        public string RGLogado { get; set; }
        public string DataInicio { get; set; }
        public string HoraInicio { get; set; }
        public string DataProgramanda { get; set; }
        public string HoraProgramada { get; set; }
    }
    public class ModelModificarNotaAcaoItem
    {
        public string NumItem { get; set; }
        public string NumAcao { get; set; }        
        public string GrpAcao { get; set; }
        public string CodeAcao { get; set; }
        public string TextoAtividade { get; set; }
        public string FatoQuantidade { get; set; }
        public string DataInicio { get; set; }
        public string HoraInicio { get; set; }
        public string DataFim { get; set; }
        public string HoraFim { get; set; }
    }
    public class ModelModificarNotaMedidasNota
    {
        public string NumMedida { get; set; }
        public string GrpCodMedidas { get; set; }
        public string CodMedidas { get; set; }
        public string StatusMedida { get; set; }
        public string TextoMedidas { get; set; }
        public string FuncResposavel { get; set; }
        public string Responsavel { get; set; }
        public string RGLogado { get; set; }
        public string DataInicio { get; set; }
        public string HoraInicio { get; set; }
        public string DataProgramanda { get; set; }
        public string HoraProgramada { get; set; }
    }
}