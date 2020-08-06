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
    public class IntervencaoOperacaoService
    {
        private DatabaseContext context;

        public IntervencaoOperacaoService()
        {
            context = new DatabaseContext();
        }

        public IntervencaoOperacao GetByID(int id)
        {
            return context.IntervencaoOperacaoRepository.GetById(id);
        }

        public List<IntervencaoOperacao> GetAll()
        {
            return context.IntervencaoOperacaoRepository.GetAll();
        }

        public List<IntervencaoOperacao> GetByOperacaoOrdem(int id)
        {
            List<IntervencaoOperacao> intervencoes = context.IntervencaoOperacaoRepository.Find(x => x.id_operacao_fk == id);
            return intervencoes;
        }

        public bool DeleteById(int id)
        {
            IntervencaoOperacao intervencaoOperacao = new IntervencaoOperacao();

            try
            {
                intervencaoOperacao = context.IntervencaoOperacaoRepository.GetById(id);
                var retorno = context.IntervencaoOperacaoRepository.Update(intervencaoOperacao);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IntervencaoOperacao Add(IntervencaoOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.IntervencaoOperacaoRepository.Add(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.Erro = true;
            }
            catch (Exception e)
            {
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
            }

            return param;
        }

        public IntervencaoOperacao Update(IntervencaoOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.IntervencaoOperacaoRepository.Add(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.Erro = true;
            }
            catch (Exception e)
            {
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
            }

            return param;
        }
    }
}