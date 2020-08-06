using PM.Domain.Entities.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PM.Domain.Entities
{
    [NotMapped]
    public class BaseModel
    {
        //[NotMapped]
        public bool Erro { get; set; }

        //[NotMapped]
        public MessageType Retorno { get; set; }

        //[NotMapped]
        public string MensagemUsuario { get; set; }

        public Exception MensagemException { get; set; }
    }
}
