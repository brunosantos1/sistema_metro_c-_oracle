using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaTabelaServices
    {
        public IList<SistemaTabela> GetAll()
        {
            return SistemaTabelaOperationsExtensions.GetAll(Links.appN.SistemaTabelaOperations);
        }

        public SistemaTabela GetById(int id)
        {
            SistemaTabela retorno = new SistemaTabela();
            try
            {
                retorno = SistemaTabelaOperationsExtensions.GetById(Links.appN.SistemaTabelaOperations, id);
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

        public SistemaTabela Add(SistemaTabela _param)
        {
            SistemaTabela retorno = new SistemaTabela();
            try
            {
                retorno = SistemaTabelaOperationsExtensions.Add(Links.appN.SistemaTabelaOperations, _param);
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

        public bool Update(SistemaTabela _param)
        {
            return SistemaTabelaOperationsExtensions.Update(Links.appN.SistemaTabelaOperations, _param).Value;
        }

        public SistemaTabela DeleteById(int id)
        {
            SistemaTabela retorno = new SistemaTabela();
            try
            {
                retorno = SistemaTabelaOperationsExtensions.DeleteById(Links.appN.SistemaTabelaOperations, id);
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