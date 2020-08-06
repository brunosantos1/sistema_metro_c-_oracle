using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class MaterialOperacaoServices
    {
        public IList<MaterialOperacao> GetAll()
        {
            return MateriaisOperacaoExtensions.GetAll(Links.appN.MateriaisOperacao);
        }

        public MaterialOperacao GetById(int id)
        {
            return MateriaisOperacaoExtensions.GetById(Links.appN.MateriaisOperacao, id);
        }

        public MaterialOperacao Add(MaterialOperacao _param)
        {
            return MateriaisOperacaoExtensions.Add(Links.appN.MateriaisOperacao, _param);
        }

        public IList<MaterialOperacao> GetByOperacaoOrdem(int id)
        {
            return MateriaisOperacaoExtensions.GetByOperacaoOrdem(Links.appN.MateriaisOperacao, id);
        }

        public MaterialOperacao Update(MaterialOperacao _param)
        {
            return MateriaisOperacaoExtensions.Update(Links.appN.MateriaisOperacao, _param);
        }

        public MaterialOperacao DeleteById(int id)
        {
            return MateriaisOperacaoExtensions.DeleteById(Links.appN.MateriaisOperacao, id);
        }
    }
}
