using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaLogLoginServices
    {
        public IList<SistemaLogLogin> GetAll()
        {
            return SistemaLogLoginOperationsExtensions.GetAll(Links.appN.SistemaLogLoginOperations);
        }

        public SistemaLogLogin GetById(int id)
        {
            SistemaLogLogin retorno = new SistemaLogLogin();
            try
            {
                retorno = SistemaLogLoginOperationsExtensions.GetById(Links.appN.SistemaLogLoginOperations, id);
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

        public SistemaLogLogin Add(SistemaLogLogin _param)
        {
            SistemaLogLogin retorno = new SistemaLogLogin();
            try
            {
                retorno = SistemaLogLoginOperationsExtensions.Add(Links.appN.SistemaLogLoginOperations, _param);
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

        public bool Update(SistemaLogLogin _param)
        {
            return SistemaLogLoginOperationsExtensions.Update(Links.appN.SistemaLogLoginOperations, _param).Value;
        }

        public SistemaLogLogin DeleteById(int id)
        {
            SistemaLogLogin retorno = new SistemaLogLogin();
            try
            {
                retorno = SistemaLogLoginOperationsExtensions.DeleteById(Links.appN.SistemaLogLoginOperations, id);
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