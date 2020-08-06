using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ListaTarefaOperacaoService
    {
        private DatabaseContext context;

        public ListaTarefaOperacaoService()
        {
            context = new DatabaseContext();
        }

        public ListaTarefaOperacao GetByID(int id)
        {
            return context.ListaTarefaOperacaoRepository.GetById(id);
        }
        
        public List<ListaTarefaOperacao> GetAll()
        {
            return context.ListaTarefaOperacaoRepository.GetAll();
        }

        public List<ListaTarefaOperacao> GetByid_lt_tarefa(int id_lt_tarefa)
        {
            return context.ListaTarefaOperacaoRepository.AsQueryable()
               .Include(x => x.ListaTarefa)
               .Where(x => x.id_lt_tarefa_fk == id_lt_tarefa)
               .ToList();
        }

        public ListaTarefaOperacao Delete(ListaTarefaOperacao obj)
        {
            ListaTarefaOperacao ListaTarefaOperacao = new ListaTarefaOperacao();
            ListaTarefaOperacao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                ListaTarefaOperacao = context.ListaTarefaOperacaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    ListaTarefaOperacao.BaseModel.Retorno = MessageType.Success;
                    ListaTarefaOperacao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    ListaTarefaOperacao.BaseModel.Erro = true;
                }
                else
                {
                    ListaTarefaOperacao.BaseModel.Retorno = MessageType.Warning;
                    ListaTarefaOperacao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    ListaTarefaOperacao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    ListaTarefaOperacao.BaseModel.Retorno = MessageType.Error;
                }

                ListaTarefaOperacao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                ListaTarefaOperacao.BaseModel.MensagemException = e;
            }

            return ListaTarefaOperacao;
        }

        public ListaTarefaOperacao Add(ListaTarefaOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ListaTarefaOperacaoRepository.Add(param);
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

        public ListaTarefaOperacao Update(ListaTarefaOperacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ListaTarefaOperacaoRepository.Add(param);
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
