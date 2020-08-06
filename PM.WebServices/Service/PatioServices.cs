using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class PatioServices
    {
        public List<Patio> GetAll()
        {
            try
            {
                return PatiosExtensions.GetAll(Links.appN.Patios).ToList();
            }
            catch (System.Exception e)
            {
                return new List<Patio>();
            }
        }
    }
}
