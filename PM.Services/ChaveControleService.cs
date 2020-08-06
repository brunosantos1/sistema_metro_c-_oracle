using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ChaveControleService
    {
        private DatabaseContext context;

        public ChaveControleService()
        {
            context = new DatabaseContext();
        }

        public ChaveControle GetByID(int id)
        {
            return context.ChaveControleRepository.GetById(id);
        }

        public List<ChaveControle> GetAll()
        {
            return context.ChaveControleRepository.GetAll();
        }

        public ChaveControle Delete(ChaveControle obj)
        {
            ChaveControle chaveControle = new ChaveControle();
            chaveControle.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                chaveControle = context.ChaveControleRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    chaveControle.BaseModel.Retorno = MessageType.Success;
                    chaveControle.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    chaveControle.BaseModel.Erro = true;
                }
                else
                {
                    chaveControle.BaseModel.Retorno = MessageType.Warning;
                    chaveControle.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    chaveControle.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    chaveControle.BaseModel.Retorno = MessageType.Error;
                }

                chaveControle.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                chaveControle.BaseModel.MensagemException = e;
            }

            return chaveControle;
        }

        public ChaveControle Add(ChaveControle param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ChaveControleRepository.Add(param);
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

        public ChaveControle Update(ChaveControle param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ChaveControleRepository.Add(param);
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
