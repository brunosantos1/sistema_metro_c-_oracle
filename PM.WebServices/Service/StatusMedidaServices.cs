using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class StatusMedidaServices
    {
        public IList<StatusMedida> GetAll()
        {
            return StatusMedidasExtensions.GetAll(Links.appN.StatusMedidas);
        }

        public StatusMedida GetByCdSap(string cdSap)
        {
            return StatusMedidasExtensions.GetByCdSap(Links.appN.StatusMedidas, cdSap);
        }
    }
}
