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
    public class ListaTarefaService
    {
        private DatabaseContext context;

        public ListaTarefaService()
        {
            context = new DatabaseContext();
        }

        public ListaTarefa GetByID(int id)
        {
            return context.ListaTarefaRepository.GetById(id);
        }
        public List<ListaTarefa> GetByEquipamentoid(int id_equipamento)
        {
            return context.ListaTarefaRepository.AsQueryable()
                .Where(x => x.cd_equipamento_fk == id_equipamento)
                .ToList();
        }

        public List<ListaTarefa> GetAll()
        {
            return context.ListaTarefaRepository.GetAll();
        }

        public ListaTarefa Delete(ListaTarefa obj)
        {
            ListaTarefa ListaTarefa = new ListaTarefa();
            ListaTarefa.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                ListaTarefa = context.ListaTarefaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    ListaTarefa.BaseModel.Retorno = MessageType.Success;
                    ListaTarefa.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    ListaTarefa.BaseModel.Erro = true;
                }
                else
                {
                    ListaTarefa.BaseModel.Retorno = MessageType.Warning;
                    ListaTarefa.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    ListaTarefa.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    ListaTarefa.BaseModel.Retorno = MessageType.Error;
                }

                ListaTarefa.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                ListaTarefa.BaseModel.MensagemException = e;
            }

            return ListaTarefa;
        }

        public ListaTarefa Add(ListaTarefa param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ListaTarefaRepository.Add(param);
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

        public ListaTarefa Update(ListaTarefa param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ListaTarefaRepository.Add(param);
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
