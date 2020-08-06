using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class FrotaServices
    {
        public IList<Frota> GetAll()
        {
            return FrotasExtensions.GetAll(Links.appN.Frotas);
        }

        public Frota GetById(int id)
        {
            return FrotasExtensions.GetById(Links.appN.Frotas, id);
        }

        public Frota Add(Frota _param)
        {
            return FrotasExtensions.Add(Links.appN.Frotas, _param);
        }

        public Frota Update(Frota _param)
        {
            return FrotasExtensions.Update(Links.appN.Frotas, _param);
        }
    }
}