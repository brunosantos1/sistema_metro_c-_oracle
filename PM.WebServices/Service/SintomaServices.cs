using PM.WebServices;
using PM.WebServices.Models;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SintomaServices
    {
        public IList<Code> GetAll()
        {
            return CodesExtensions.GetAll(Links.appN.Codes);
        }
    }
}
