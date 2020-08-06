using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CentroLocalizacaoService
    {
        private DatabaseContext context;

        public CentroLocalizacaoService()
        {
            context = new DatabaseContext();
        }

        public CentroLocalizacao GetByID(int id)
        {
            return context.CentroLocalizacaoRepository.GetById(id);
        }

        public List<CentroLocalizacao> GetAll()
        {
            return context.CentroLocalizacaoRepository.GetAll();
        }

        public CentroLocalizacao Delete(CentroLocalizacao obj)
        {
            CentroLocalizacao centroLocalizacao = new CentroLocalizacao();
            centroLocalizacao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                centroLocalizacao = context.CentroLocalizacaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    centroLocalizacao.BaseModel.Retorno = MessageType.Success;
                    centroLocalizacao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    centroLocalizacao.BaseModel.Erro = true;
                }
                else
                {
                    centroLocalizacao.BaseModel.Retorno = MessageType.Warning;
                    centroLocalizacao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    centroLocalizacao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    centroLocalizacao.BaseModel.Retorno = MessageType.Error;
                }

                centroLocalizacao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                centroLocalizacao.BaseModel.MensagemException = e;
            }

            return centroLocalizacao;
        }

        public CentroLocalizacao Add(CentroLocalizacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CentroLocalizacaoRepository.Add(param);
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

        public CentroLocalizacao Update(CentroLocalizacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CentroLocalizacaoRepository.Add(param);
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
