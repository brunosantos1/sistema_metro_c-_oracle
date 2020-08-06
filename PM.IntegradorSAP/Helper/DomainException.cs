using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.IntegradorSAP.Helper
{
    public class DomainException : Exception
    {      

        protected DomainException(string Error) : base(Error)
        {

        }
        public static void When(bool hasError, string error) 
        {
            if(hasError)
            {
                throw new DomainException(error);
            }

        }
        public static bool IsDate(string txtData)
        {
            DateTime resultado = DateTime.MinValue;
            if (DateTime.TryParse(txtData, out resultado))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}