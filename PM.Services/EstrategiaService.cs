using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class EstrategiaService
    {
        private DatabaseContext context;

        public EstrategiaService()
        {
            context = new DatabaseContext();
        }

        public Estrategia GetByID(int id)
        {
            return context.EstrategiaRepository.GetById(id);
        }

        public List<Estrategia> GetAll()
        {
            return context.EstrategiaRepository.GetAll();
        }

        public Estrategia Delete(Estrategia obj)
        {
            Estrategia estrategia = new Estrategia();
            estrategia.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                estrategia = context.EstrategiaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    estrategia.BaseModel.Retorno = MessageType.Success;
                    estrategia.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    estrategia.BaseModel.Erro = true;
                }
                else
                {
                    estrategia.BaseModel.Retorno = MessageType.Warning;
                    estrategia.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    estrategia.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    estrategia.BaseModel.Retorno = MessageType.Error;
                }

                estrategia.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                estrategia.BaseModel.MensagemException = e;
            }

            return estrategia;
        }

        public Estrategia Add(Estrategia param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EstrategiaRepository.Add(param);
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

        public Estrategia Update(Estrategia param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EstrategiaRepository.Add(param);
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
