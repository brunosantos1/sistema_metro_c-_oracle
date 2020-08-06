using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class PatioLinhaServices
    {
        public List<PatioLinha> GetAll()
        {
            try
            {
                return PatioLinhaOperationsExtensions .GetAll(Links.appN.PatioLinhaOperations).ToList();
            }
            catch (System.Exception e)
            {
                return new List<PatioLinha>();
            }
        }

        public List<PatioLinha> GetByLinhaID(int ID)
        {
            try
            {
                return PatioLinhaOperationsExtensions.GetByLinhaId(Links.appN.PatioLinhaOperations, ID).ToList();
            }
            catch (System.Exception e)
            {
                return new List<PatioLinha>();
            }
        }
    }
}
