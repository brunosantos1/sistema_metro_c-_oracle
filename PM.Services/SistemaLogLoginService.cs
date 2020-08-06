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
    public class SistemaLogLoginService
    {
        private DatabaseContext context;

        public SistemaLogLoginService()
        {
            context = new DatabaseContext();
        }

        public SistemaLogLogin GetByID(int id)
        {
            return context.SistemaLogLoginRepository.GetById(id);
        }

        public List<SistemaLogLogin> GetAll()
        {
            return context.SistemaLogLoginRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaLogLogin param = new SistemaLogLogin();

            try
            {
                param = context.SistemaLogLoginRepository.GetById(id);
                var retorno = context.SistemaLogLoginRepository.Update(param);
                param.BaseModel.MensagemUsuario = "Registro excluído com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                return true;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel                  = new BaseModel();
                oBaseModel.Retorno               = MessageType.Error;
                oBaseModel.MensagemUsuario       = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException     = e;
                param.BaseModel                  = oBaseModel;
                return false;
            }
        }

        public SistemaLogLogin Add(SistemaLogLogin param)
        {
            try
            {
                context.SistemaLogLoginRepository.Add(param);
                param.BaseModel.MensagemUsuario      = "Registro adicionado com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno              = MessageType.Success;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel                  = new BaseModel();
                oBaseModel.Retorno               = MessageType.Error;
                oBaseModel.MensagemUsuario       = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException     = e;
                param.BaseModel                 = oBaseModel;
            }
            return param;
        }

        public bool Update(SistemaLogLogin param)
        {
            try
            {
                context.SistemaLogLoginRepository.Update(param);
                param.BaseModel.MensagemUsuario      = "Registro alterado com sucesso";
                context.SaveChanges();
                param.BaseModel.Retorno = MessageType.Success;
                return true;
            }
            catch (Exception e)
            {
                BaseModel oBaseModel                  = new BaseModel();
                oBaseModel.Retorno               = MessageType.Error;
                oBaseModel.MensagemUsuario       = "Erro ao processar registro tente novamente mais tarde !!!";
                oBaseModel.MensagemException     = e;
                param.BaseModel                  = oBaseModel;
                return false;
            }
        }
    }
}