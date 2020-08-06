using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class OperacaoOrdemServices
    {
        public IList<OperacaoOrdem> GetAll()
        {
            return OperacoesOrdemExtensions.GetAll(Links.appN.OperacoesOrdem);
        }

        public OperacaoOrdem GetById(int id)
        {
            return OperacoesOrdemExtensions.GetById(Links.appN.OperacoesOrdem, id);
        }


        public IList<OperacaoOrdem> GetByOrdem(int id)
        {
            return OperacoesOrdemExtensions.GetByOrdem(Links.appN.OperacoesOrdem, id);
        }

        public IList<OperacaoOrdem> GetNavigationPropertiesByOrdem(int id)
        {
            return OperacoesOrdemExtensions.GetNavigationPropertiesByOrdem(Links.appN.OperacoesOrdem, id);
        }

        public OperacaoOrdem Add(OperacaoOrdem _param)
        {
            return OperacoesOrdemExtensions.Add(Links.appN.OperacoesOrdem, _param);
        }

        public OperacaoOrdem Update(OperacaoOrdem _param)
        {
            return OperacoesOrdemExtensions.Update(Links.appN.OperacoesOrdem, _param);
        }

        public OperacaoOrdem DeleteById(int id)
        {
            return OperacoesOrdemExtensions.DeleteById(Links.appN.OperacoesOrdem, id);
        }
    }
}
