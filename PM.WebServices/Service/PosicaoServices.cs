using PM.WebServices;
using PM.WebServices.Models;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class PosicaoServices
    {
        public IList<Posicao> GetAll()
        {
            return PosicoesExtensions.GetAll(Links.appN.Posicoes);
        }
        public Posicao GetById(int id)
        {
            return PosicoesExtensions.GetById(Links.appN.Posicoes, id);
        }

        public IList<Posicao> GetByComplemento(int idComplemento)
        {
            return PosicoesExtensions.GetByComplemento(Links.appN.Posicoes, idComplemento);
        }
    }
}
