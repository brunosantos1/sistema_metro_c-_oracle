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
    public class SistemaLogOperacoesItemService
    {
        private DatabaseContext context;

        public SistemaLogOperacoesItemService()
        {
            context = new DatabaseContext();
        }

        public SistemaLogOperacoesItem GetByID(int id)
        {
            return context.SistemaLogOperacoesItemRepository.GetById(id);
        }

        public List<SistemaLogOperacoesItem> GetAll()
        {
            return context.SistemaLogOperacoesItemRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaLogOperacoesItem param = new SistemaLogOperacoesItem();

            try
            {
                param = context.SistemaLogOperacoesItemRepository.GetById(id);
                var retorno = context.SistemaLogOperacoesItemRepository.Update(param);
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

        public SistemaLogOperacoesItem Add(SistemaLogOperacoesItem param)
        {
            try
            {
                context.SistemaLogOperacoesItemRepository.Add(param);
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

        public bool Update(SistemaLogOperacoesItem param)
        {
            try
            {
                context.SistemaLogOperacoesItemRepository.Update(param);
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