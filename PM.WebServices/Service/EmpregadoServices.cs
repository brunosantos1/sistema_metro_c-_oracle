using PM.WebServices.Models;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class EmpregadoServices
    {
        public IList<Empregado> GetAll()
        {
            return EmpregadosExtensions.GetAll(Links.appN.Empregados);
        }

        public IList<Empregado> GetByNomeOrRG(string nome_rg)
        {
            return EmpregadosExtensions.GetByNomeOrRG(Links.appN.Empregados, nome_rg);
        }

        public Empregado GetById(int id)
        {
            return EmpregadosExtensions.GetById(Links.appN.Empregados, id);
        }

        public Empregado Add(Empregado _param)
        {
            return EmpregadosExtensions.Add(Links.appN.Empregados, _param);
        }

        public Empregado Update(Empregado _param)
        {
            return EmpregadosExtensions.Update(Links.appN.Empregados, _param);
        }
    }
}