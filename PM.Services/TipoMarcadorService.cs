using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class TipoMarcadorService
    {
        private DatabaseContext context;

        public TipoMarcadorService()
        {
            context = new DatabaseContext();
        }

        public TipoMarcador GetByID(int id)
        {
            return context.TipoMarcadorRepository.GetById(id);
        }

        public List<TipoMarcador> GetAll()
        {
            return context.TipoMarcadorRepository.GetAll();
        }

        public TipoMarcador Delete(TipoMarcador obj)
        {
            TipoMarcador tipoMarcador = new TipoMarcador();
            tipoMarcador.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                tipoMarcador = context.TipoMarcadorRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    tipoMarcador.BaseModel.Retorno = MessageType.Success;
                    tipoMarcador.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    tipoMarcador.BaseModel.Erro = true;
                }
                else
                {
                    tipoMarcador.BaseModel.Retorno = MessageType.Warning;
                    tipoMarcador.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    tipoMarcador.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    tipoMarcador.BaseModel.Retorno = MessageType.Error;
                }

                tipoMarcador.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                tipoMarcador.BaseModel.MensagemException = e;
            }

            return tipoMarcador;
        }

        public TipoMarcador Add(TipoMarcador param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoMarcadorRepository.Add(param);
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

        public TipoMarcador Update(TipoMarcador param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoMarcadorRepository.Add(param);
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
