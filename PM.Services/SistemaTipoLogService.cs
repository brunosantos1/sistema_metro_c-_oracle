using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using PM.Domain.Entities.Enum;

namespace PM.Services
{
    public class SistemaTipoLogService
    {
        private DatabaseContext context;

        public SistemaTipoLogService()
        {
            context = new DatabaseContext();
        }

        public SistemaTipoLog GetByID(int id)
        {
            return context.SistemaTipoLogRepository.GetById(id);
        }

        public List<SistemaTipoLog> GetAll()
        {
            return context.SistemaTipoLogRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaTipoLog param = new SistemaTipoLog();

            try
            {
                param = context.SistemaTipoLogRepository.GetById(id);
                var retorno = context.SistemaTipoLogRepository.Update(param);
                param.BaseModel.MensagemUsuario = "Registro excluído com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                return true;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel = new BaseModel();
                oBaseModel.Retorno = MessageType.Error;
                oBaseModel.MensagemUsuario = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException = e;
                param.BaseModel = oBaseModel;
                return false;
            }
        }

        public SistemaTipoLog Add(SistemaTipoLog param)
        {
            try
            {
                context.SistemaTipoLogRepository.Add(param);
                param.BaseModel.MensagemUsuario = "Registro adicionado com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel = new BaseModel();
                oBaseModel.Retorno = MessageType.Error;
                oBaseModel.MensagemUsuario = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException = e;
                param.BaseModel = oBaseModel;
            }
            return param;
        }

        public bool Update(SistemaTipoLog param)
        {
            try
            {
                context.SistemaTipoLogRepository.Update(param);
                param.BaseModel.MensagemUsuario = "Registro alterado com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                return true;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel = new BaseModel();
                oBaseModel.Retorno = MessageType.Error;
                oBaseModel.MensagemUsuario = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException = e;
                param.BaseModel = oBaseModel;
                return false;
            }
        }
    }
}