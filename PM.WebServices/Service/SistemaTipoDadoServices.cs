using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaTipoDadoServices
    {
        public IList<SistemaTipoDado> GetAll()
        {
            return SistemaTipoDadoOperationsExtensions.GetAll(Links.appN.SistemaTipoDadoOperations);
        }

        public SistemaTipoDado GetById(int id)
        {
            SistemaTipoDado retorno = new SistemaTipoDado();
            try
            {
                retorno = SistemaTipoDadoOperationsExtensions.GetById(Links.appN.SistemaTipoDadoOperations, id);
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

        public SistemaTipoDado Add(SistemaTipoDado _param)
        {
            SistemaTipoDado retorno = new SistemaTipoDado();
            try
            {
                retorno = SistemaTipoDadoOperationsExtensions.Add(Links.appN.SistemaTipoDadoOperations, _param);
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

        public bool Update(SistemaTipoDado _param)
        {
            return SistemaTipoDadoOperationsExtensions.Update(Links.appN.SistemaTipoDadoOperations, _param).Value;
        }

        public SistemaTipoDado DeleteById(int id)
        {
            SistemaTipoDado retorno = new SistemaTipoDado();
            try
            {
                retorno = SistemaTipoDadoOperationsExtensions.DeleteById(Links.appN.SistemaTipoDadoOperations, id);
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