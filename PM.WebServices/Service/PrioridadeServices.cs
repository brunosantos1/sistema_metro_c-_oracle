using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class PrioridadeServices
    {
        public List<Prioridade> GetAll()
        {
            try
            {
                return PrioridadesExtensions.GetAll(Links.appN.Prioridades).ToList();
            }
            catch (System.Exception)
            {
                return new List<Prioridade>();
            }
        }

        public Prioridade GetBySintoma(int idSintoma)
        {
            try
            {
                return PrioridadesExtensions.GetBySintoma(Links.appN.Prioridades, idSintoma);
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
