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
    public class SistemaAplicacaoService
    {
        private DatabaseContext context;

        public SistemaAplicacaoService()
        {
            context = new DatabaseContext();
        }

        public SistemaAplicacao GetByID(int id)
        {
            return context.SistemaAplicacaoRepository.GetById(id);
        }

        public List<SistemaAplicacao> GetAll()
        {
            return context.SistemaAplicacaoRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaAplicacao param = new SistemaAplicacao();

            try
            {
                param = context.SistemaAplicacaoRepository.GetById(id);
                var retorno = context.SistemaAplicacaoRepository.Update(param);
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

        public SistemaAplicacao Add(SistemaAplicacao param)
        {
            try
            {
                context.SistemaAplicacaoRepository.Add(param);
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

        public bool Update(SistemaAplicacao param)
        {
            try
            {
                context.SistemaAplicacaoRepository.Update(param);
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