using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class ClassificacaoService
    {
        private DatabaseContext context;

        public ClassificacaoService()
        {
            context = new DatabaseContext();
        }

        public Classificacao GetByID(int id)
        {
            return context.ClassificacaoRepository.GetById(id);
        }

        public List<Classificacao> GetAll()
        {
            return context.ClassificacaoRepository.GetAll();
        }

        public Classificacao Delete(Classificacao obj)
        {
            Classificacao classificacao = new Classificacao();
            classificacao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                classificacao = context.ClassificacaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    classificacao.BaseModel.Retorno = MessageType.Success;
                    classificacao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    classificacao.BaseModel.Erro = true;
                }
                else
                {
                    classificacao.BaseModel.Retorno = MessageType.Warning;
                    classificacao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    classificacao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    classificacao.BaseModel.Retorno = MessageType.Error;
                }

                classificacao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                classificacao.BaseModel.MensagemException = e;
            }

            return classificacao;
        }

        public Classificacao Add(Classificacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ClassificacaoRepository.Add(param);
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

        public Classificacao Update(Classificacao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.ClassificacaoRepository.Add(param);
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
