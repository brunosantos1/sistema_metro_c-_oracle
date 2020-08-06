using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class FrotaService
    {
        private DatabaseContext context;

        public FrotaService()
        {
            context = new DatabaseContext();
        }

        public Frota GetByID(int id)
        {
            return context.FrotaRepository.GetById(id);
        }

        public List<Frota> GetAll()
        {
            return context.FrotaRepository.GetAll();
        }

        public Frota Delete(Frota obj)
        {
            Frota frota = new Frota();
            frota.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                frota = context.FrotaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    frota.BaseModel.Retorno = MessageType.Success;
                    frota.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    frota.BaseModel.Erro = true;
                }
                else
                {
                    frota.BaseModel.Retorno = MessageType.Warning;
                    frota.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    frota.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    frota.BaseModel.Retorno = MessageType.Error;
                }

                frota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                frota.BaseModel.MensagemException = e;
            }

            return frota;
        }

        public Frota Add(Frota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.FrotaRepository.Add(param);
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

        public Frota Update(Frota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.FrotaRepository.Update(param);
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
