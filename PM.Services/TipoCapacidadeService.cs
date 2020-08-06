using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class TipoCapacidadeService
    {
        private DatabaseContext context;

        public TipoCapacidadeService()
        {
            context = new DatabaseContext();
        }

        public TipoCapacidade GetByID(int id)
        {
            return context.TipoCapacidadeRepository.GetById(id);
        }

        public List<TipoCapacidade> GetAll()
        {
            return context.TipoCapacidadeRepository.GetAll();
        }

        public TipoCapacidade Delete(TipoCapacidade obj)
        {
            TipoCapacidade tipoCapacidade = new TipoCapacidade();
            tipoCapacidade.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                tipoCapacidade = context.TipoCapacidadeRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    tipoCapacidade.BaseModel.Retorno = MessageType.Success;
                    tipoCapacidade.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    tipoCapacidade.BaseModel.Erro = true;
                }
                else
                {
                    tipoCapacidade.BaseModel.Retorno = MessageType.Warning;
                    tipoCapacidade.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    tipoCapacidade.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    tipoCapacidade.BaseModel.Retorno = MessageType.Error;
                }

                tipoCapacidade.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                tipoCapacidade.BaseModel.MensagemException = e;
            }

            return tipoCapacidade;
        }

        public TipoCapacidade Add(TipoCapacidade param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoCapacidadeRepository.Add(param);
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

        public TipoCapacidade Update(TipoCapacidade param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoCapacidadeRepository.Add(param);
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
