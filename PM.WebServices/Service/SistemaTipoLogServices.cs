using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaTipoLogServices
    {
        public IList<SistemaTipoLog> GetAll()
        {
            return SistemaTipoLogOperationsExtensions.GetAll(Links.appN.SistemaTipoLogOperations);
        }

        public SistemaTipoLog GetById(int id)
        {
            SistemaTipoLog retorno = new SistemaTipoLog();
            try
            {
                retorno = SistemaTipoLogOperationsExtensions.GetById(Links.appN.SistemaTipoLogOperations, id);
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

        public SistemaTipoLog Add(SistemaTipoLog _param)
        {
            SistemaTipoLog retorno = new SistemaTipoLog();
            try
            {
                retorno = SistemaTipoLogOperationsExtensions.Add(Links.appN.SistemaTipoLogOperations, _param);
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

        public bool Update(SistemaTipoLog _param)
        {
            return SistemaTipoLogOperationsExtensions.Update(Links.appN.SistemaTipoLogOperations, _param).Value;
        }

        public SistemaTipoLog DeleteById(int id)
        {
            SistemaTipoLog retorno = new SistemaTipoLog();
            try
            {
                retorno = SistemaTipoLogOperationsExtensions.DeleteById(Links.appN.SistemaTipoLogOperations, id);
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