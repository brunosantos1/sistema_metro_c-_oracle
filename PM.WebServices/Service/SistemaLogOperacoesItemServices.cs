using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaLogOperacoesItemServices
    {
        public IList<SistemaLogOperacoesItem> GetAll()
        {
            return SistemaLogOperacoesItemOperationsExtensions.GetAll(Links.appN.SistemaLogOperacoesItemOperations);
        }

        public SistemaLogOperacoesItem GetById(int id)
        {
            SistemaLogOperacoesItem retorno = new SistemaLogOperacoesItem();
            try
            {
                retorno = SistemaLogOperacoesItemOperationsExtensions.GetById(Links.appN.SistemaLogOperacoesItemOperations, id);
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

        public SistemaLogOperacoesItem Add(SistemaLogOperacoesItem _param)
        {
            SistemaLogOperacoesItem retorno = new SistemaLogOperacoesItem();
            try
            {
                retorno = SistemaLogOperacoesItemOperationsExtensions.Add(Links.appN.SistemaLogOperacoesItemOperations, _param);
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

        public bool Update(SistemaLogOperacoesItem _param)
        {
            return SistemaLogOperacoesItemOperationsExtensions.Update(Links.appN.SistemaLogOperacoesItemOperations, _param).Value;
        }

        public SistemaLogOperacoesItem DeleteById(int id)
        {
            SistemaLogOperacoesItem retorno = new SistemaLogOperacoesItem();
            try
            {
                retorno = SistemaLogOperacoesItemOperationsExtensions.DeleteById(Links.appN.SistemaLogOperacoesItemOperations, id);
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