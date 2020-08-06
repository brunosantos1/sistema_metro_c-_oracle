using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using PM.Domain.Entities.Enum;

namespace PM.Services
{
    public class TipoNotaService
    {
        private DatabaseContext context;

        public TipoNotaService()
        {
            context = new DatabaseContext();
        }

        public TipoNotaService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public TipoNota GetByID(int id)
        {
            return context.TipoNotaRepository.GetById(id);
        }

        public TipoNota GetByCodigoSap(string cd_sap)
        {
            return context.TipoNotaRepository.AsQueryable()
                .Where(x => x.cd_sap == cd_sap)
                .FirstOrDefault();
        }

        public List<TipoNota> GetAll()
        {
            try
            {
                return context.TipoNotaRepository.GetAll();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public TipoNota Delete(TipoNota obj)
        {
            TipoNota tipoNota = new TipoNota();
            tipoNota.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                tipoNota = context.TipoNotaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    tipoNota.BaseModel.Retorno = MessageType.Success;
                    tipoNota.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    tipoNota.BaseModel.Erro = true;
                }
                else
                {
                    tipoNota.BaseModel.Retorno = MessageType.Warning;
                    tipoNota.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    tipoNota.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    tipoNota.BaseModel.Retorno = MessageType.Error;
                }

                tipoNota.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                tipoNota.BaseModel.MensagemException = e;
            }

            return tipoNota;
        }

        public TipoNota Add(TipoNota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoNotaRepository.Add(param);
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

        public TipoNota Update(TipoNota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TipoNotaRepository.Update(param);
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