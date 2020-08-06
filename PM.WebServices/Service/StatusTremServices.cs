using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class StatusTremServices
    {
        public List<StatusTrem> GetAll()
        {
            try
            {
                return StatusTremOperationsExtensions.GetAll(Links.appN.StatusTremOperations).ToList();
            }
            catch (System.Exception)
            {
                return new List<StatusTrem>();
            }
        }

        public StatusTrem GetById(int id)
        {
            try
            {
                return StatusTremOperationsExtensions.GetById(Links.appN.StatusTremOperations, id);
            }
            catch (System.Exception)
            {
                return (new StatusTrem());
            }
        }
    }
}
