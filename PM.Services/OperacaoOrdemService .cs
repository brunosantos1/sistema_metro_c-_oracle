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
    public class OperacaoOrdemService
    {
        private DatabaseContext context;

        public OperacaoOrdemService()
        {
            context = new DatabaseContext();
        }

        public OperacaoOrdem GetByID(int id)
        {
            return context.OperacaoOrdemRepository.GetById(id);
        }

        public List<OperacaoOrdem> GetByOrdem(int id)
        {
            List<OperacaoOrdem> operacoes = context.OperacaoOrdemRepository.Find(x => x.id_ordem_fk == id);
            return operacoes;
        }

        public List<OperacaoOrdem> GetNavigationPropertiesByOrdem(int id)
        {
            List<OperacaoOrdem> operacoes = context.OperacaoOrdemRepository.AsQueryable()
                .Include(x => x.StatusOperacao)
                .Include(x => x.NotaEA)
                .Include(x => x.CentroTrabalho)
                .Where(x => x.id_ordem_fk == id)
                .ToList();

            return operacoes;
        }

        public List<OperacaoOrdem> GetAll()
        {
            return context.OperacaoOrdemRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            OperacaoOrdem operacaoOrdem = new OperacaoOrdem();

            try
            {
                operacaoOrdem = context.OperacaoOrdemRepository.GetById(id);
                var retorno = context.OperacaoOrdemRepository.Update(operacaoOrdem);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public OperacaoOrdem Add(OperacaoOrdem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.OperacaoOrdemRepository.Add(param);
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

        public OperacaoOrdem Update(OperacaoOrdem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.OperacaoOrdemRepository.Add(param);
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