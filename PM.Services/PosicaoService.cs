using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace PM.Services
{
    public class PosicaoService
    {
        private DatabaseContext context;

        public PosicaoService()
        {
            context = new DatabaseContext();
        }

        public Posicao GetByID(int id)
        {
            return context.PosicaoRepository.GetById(id);
        }

        public List<Posicao> GetAll()
        {
            return context.PosicaoRepository.GetAll();
        }

        public Posicao Delete(Posicao obj)
        {
            Posicao posicao = new Posicao();
            posicao.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                posicao = context.PosicaoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    posicao.BaseModel.Retorno = MessageType.Success;
                    posicao.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    posicao.BaseModel.Erro = true;
                }
                else
                {
                    posicao.BaseModel.Retorno = MessageType.Warning;
                    posicao.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    posicao.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    posicao.BaseModel.Retorno = MessageType.Error;
                }

                posicao.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                posicao.BaseModel.MensagemException = e;
            }

            return posicao;
        }

        public Posicao Add(Posicao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PosicaoRepository.Add(param);
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

        public Posicao Update(Posicao param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PosicaoRepository.Add(param);
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

        public List<Posicao> GetByComplemento(int idComplemento)
        {
            return context.PosicaoRepository.AsQueryable().Where(x => x.id_complemento_fk == idComplemento).ToList();
        }
    }
}
