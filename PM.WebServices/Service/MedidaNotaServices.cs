using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class MedidaNotaServices
    {
        public IList<MedidaNota> GetAll()
        {
            return MedidasNotaExtensions.GetAll(Links.appN.MedidasNota);
        }

        public IList<MedidaNota> GetByNota(int id)
        {
            return MedidasNotaExtensions.GetByNota(Links.appN.MedidasNota, id);
        }

        public IList<MedidaNota> GetNavigationPropertiesByNota(int id)
        {
            return MedidasNotaExtensions.GetNavigationPropertiesByNota(Links.appN.MedidasNota, id);
        }

        public MedidaNota GetById(int id)
        {
            return MedidasNotaExtensions.GetById(Links.appN.MedidasNota, id);
        }

        public MedidaNota Add(MedidaNota _param)
        {
            return MedidasNotaExtensions.Add(Links.appN.MedidasNota, _param);
        }

        public MedidaNota Update(MedidaNota _param)
        {
            return MedidasNotaExtensions.Update(Links.appN.MedidasNota, _param);
        }

        public MedidaNota DeleteById(int id)
        {
            return MedidasNotaExtensions.DeleteById(Links.appN.MedidasNota, id);
        }
    }
}
