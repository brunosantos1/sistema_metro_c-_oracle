using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaLogOperacoesServices
    {
        public IList<SistemaLogOperacoes> GetAll()
        {
            return SistemaLogOperacoesOperationsExtensions.GetAll(Links.appN.SistemaLogOperacoesOperations);
        }

        public SistemaLogOperacoes GetById(int id)
        {
            SistemaLogOperacoes retorno = new SistemaLogOperacoes();
            try
            {
                retorno = SistemaLogOperacoesOperationsExtensions.GetById(Links.appN.SistemaLogOperacoesOperations, id);
            }
            catch (Exception e)
            {
                retorno.BaseModel = new BaseModel();
                retorno.BaseModel.MensagemException = e;
                retorno.BaseModel.MensagemUsuario = "Registro não existe ou foi excluído por outro usuário";
                retorno.BaseModel.Erro = true;
            }
            return retorno;
        }

        public SistemaLogOperacoes Add(SistemaLogOperacoes _param)
        {
            SistemaLogOperacoes retorno = new SistemaLogOperacoes();
            try
            {
                retorno = SistemaLogOperacoesOperationsExtensions.Add(Links.appN.SistemaLogOperacoesOperations, _param);
            }
            catch (Exception e)
            {
                retorno.BaseModel = new BaseModel();
                retorno.BaseModel.MensagemException = e;
                retorno.BaseModel.MensagemUsuario = "DESCULPE-ME, mas tivemos um problema ao inserir registro. Tente novamente mais tarde !!!";
                retorno.BaseModel.Erro = true;
            }
            return retorno;
        }

        public bool Update(SistemaLogOperacoes _param)
        {
            return SistemaLogOperacoesOperationsExtensions.Update(Links.appN.SistemaLogOperacoesOperations, _param).Value;
        }

        public SistemaLogOperacoes DeleteById(int id)
        {
            SistemaLogOperacoes retorno = new SistemaLogOperacoes();
            try
            {
                retorno = SistemaLogOperacoesOperationsExtensions.DeleteById(Links.appN.SistemaLogOperacoesOperations, id);
            }
            catch (Exception e)
            {
                retorno.BaseModel = new BaseModel();
                retorno.BaseModel.MensagemException = e;
                retorno.BaseModel.MensagemUsuario = "Registro não existe ou foi excluído por outro usuário";
                retorno.BaseModel.Erro = true;
            }
            return retorno;
        }
    }
}