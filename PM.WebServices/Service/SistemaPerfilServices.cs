using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaPerfilServices
    {
        public IList<SistemaPerfil> GetAll()
        {
            return SistemaPerfilOperationsExtensions.GetAll(Links.appN.SistemaPerfilOperations);
        }

        public SistemaPerfil GetById(int id)
        {
            SistemaPerfil retorno = new SistemaPerfil();
            try
            {
                retorno = SistemaPerfilOperationsExtensions.GetById(Links.appN.SistemaPerfilOperations, id);
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

        public SistemaPerfil Add(SistemaPerfil _param)
        {
            SistemaPerfil retorno = new SistemaPerfil();
            try
            {
                retorno = SistemaPerfilOperationsExtensions.Add(Links.appN.SistemaPerfilOperations, _param);
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

        public bool Update(SistemaPerfil _param)
        {
            return SistemaPerfilOperationsExtensions.Update(Links.appN.SistemaPerfilOperations, _param).Value;
        }

        public SistemaPerfil DeleteById(int id)
        {
            SistemaPerfil retorno = new SistemaPerfil();
            try
            {
                retorno = SistemaPerfilOperationsExtensions.DeleteById(Links.appN.SistemaPerfilOperations, id);
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