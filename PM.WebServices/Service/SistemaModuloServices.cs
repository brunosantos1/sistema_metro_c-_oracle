using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaModuloServices
    {
        public IList<SistemaModulo> GetAll()
        {
            return SistemaModuloOperationsExtensions.GetAll(Links.appN.SistemaModuloOperations);
        }

        public SistemaModulo GetById(int id)
        {
            SistemaModulo retorno = new SistemaModulo();
            try
            {
                retorno = SistemaModuloOperationsExtensions.GetById(Links.appN.SistemaModuloOperations, id);
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

        public SistemaModulo Add(SistemaModulo _param)
        {
            SistemaModulo retorno = new SistemaModulo();
            try
            {
                retorno = SistemaModuloOperationsExtensions.Add(Links.appN.SistemaModuloOperations, _param);
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

        public bool Update(SistemaModulo _param)
        {
            return SistemaModuloOperationsExtensions.Update(Links.appN.SistemaModuloOperations, _param).Value;
        }

        public SistemaModulo DeleteById(int id)
        {
            SistemaModulo retorno = new SistemaModulo();
            try
            {
                retorno = SistemaModuloOperationsExtensions.DeleteById(Links.appN.SistemaModuloOperations, id);
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