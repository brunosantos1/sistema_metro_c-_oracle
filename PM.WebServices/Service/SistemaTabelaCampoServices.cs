using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaTabelaCampoServices
    {
        public IList<SistemaTabelaCampo> GetAll()
        {
            return SistemaTabelaCampoOperationsExtensions.GetAll(Links.appN.SistemaTabelaCampoOperations);
        }

        public SistemaTabelaCampo GetById(int id)
        {
            SistemaTabelaCampo retorno = new SistemaTabelaCampo();
            try
            {
                retorno = SistemaTabelaCampoOperationsExtensions.GetById(Links.appN.SistemaTabelaCampoOperations, id);
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

        public SistemaTabelaCampo Add(SistemaTabelaCampo _param)
        {
            SistemaTabelaCampo retorno = new SistemaTabelaCampo();
            try
            {
                retorno = SistemaTabelaCampoOperationsExtensions.Add(Links.appN.SistemaTabelaCampoOperations, _param);
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

        public bool Update(SistemaTabelaCampo _param)
        {
            return SistemaTabelaCampoOperationsExtensions.Update(Links.appN.SistemaTabelaCampoOperations, _param).Value;
        }

        public SistemaTabelaCampo DeleteById(int id)
        {
            SistemaTabelaCampo retorno = new SistemaTabelaCampo();
            try
            {
                retorno = SistemaTabelaCampoOperationsExtensions.DeleteById(Links.appN.SistemaTabelaCampoOperations, id);
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