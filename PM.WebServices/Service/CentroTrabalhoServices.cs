using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class CentroTrabalhoServices
    {
        public CentroTrabalho GetById(int id)
        {
            return CentroTrabalhosExtensions.GetById(Links.appN.CentroTrabalhos, id);
        }
        public List<CentroTrabalho> GetAll()
        {
            try
            {
                return CentroTrabalhosExtensions.GetAll(Links.appN.CentroTrabalhos).ToList();
            }
            catch (System.Exception)
            {
                return new List<CentroTrabalho>();
            }
        }

        public CentroTrabalho GetByLinha(int idLinha)
        {
            return CentroTrabalhosExtensions.GetByLinha(Links.appN.CentroTrabalhos, idLinha);
        }
    }
}