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
    public class ListaTarefaOperacaoComponenteService
    {
        private DatabaseContext context;

        public ListaTarefaOperacaoComponenteService()
        {
            context = new DatabaseContext();
        }

        public ListaTarefaOperacaoComponente GetByID(int id)
        {
            return context.ListaTarefaOperacaoComponenteRepository.GetById(id);
        }

        public List<ListaTarefaOperacaoComponente> GetAll()
        {
            return context.ListaTarefaOperacaoComponenteRepository.GetAll();
        }

        public List<ListaTarefaOperacaoComponente> GetByid_lt_tarefa(int id_lt_tarefa)
        {
            var result = new ListaTarefaOperacaoService().GetByid_lt_tarefa(id_lt_tarefa);
            List<ListaTarefaOperacaoComponente> retorno = new List<ListaTarefaOperacaoComponente>();

            result.ForEach(x => {
                retorno = context.ListaTarefaOperacaoComponenteRepository.AsQueryable()
                   //.Include(y => y.ListaTarefa)
                   //.Include(y => y.Operacao)
                   .Include(y => y.Material)
                   .Where(y => y.id_operacao_fk == 1)
                   .ToList();
            });
            //arrumar .Where(y => y.id_operacao_fk == 1)
            return retorno;
        }

        public ListaTarefaOperacaoComponente Delete(ListaTarefaOperacaoComponente obj)
        {
            ListaTarefaOperacaoComponente ListaTarefaOperacaoComponente = new ListaTarefaOperacaoComponente();
            ListaTarefaOperacaoComponente.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                ListaTarefaOperacaoComponente = context.ListaTarefaOperacaoComponenteRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    ListaTarefaOperacaoComponente.BaseModel.Retorno = MessageType.Success;
                    ListaTarefaOperacaoComponente.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    ListaTarefaOperacaoComponente.BaseModel.Erro = true;
                }
                else
                {
                    ListaTarefaOperacaoComponente.BaseModel.Retorno = MessageType.Warning;
                    ListaTarefaOperacaoComponente.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    ListaTarefaOperacaoComponente.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    ListaTarefaOperacaoComponente.BaseModel.Retorno = MessageType.Error;
                }

                ListaTarefaOperacaoComponente.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                ListaTarefaOperacaoComponente.BaseModel.MensagemException = e;
            }

            return ListaTarefaOperacaoComponente;
        }

        public ListaTarefaOperacaoComponente Add(ListaTarefaOperacaoComponente param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ListaTarefaOperacaoComponenteRepository.Add(param);
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

        public ListaTarefaOperacaoComponente Update(ListaTarefaOperacaoComponente param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ListaTarefaOperacaoComponenteRepository.Add(param);
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
