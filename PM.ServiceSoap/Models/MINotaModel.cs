using System.Runtime.Serialization;

namespace PM.ServiceSoap.Models
{
    public class MINotaModel
    {
        //[MaxLength()]
        [DataMember(Name = "IFLO-TPLNR", EmitDefaultValue = false)]
        public string FrotaTremCarroSist { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-QMNUM", EmitDefaultValue = false)]
        public string Nota { get; set; }

        //[MaxLength()]
        //[DataMember(Name = "", EmitDefaultValue = false)]
        public string De { get; set; }

        //[MaxLength()]
        //[DataMember(Name = "", EmitDefaultValue = false)]
        public string Ate { get; set; }

        //[MaxLength()]
        [DataMember(Name = "J_STMAINT-ANWSO", EmitDefaultValue = false)]
        public string StatusUsuarioNota { get; set; }

        //[MaxLength()]
        [DataMember(Name = "VIQMEL-QMNAM", EmitDefaultValue = false)]
        public string Notificador { get; set; }
    }
}