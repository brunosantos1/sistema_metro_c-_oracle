using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class StatusEntregaTremServices
    {
        public List<StatusEntregaTrem> GetAll()
        {
            try
            {
                return StatusEntregaTremOperationsExtensions.GetAll(Links.appN.StatusEntregaTremOperations).ToList();
            }
            catch (System.Exception)
            {
                return new List<StatusEntregaTrem>();
            }
        }

        public StatusEntregaTrem GetById(int id)
        {
            try
            {
                return StatusEntregaTremOperationsExtensions.GetById(Links.appN.StatusEntregaTremOperations, id);
            }
            catch (System.Exception)
            {
                return (new StatusEntregaTrem());
            }
        }
    }
}
