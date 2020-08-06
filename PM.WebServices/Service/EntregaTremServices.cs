using PM.WebServices;
using PM.WebServices.Models;
using PM.WebServices.Service;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM.WebServices.Service
{
    public class EntregaTremServices
    {
        public IList<EntregaTrem> GetAll()
        {
            return EntregaTremOperationsExtensions.GetAll(Links.appN.EntregaTremOperations);
        }

        public EntregaTrem GetById(int id)
        {
            return EntregaTremOperationsExtensions.GetById(Links.appN.EntregaTremOperations, id);
        }

        public EntregaTrem GetNavigationPropertiesByID(int id)
        {
            return EntregaTremOperationsExtensions.GetNavigationPropertiesByID(Links.appN.EntregaTremOperations, id);
        }        

        public EntregaTrem Add(EntregaTrem _param)
        {
            try
            {
                return EntregaTremOperationsExtensions.Add(Links.appN.EntregaTremOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public EntregaTrem LiberarEntregaTrem(EntregaTrem _param)
        {
            try
            {
                return EntregaTremOperationsExtensions.LiberarEntregaTrem(Links.appN.EntregaTremOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public EntregaTrem CancelaEntregaTrem(EntregaTrem _param)
        {
            try
            {
                return EntregaTremOperationsExtensions.CancelaEntregaTrem(Links.appN.EntregaTremOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public EntregaTrem MudarLocalEntregaTrem(EntregaTrem _param)
        {
            try
            {
                return EntregaTremOperationsExtensions.MudarLocalEntregaTrem(Links.appN.EntregaTremOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public EntregaTrem Update(EntregaTrem _param)
        {
            try
            {
                return EntregaTremOperationsExtensions.Update(Links.appN.EntregaTremOperations, _param);
            }
            catch (System.Exception e)
            {
                _param.BaseModel = new BaseModel();
                _param.BaseModel.Erro = true;
                _param.BaseModel.Retorno = (int)MessageType.Error;
                _param.BaseModel.MensagemUsuario = "Erro ao processar registro. Tente novamente mais tarde";
                _param.BaseModel.MensagemException = e;
                return _param;
            }
        }

        public IList<EntregaTrem> GetByEntrega(int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
        {
            return EntregaTremOperationsExtensions.GetByEntrega(Links.appN.EntregaTremOperations, idLinha, idPatio, idTrem, idMotivo, dtInicio, dtFinal);

        }
    }
}