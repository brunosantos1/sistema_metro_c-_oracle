using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;

namespace PM.WebServices.Service
{
    public class EquipamentoServices
    {
        public Equipamento GetById(int id)
        {
            return EquipamentosExtensions.GetById(Links.appN.Equipamentos, id);
        }

        public List<Equipamento> GetAll()
        {
            try
            {
                return EquipamentosExtensions.GetAll(Links.appN.Equipamentos).ToList();
            }
            catch (System.Exception e)
            {
                return new List<Equipamento>();
            }
        }
        public IList<Equipamento> ConsultarEFParametros(Equipamento equipamento)
        {
            return EquipamentosExtensions.ConsultarEFParametros(Links.appN.Equipamentos, equipamento);
        }
    }
}
