using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using System;
using System.Collections.Generic;

namespace PM.WebServices.Service
{
    public class MotivoEntregaServices
    {
        public IList<MotivoEntrega> GetAll()
        {
            return MotivoEntregaOperationsExtensions.GetAll(Links.appN.MotivoEntregaOperations);
        }

        public MotivoEntrega GetById(int id)
        {
            MotivoEntrega retorno = new MotivoEntrega();
            try
            {
                retorno = MotivoEntregaOperationsExtensions.GetById(Links.appN.MotivoEntregaOperations, id);
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

        public MotivoEntrega Add(MotivoEntrega _param)
        {
            MotivoEntrega retorno = new MotivoEntrega();
            try
            {
                retorno = MotivoEntregaOperationsExtensions.Add(Links.appN.MotivoEntregaOperations, _param);
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

        //public bool Update(MotivoEntrega _param)
        //{
        //    //return MotivoEntregaOperationsExtensions.Update(Links.appN.MotivoEntregaOperations, _param);
        //}

        //public MotivoEntrega DeleteById(int id)
        //{
        //    MotivoEntrega retorno = new MotivoEntrega();
        //    try
        //    {
        //        retorno = MotivoEntregaOperationsExtensions.DeleteById(Links.appN.MotivoEntregaOperations, id);
        //    }
        //    catch (Exception e)
        //    {
        //        retorno.BaseModel = new BaseModel();
        //        retorno.BaseModel.MensagemException = e;
        //        retorno.BaseModel.MensagemUsuario = "Registro não existe ou foi excluído por outro usuário";
        //        retorno.BaseModel.Erro = true;
        //    }
        //    return retorno;
        //}
    }
}