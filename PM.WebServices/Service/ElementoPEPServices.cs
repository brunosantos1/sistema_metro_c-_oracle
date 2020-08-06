using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class ElementoPEPServices
    {
        public ElementoPEP GetById(int id)
        {
            return ElementosPEPExtensions.GetById(Links.appN.ElementosPEP, id);
        }

        public List<ElementoPEP> GetAll()
        {
            try
            {
                return ElementosPEPExtensions.GetAll(Links.appN.ElementosPEP).ToList();
            }
            catch (System.Exception e)
            {
                return new List<ElementoPEP>();
            }
        }
    }
}
