using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class PatioService
    {
        private DatabaseContext context;

        public PatioService()
        {
            context = new DatabaseContext();
        }

        public Patio GetByID(int id)
        {
            return context.PatioRepository.GetById(id);
        }

        public List<Patio> GetAll()
        {
            return context.PatioRepository.GetAll();
        }

        public Patio Delete(Patio obj)
        {
            Patio patio = new Patio();

            try
            {
                string mensagem = string.Empty;
                patio = context.PatioRepository.Delete(obj);
                patio.BaseModel.Erro = false;

                if (context.SaveChanges() > 0)
                {
                    patio.BaseModel.Retorno = MessageType.Success;
                    patio.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    patio.BaseModel.Erro = true;
                }
                else
                {
                    patio.BaseModel.Retorno = MessageType.Warning;
                    patio.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    patio.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    patio.BaseModel.Retorno = MessageType.Error;
                }

                patio.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                patio.BaseModel.MensagemException = e;
            }

            return patio;
        }

        public Patio Add_Update(Patio param)
        {
            try
            {
                param.BaseModel.Erro = false;

                if (!param.id_patio.Equals(0))
                {
                    context.PatioRepository.Update(param);
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
                }
                else
                {
                    context.PatioRepository.Add(param);
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                }
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

        public Patio Update(Patio param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PatioRepository.Update(param);
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
