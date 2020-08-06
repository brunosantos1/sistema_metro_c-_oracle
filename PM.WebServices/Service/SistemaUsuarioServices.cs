using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaUsuarioServices
    {
        public IList<SistemaUsuario> GetAll()
        {
            return SistemaUsuarioOperationsExtensions.GetAll(Links.appN.SistemaUsuarioOperations);
        }

        public SistemaUsuario GetById(int id)
        {
            SistemaUsuario retorno = new SistemaUsuario();
            try
            {
                retorno = SistemaUsuarioOperationsExtensions.GetById(Links.appN.SistemaUsuarioOperations, id);
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

        public SistemaUsuario Add(SistemaUsuario _param)
        {
            SistemaUsuario retorno = new SistemaUsuario();
            try
            {
                retorno = SistemaUsuarioOperationsExtensions.Add(Links.appN.SistemaUsuarioOperations, _param);
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

        public bool Update(SistemaUsuario _param)
        {
            return SistemaUsuarioOperationsExtensions.Update(Links.appN.SistemaUsuarioOperations, _param).Value;
        }

        public SistemaUsuario DeleteById(int id)
        {
            SistemaUsuario retorno = new SistemaUsuario();
            try
            {
                retorno = SistemaUsuarioOperationsExtensions.DeleteById(Links.appN.SistemaUsuarioOperations, id);
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