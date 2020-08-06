using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class StatusUsuarioServices
    {
        public List<StatusUsuario> GetAll()
        {
            try
            {
                return StatusUsuariosExtensions.GetAll(Links.appN.StatusUsuarios).ToList();
            }
            catch (System.Exception)
            {
                return new List<StatusUsuario>();
            }
        }

        public StatusUsuario GetByCdSap(string sap)
        {
            try
            {
                return StatusUsuariosExtensions.GetByCdSap(Links.appN.StatusUsuarios, sap);
            }
            catch (System.Exception)
            {
                return new StatusUsuario();
            }
        }
    }
}
