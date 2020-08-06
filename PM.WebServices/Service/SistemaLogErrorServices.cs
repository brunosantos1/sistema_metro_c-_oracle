using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaLogErrorServices
    {
        public IList<SistemaLogError> GetAll()
        {
            return SistemaLogErrorOperationsExtensions.GetAll(Links.appN.SistemaLogErrorOperations);
        }

        public SistemaLogError GetById(int id)
        {
            SistemaLogError retorno = new SistemaLogError();
            try
            {
                retorno = SistemaLogErrorOperationsExtensions.GetById(Links.appN.SistemaLogErrorOperations, id);
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

        public SistemaLogError Add(SistemaLogError _param)
        {
            SistemaLogError retorno = new SistemaLogError();
            try
            {
                retorno = SistemaLogErrorOperationsExtensions.Add(Links.appN.SistemaLogErrorOperations, _param);
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

        public bool Update(SistemaLogError _param)
        {
            return SistemaLogErrorOperationsExtensions.Update(Links.appN.SistemaLogErrorOperations, _param).Value;
        }

        public SistemaLogError DeleteById(int id)
        {
            SistemaLogError retorno = new SistemaLogError();
            try
            {
                retorno = SistemaLogErrorOperationsExtensions.DeleteById(Links.appN.SistemaLogErrorOperations, id);
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