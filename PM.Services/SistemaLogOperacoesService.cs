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
    public class SistemaLogOperacoesService
    {
        private DatabaseContext context;

        public SistemaLogOperacoesService()
        {
            context = new DatabaseContext();
        }

        public SistemaLogOperacoes GetByID(int id)
        {
            return context.SistemaLogOperacoesRepository.GetById(id);
        }

        public List<SistemaLogOperacoes> GetAll()
        {
            return context.SistemaLogOperacoesRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaLogOperacoes param = new SistemaLogOperacoes();

            try
            {
                param = context.SistemaLogOperacoesRepository.GetById(id);
                var retorno = context.SistemaLogOperacoesRepository.Update(param);
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

        public SistemaLogOperacoes Add(SistemaLogOperacoes param)
        {
            try
            {
                context.SistemaLogOperacoesRepository.Add(param);
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

        public bool Update(SistemaLogOperacoes param)
        {
            try
            {
                context.SistemaLogOperacoesRepository.Update(param);
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