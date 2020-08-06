using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ParceiroService
    {
        private DatabaseContext context;

        public ParceiroService()
        {
            context = new DatabaseContext();
        }

        public Parceiro GetByID(int id)
        {
            return context.ParceiroRepository.GetById(id);
        }

        public List<Parceiro> GetAll()
        {
            return context.ParceiroRepository.GetAll();
        }

        public Parceiro Delete(Parceiro obj)
        {
            Parceiro Parceiro = new Parceiro();
            Parceiro.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                Parceiro = context.ParceiroRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    Parceiro.BaseModel.Retorno = MessageType.Success;
                    Parceiro.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    Parceiro.BaseModel.Erro = true;
                }
                else
                {
                    Parceiro.BaseModel.Retorno = MessageType.Warning;
                    Parceiro.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    Parceiro.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    Parceiro.BaseModel.Retorno = MessageType.Error;
                }

                Parceiro.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                Parceiro.BaseModel.MensagemException = e;
            }

            return Parceiro;
        }

        public Parceiro Add(Parceiro param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ParceiroRepository.Add(param);
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

        public Parceiro Update(Parceiro param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ParceiroRepository.Add(param);
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
