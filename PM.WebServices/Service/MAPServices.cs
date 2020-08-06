using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class MAPServices
    {
        public IList<MAP> GetAll()
        {
            return MAPsExtensions.GetAll(Links.appN.MAPs);
        }

        public MAP GetById(int id)
        {
            return MAPsExtensions.GetById(Links.appN.MAPs, id);
        }

        public MAP Add(MAP _param)
        {
            return MAPsExtensions.Add(Links.appN.MAPs, _param);
        }

        public IList<MAP> GetByOperacaoOrdem(int id)
        {
            return MAPsExtensions.GetByOperacaoOrdem(Links.appN.MAPs, id);
        }

        public MAP Update(MAP _param)
        {
            return MAPsExtensions.Update(Links.appN.MAPs, _param);
        }

        public MAP DeleteById(int id)
        {
            return MAPsExtensions.DeleteById(Links.appN.MAPs, id);
        }
    }
}
