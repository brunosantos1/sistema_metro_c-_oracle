using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaEmpresaServices
    {
        public IList<SistemaEmpresa> GetAll()
        {
            return SistemaEmpresaOperationsExtensions.GetAll(Links.appN.SistemaEmpresaOperations);
        }

        public SistemaEmpresa GetById(int id)
        {
            SistemaEmpresa retorno = new SistemaEmpresa();
            try
            {
                retorno = SistemaEmpresaOperationsExtensions.GetById(Links.appN.SistemaEmpresaOperations, id);
            }
            catch(Exception e)
            {
                retorno.BaseModel = new BaseModel();
                retorno.BaseModel.MensagemException = e;
                retorno.BaseModel.MensagemUsuario = "Registro não existe ou foi excluído por outro usuário";
                retorno.BaseModel.Erro = true;
            }
            return retorno;
        }

        public SistemaEmpresa Add(SistemaEmpresa _param)
        {
            SistemaEmpresa retorno = new SistemaEmpresa();
            try
            {
                retorno = SistemaEmpresaOperationsExtensions.Add(Links.appN.SistemaEmpresaOperations, _param);
            }
            catch(Exception e)
            {
                retorno.BaseModel = new BaseModel();
                retorno.BaseModel.MensagemException = e;
                retorno.BaseModel.MensagemUsuario = "DESCULPE-ME, mas tivemos um problema ao inserir registro. Tente novamente mais tarde !!!";
                retorno.BaseModel.Erro = true;
            }
            return retorno;
        }

        public bool Update(SistemaEmpresa _param)
        {   
            return SistemaEmpresaOperationsExtensions.Update(Links.appN.SistemaEmpresaOperations, _param).Value;
        }

        public SistemaEmpresa DeleteById(int id)
        {
            SistemaEmpresa retorno = new SistemaEmpresa();
            try
            {
                retorno = SistemaEmpresaOperationsExtensions.DeleteById(Links.appN.SistemaEmpresaOperations, id);
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