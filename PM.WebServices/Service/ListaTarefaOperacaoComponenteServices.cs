using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.WebServices.Service
{
    public class ListaTarefaOperacaoComponenteServices
    {
        public List<ListaTarefaOperacaoComponente> GetAll()
        {
            try
            {
                return ListaTarefaOperacaoComponentesExtensions.GetAll(Links.appN.ListaTarefaOperacaoComponentes).ToList();
            }
            catch (System.Exception)
            {
                return new List<ListaTarefaOperacaoComponente>();
            }
        }

        public List<ListaTarefaOperacaoComponente> GetByid_lt_tarefa(int id_lt_tarefa)
        {
            try
            {
                var retorno = ListaTarefaOperacaoComponentesExtensions.GetByidlttarefa(Links.appN.ListaTarefaOperacaoComponentes, id_lt_tarefa).ToList();
                return retorno;
            }
            catch (System.Exception e)
            {
                return new List<ListaTarefaOperacaoComponente>();
            }
        }

    }
}
