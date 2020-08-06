using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class TipoOrdemService
    {
        private DatabaseContext context;

        public TipoOrdemService()
        {
            context = new DatabaseContext();
        }

        public TipoOrdem GetByID(int id)
        {
            return context.TipoOrdemRepository.GetById(id);
        }

        public List<TipoOrdem> GetAll()
        {
            return context.TipoOrdemRepository.GetAll();
        }

        public TipoOrdem Delete(TipoOrdem obj)
        {
            TipoOrdem tipoOrdem = new TipoOrdem();
            tipoOrdem.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                tipoOrdem = context.TipoOrdemRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    tipoOrdem.BaseModel.Retorno = MessageType.Success;
                    tipoOrdem.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    tipoOrdem.BaseModel.Erro = true;
                }
                else
                {
                    tipoOrdem.BaseModel.Retorno = MessageType.Warning;
                    tipoOrdem.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    tipoOrdem.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    tipoOrdem.BaseModel.Retorno = MessageType.Error;
                }

                tipoOrdem.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                tipoOrdem.BaseModel.MensagemException = e;
            }

            return tipoOrdem;
        }

        public TipoOrdem Add(TipoOrdem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoOrdemRepository.Add(param);
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

        public TipoOrdem Update(TipoOrdem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoOrdemRepository.Add(param);
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
