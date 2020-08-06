using PM.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.WebServices.Service
{
    public static class Links
    {
        #region Producao
        //public static PMClient appN = new PMClient(new Uri("https://PM.azurewebsites.net"));
        #endregion

        #region Homologacao
        //public static PMClient appN = new PMClient(new Uri("https://PM.azurewebsites.net"));
        #endregion

        public static PMClient appN = new PMClient(System.Web.HttpContext.Current.Request.Url);
    }
}
