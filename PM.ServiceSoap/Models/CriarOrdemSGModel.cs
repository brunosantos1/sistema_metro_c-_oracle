using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PM.ServiceSoap.Models
{
    [DataContract]
    public class CriarOrdemSGModel
    {
        //[MaxLength()]
        [DataMember(Name = "TIPOORDEM", EmitDefaultValue = false)]
        public string Tipo_Ordem { get; set; }

        //[MaxLength()]
        [DataMember(Name = "TIPOSERVICO", EmitDefaultValue = false)]
        public string Tipo_Servico { get; set; }

        //[MaxLength()]
        [DataMember(Name = "DESCRICAO", EmitDefaultValue = false)]
        public string Descricao { get; set; }

        //[MaxLength()]
        [DataMember(Name = "CENTROTRABALHORESPONSAVEL", EmitDefaultValue = false)]
        public string Centro_Trabalho_Responsavel { get; set; }

        //[MaxLength()]
        [DataMember(Name = "DATAINICIO", EmitDefaultValue = false)]
        public string Data_Inicio { get; set; }

        //[MaxLength()]
        [DataMember(Name = "HORAINICIO", EmitDefaultValue = false)]
        public string Hora_Inicio { get; set; }

        //[MaxLength()]
        [DataMember(Name = "DATAFIM", EmitDefaultValue = false)]
        public string Data_Fim { get; set; }

        //[MaxLength()]
        [DataMember(Name = "HORAFIM", EmitDefaultValue = false)]
        public string Hora_Fim { get; set; }

        //[MaxLength()]
        [DataMember(Name = "LINHA", EmitDefaultValue = false)]
        public string Linha { get; set; }

        //[MaxLength()]
        [DataMember(Name = "NUMEROOPERACAO", EmitDefaultValue = false)]
        public string Numero_Operacao { get; set; }

        ////[MaxLength()]
        //[DataMember(Name = "TIPOORDEM", EmitDefaultValue = false)]
        //public string Tipo_Ordem { get; set; }
    }
}