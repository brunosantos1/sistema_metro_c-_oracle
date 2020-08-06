using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaPerfilItemServices
    {
        public IList<SistemaPerfilItem> GetAll()
        {
            return SistemaPerfilItemOperationsExtensions.GetAll(Links.appN.SistemaPerfilItemOperations);
        }

        public SistemaPerfilItem GetById(int id)
        {
            SistemaPerfilItem retorno = new SistemaPerfilItem();
            try
            {
                retorno = SistemaPerfilItemOperationsExtensions.GetById(Links.appN.SistemaPerfilItemOperations, id);
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

        public SistemaPerfilItem Add(SistemaPerfilItem _param)
        {
            SistemaPerfilItem retorno = new SistemaPerfilItem();
            try
            {
                retorno = SistemaPerfilItemOperationsExtensions.Add(Links.appN.SistemaPerfilItemOperations, _param);
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

        public bool Update(SistemaPerfilItem _param)
        {
            return SistemaPerfilItemOperationsExtensions.Update(Links.appN.SistemaPerfilItemOperations, _param).Value;
        }

        public SistemaPerfilItem DeleteById(int id)
        {
            SistemaPerfilItem retorno = new SistemaPerfilItem();
            try
            {
                retorno = SistemaPerfilItemOperationsExtensions.DeleteById(Links.appN.SistemaPerfilItemOperations, id);
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