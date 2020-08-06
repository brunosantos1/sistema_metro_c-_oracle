using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class OrdemServices
    {
        public IList<Ordem> GetAll()
        {
            return OrdensExtensions.GetAll(Links.appN.Ordens);
        }

        public Ordem GetById(int id)
        {
            return OrdensExtensions.GetById(Links.appN.Ordens, id);
        }

        public Ordem Add(Ordem _param)
        {
            return OrdensExtensions.Add(Links.appN.Ordens, _param);
        }

        public Ordem Update(Ordem _param)
        {
            return OrdensExtensions.Update(Links.appN.Ordens, _param);
        }

        public Ordem DeleteById(int id)
        {
            return OrdensExtensions.DeleteById(Links.appN.Ordens, id);
        }
    }
}