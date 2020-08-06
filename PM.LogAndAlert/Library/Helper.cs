using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PM.LogAndAlert.Library
{
    public static class Helper
    {
        /// <summary>
        /// Rotina usada para popular combo True/False
        /// </summary>
        /// <returns></returns>
        public static Dictionary<bool, string> IsAtivo(bool isSimNao = false)
        {
            return new Dictionary<bool, string>
                {
                    {true, string.Format("{0}", isSimNao ? "SIM" : "ATIVO")},
                    {false, string.Format("{0}", isSimNao ? "NÃO" : "INATIVO")},                    
                    // some lines skipped
                };
        }
    }
}