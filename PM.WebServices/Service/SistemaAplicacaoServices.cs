using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class SistemaAplicacaoServices
    {
        public IList<SistemaAplicacao> GetAll()
        {
            return SistemaAplicacaoOperationsExtensions.GetAll(Links.appN.SistemaAplicacaoOperations);
        }

        public SistemaAplicacao GetById(int id)
        {
            SistemaAplicacao retorno = new SistemaAplicacao();
            try
            {
                retorno = SistemaAplicacaoOperationsExtensions.GetById(Links.appN.SistemaAplicacaoOperations, id);
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

        public SistemaAplicacao Add(SistemaAplicacao _param)
        {
            SistemaAplicacao retorno = new SistemaAplicacao();
            try
            {
                retorno = SistemaAplicacaoOperationsExtensions.Add(Links.appN.SistemaAplicacaoOperations, _param);
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

        public bool Update(SistemaAplicacao _param)
        {
            return SistemaAplicacaoOperationsExtensions.Update(Links.appN.SistemaAplicacaoOperations, _param).Value;
        }

        public SistemaAplicacao DeleteById(int id)
        {
            SistemaAplicacao retorno = new SistemaAplicacao();
            try
            {
                retorno = SistemaAplicacaoOperationsExtensions.DeleteById(Links.appN.SistemaAplicacaoOperations, id);
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