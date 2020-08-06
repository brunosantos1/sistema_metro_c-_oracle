using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.WebServices.Service
{
    public class ListaTarefaServices
    {
        public List<ListaTarefa> GetAll()
        {
            try
            {
                return ListasTarefasExtensions.GetAll(Links.appN.ListasTarefas).ToList();
            }
            catch (System.Exception)
            {
                return new List<ListaTarefa>();
            }
        }

        public List<ListaTarefa> GetByEquipamentoid(int id_equipamento)
        {
            try
            {
                var retorno = ListasTarefasExtensions.GetByEquipamentoid(Links.appN.ListasTarefas, id_equipamento).ToList();
                return retorno;
            }
            catch (System.Exception e)
            {
                return new List<ListaTarefa>();
            }
        }

    }
}
