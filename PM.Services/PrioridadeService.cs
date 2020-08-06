using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class PrioridadeService
    {
        private DatabaseContext context;

        public PrioridadeService()
        {
            context = new DatabaseContext();
        }

        public Prioridade GetBySintoma(int idSintoma)
        {
            Prioridade prioridade;
            List<PrioridadeSintoma> list = context.PrioridadeSintomaRepository.Find(x => x.id_code_fk == idSintoma);
            if (list.Count > 0)
            {
                prioridade = context.PrioridadeRepository.GetById(list[0].id_prioridade_fk.GetValueOrDefault());

            }
            else
            {
                prioridade = null;
            }
            return prioridade;
        }

        public Prioridade GetByID(int id)
        {
            return context.PrioridadeRepository.GetById(id);
        }

        public List<Prioridade> GetAll()
        {
            return context.PrioridadeRepository.GetAll();
        }

        public Prioridade Delete(Prioridade obj)
        {
            Prioridade prioridade = new Prioridade();
            prioridade.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                prioridade = context.PrioridadeRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    prioridade.BaseModel.Retorno = MessageType.Success;
                    prioridade.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    prioridade.BaseModel.Erro = true;
                }
                else
                {
                    prioridade.BaseModel.Retorno = MessageType.Warning;
                    prioridade.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    prioridade.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    prioridade.BaseModel.Retorno = MessageType.Error;
                }

                prioridade.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                prioridade.BaseModel.MensagemException = e;
            }

            return prioridade;
        }

        public Prioridade Add(Prioridade param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PrioridadeRepository.Add(param);
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

        public Prioridade Update(Prioridade param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PrioridadeRepository.Update(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
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
