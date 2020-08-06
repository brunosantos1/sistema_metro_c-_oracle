using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaUsuarioModuloServices
    {
        public IList<SistemaUsuarioModulo> GetAll()
        {
            return SistemaUsuarioModuloOperationsExtensions.GetAll(Links.appN.SistemaUsuarioModuloOperations);
        }

        public SistemaUsuarioModulo GetById(int id)
        {
            SistemaUsuarioModulo retorno = new SistemaUsuarioModulo();
            try
            {
                retorno = SistemaUsuarioModuloOperationsExtensions.GetById(Links.appN.SistemaUsuarioModuloOperations, id);
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

        public SistemaUsuarioModulo Add(SistemaUsuarioModulo _param)
        {
            SistemaUsuarioModulo retorno = new SistemaUsuarioModulo();
            try
            {
                retorno = SistemaUsuarioModuloOperationsExtensions.Add(Links.appN.SistemaUsuarioModuloOperations, _param);
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

        public bool Update(SistemaUsuarioModulo _param)
        {
            return SistemaUsuarioModuloOperationsExtensions.Update(Links.appN.SistemaUsuarioModuloOperations, _param).Value;
        }

        public SistemaUsuarioModulo DeleteById(int id)
        {
            SistemaUsuarioModulo retorno = new SistemaUsuarioModulo();
            try
            {
                retorno = SistemaUsuarioModuloOperationsExtensions.DeleteById(Links.appN.SistemaUsuarioModuloOperations, id);
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