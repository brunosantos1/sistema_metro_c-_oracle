using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class TremServices
    {
        public IList<Trem> GetAll()
        {
            return TremsExtensions.GetAll(Links.appN.Trems);
        }

        public IList<Trem> GetByFrota(int id)
        {
            return TremsExtensions.GetByFrota(Links.appN.Trems, id);
        }

        public IList<Trem> GetByPatioLinhaStatus(int idLinha, int idPatio, int idStatus, int Manobra)
        {
            return TremsExtensions.GetByPatioLinhaStatus(Links.appN.Trems, idLinha, idPatio, idStatus, Manobra);
        }

        public IList<Trem> GetByLinhaPatioTrem(int idLinha, int idPatio, int idTrem)
        {
            return TremsExtensions.GetByLinhaPatioTrem(Links.appN.Trems, idLinha, idPatio, idTrem);
        }

        public Trem GetById(int id)
        {
            return TremsExtensions.GetById(Links.appN.Trems, id);
        }

        public Trem Add(Trem _param)
        {
            return TremsExtensions.Add(Links.appN.Trems, _param);
        }

        public Trem Update(Trem _param)
        {
            return TremsExtensions.Update(Links.appN.Trems, _param);
        }
    }
}