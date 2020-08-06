using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class TipoNotaServices
    {
        public List<TipoNota> GetAll()
        {
            try
            {
                return TipoNotasExtensions.GetAll(Links.appN.TipoNotas).ToList();
            }
            catch (System.Exception e)
            {
                return new List<TipoNota>();
            }
        }

        public TipoNota GetByCodigoSap(string cd_sap)
        {
            try
            {
                return TipoNotasExtensions.GetByCodigoSap(Links.appN.TipoNotas, cd_sap);
            }
            catch (System.Exception e)
            {
                return new TipoNota();
            }
        }
    }
}
