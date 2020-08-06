using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class MaoDeObraServices
    {
        public IList<MaoDeObra> GetAll()
        {
            return MaosDeObraExtensions.GetAll(Links.appN.MaosDeObra);
        }

        public MaoDeObra GetById(int id)
        {
            return MaosDeObraExtensions.GetById(Links.appN.MaosDeObra, id);
        }

        public MaoDeObra Add(MaoDeObra _param)
        {
            return MaosDeObraExtensions.Add(Links.appN.MaosDeObra, _param);
        }
        public IList<MaoDeObra> GetByOperacaoOrdem(int id)
        {
            return MaosDeObraExtensions.GetByOperacaoOrdem(Links.appN.MaosDeObra, id);
        }
        public MaoDeObra Update(MaoDeObra _param)
        {
            return MaosDeObraExtensions.Update(Links.appN.MaosDeObra, _param);
        }

        public MaoDeObra DeleteById(int id)
        {
            return MaosDeObraExtensions.DeleteById(Links.appN.MaosDeObra, id);
        }
    }
}
