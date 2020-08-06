using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class CodeServices
    {
        public IList<Code> GetAll()
        {
            return CodesExtensions.GetAll(Links.appN.Codes);
        }

        public IList<Code> GetTipoServico()
        {
            return CodesExtensions.GetTipoServico(Links.appN.Codes);
        }

        public Code GetById(int id)
        {
            return CodesExtensions.GetById(Links.appN.Codes, id);
        }

        public Code GetByCdSap(string cdSap)
        {
            try
            {
                return CodesExtensions.GetByCdSap(Links.appN.Codes, cdSap);
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
