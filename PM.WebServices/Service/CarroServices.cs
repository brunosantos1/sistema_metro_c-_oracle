using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class CarroServices
    {
        public IList<Carro> GetAll()
        {
            return CarrosExtensions.GetAll(Links.appN.Carros);
        }

        public IList<Carro> GetByTrem(int id)
        {
            return CarrosExtensions.GetByTrem(Links.appN.Carros, id);
        }

        public Carro GetById(int id)
        {
            return CarrosExtensions.GetById(Links.appN.Carros, id);
        }

        public Carro Add(Carro _param)
        {
            return CarrosExtensions.Add(Links.appN.Carros, _param);
        }

        public Carro Update(Carro _param)
        {
            return CarrosExtensions.Update(Links.appN.Carros, _param);
        }
    }
}