using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class MaterialServices
    {
        public Material GetById(int id)
        {
            return MaterialsExtensions.GetById(Links.appN.Materials, id);
        }

        public List<Material> GetAll()
        {
            try
            {
                return MaterialsExtensions.GetAll(Links.appN.Materials).ToList();
            }
            catch (System.Exception)
            {
                return new List<Material>();
            }
        }

        public List<Material> GetByCentroTrabalho(int idCentroTrabalho)
        {
            try
            {
                return MaterialsExtensions.GetAll(Links.appN.Materials).ToList();
            }
            catch (System.Exception)
            {
                return new List<Material>();
            }
        }
    }
}
