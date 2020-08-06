using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PM.IntegradorSAP.Helper
{
    public class Enumeracao
    {
        public enum Ambiente
        {
            Desenvolvimento,
            Produção,
            Homologação,
        }
    }

    public class Resposta
    {
        public bool _status { get; set; }
        public string _codMensagem { get; set; }
        public string _mensagem { get; set; }
        public Resposta()
        {

        }
    }

    [XmlRoot("NOTAS")]
    public class RespostaNotas
    {
        [XmlElement("TipoNota")]
        public string TipoNota { get; set; }
        [XmlElement("NumeroNota")]
        public string NumeroNota { get; set; }
        [XmlElement("LocalInstalacao")]
        public string LocalInstalacao { get; set; }
        [XmlElement("Prioridade")]
        public string Prioridade { get; set; }
        [XmlElement("DataNota")]
        public string DataNota { get; set; }
        [XmlElement("HoraNota")]
        public string HoraNota { get; set; }
        [XmlElement("DescricaoNota")]
        public string DescricaoNota { get; set; }
        [XmlElement("Notificador")]
        public string Notificador { get; set; }
        [XmlElement("StatusUsuario")]
        public string StatusUsuario { get; set; }
        [XmlElement("StatusNota")]
        public string StatusNota { get; set; }
        [XmlElement("NumeroOrdem")]
        public string NumeroOrdem { get; set; }
        [XmlElement("CentroTrabalho")]
        public string CentroTrabalho { get; set; }
        [XmlElement("Centro")]
        public string Centro { get; set; }
        [XmlElement("Equipamento")]
        public string Equipamento { get; set; }
        [XmlElement("Material")]
        public string Material { get; set; }
        [XmlElement("Code")]
        public string Code { get; set; }
        [XmlElement("GrpCode")]
        public string GrpCode { get; set; }
        [XmlElement("NotaRerencia")]
        public string NotaRerencia { get; set; }
        [XmlElement("CausaRaiz")]
        public string CausaRaiz { get; set; }
        [XmlElement("Diagnostico")]
        public string Diagnostico { get; set; }
        [XmlElement("DataProcessamento")]
        public string DataProcessamento { get; set; }
        [XmlElement("HoraProcessamento")]
        public string HoraProcessamento { get; set; }
        [XmlElement("DataDesejada")]
        public string DataDesejada { get; set; }
    }
}