using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class IntervencaoOperacaoServices
    {
        public IList<IntervencaoOperacao> GetAll()
        {
            return IntervencoesOperacaoExtensions.GetAll(Links.appN.IntervencoesOperacao);
        }

        public IntervencaoOperacao GetById(int id)
        {
            return IntervencoesOperacaoExtensions.GetById(Links.appN.IntervencoesOperacao, id);
        }

        public IList<IntervencaoOperacao> GetByOperacaoOrdem(int id)
        {
            return IntervencoesOperacaoExtensions.GetByOperacaoOrdem(Links.appN.IntervencoesOperacao, id);

        }

        public IntervencaoOperacao Add(IntervencaoOperacao _param)
        {
            return IntervencoesOperacaoExtensions.Add(Links.appN.IntervencoesOperacao, _param);
        }

        public IntervencaoOperacao Update(IntervencaoOperacao _param)
        {
            return IntervencoesOperacaoExtensions.Update(Links.appN.IntervencoesOperacao, _param);
        }

        public IntervencaoOperacao DeleteById(int id)
        {
            return IntervencoesOperacaoExtensions.DeleteById(Links.appN.IntervencoesOperacao, id);
        }
    }
}
