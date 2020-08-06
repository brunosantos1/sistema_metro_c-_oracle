using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Web.ViewModel.Enum
{
    public class Enum
    {
        public enum MedidaEnum
        {
            Aberta,
            Recebida,
            Execucao,
            Paralisada,
            Finalizada
        }
        public enum PriorizacaoEnum
        {
            Alerta,
            Critico,
            Normal
        }
    }
}