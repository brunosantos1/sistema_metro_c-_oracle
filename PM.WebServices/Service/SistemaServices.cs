using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM.WebServices;
using PM.WebServices.Models;

namespace PM.WebServices.Service
{
    public class SistemaServices
    {
        public IList<Sistema> GetAll()
        {
            return SistemasExtensions.GetAll(Links.appN.Sistemas);
        }

        public IList<Sistema> GetByFrota(int id)
        {
            return SistemasExtensions.GetByFrota(Links.appN.Sistemas, id);
        }

        public IList<GrupoCode> GetSistemas(int idPerfil)
        {
            return SistemasExtensions.GetSistemas(Links.appN.Sistemas, idPerfil);
        }

        public IList<Code> GetSintomas(int idSistema)
        {
            return SistemasExtensions.GetSintomas(Links.appN.Sistemas, idSistema);
        }

        public Sistema GetById(int id)
        {
            return SistemasExtensions.GetById(Links.appN.Sistemas, id);
        }

        public Sistema Add(Sistema _param)
        {
            return SistemasExtensions.Add(Links.appN.Sistemas, _param);
        }

        /*public Sistema Update(Sistema _param)
        {
            return SistemasExtensions.Update(Links.appN.Sistemas, _param);
        }*/

    }
}