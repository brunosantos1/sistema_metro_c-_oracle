using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class CatalogoServices
    {
        public List<Catalogo> GetAll()
        {
            try
            {
                return CatalogosExtensions.GetAll(Links.appN.Catalogos).ToList();
            }
            catch (System.Exception)
            {
                return new List<Catalogo>();
            }
        }
    }
}
