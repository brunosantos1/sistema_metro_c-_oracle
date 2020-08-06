using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class DocumentoServices
    {
        public IList<Documento> GetAll()
        {
            return DocumentosExtensions.GetAll(Links.appN.Documentos);
        }

        public IList<Documento> GetByNota(int id)
        {
            return DocumentosExtensions.GetByNota(Links.appN.Documentos, id);
        }

        public IList<Documento> GetNavigationPropertiesByNota(int id)
        {
            return DocumentosExtensions.GetNavigationPropertiesByNota(Links.appN.Documentos, id);
        }

        public Documento GetById(int id)
        {
            return DocumentosExtensions.GetById(Links.appN.Documentos, id);
        }

        public Documento Add(Documento _param)
        {
            return DocumentosExtensions.Add(Links.appN.Documentos, _param);
        }

        public Documento Update(Documento _param)
        {
            return DocumentosExtensions.Update(Links.appN.Documentos, _param);
        }

        public Documento DeleteById(int id)
        {
            return DocumentosExtensions.DeleteById(Links.appN.Documentos, id);
        }
    }
}
