using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PM.Services
{
    public class LinhaService
    {
        private DatabaseContext context;

        public LinhaService()
        {
            context = new DatabaseContext();
        }
        public Linha GetByTrem(int idTrem)
        {
            Trem trem = context.TremRepository.GetById(idTrem);
            if (trem != null)
            {
                List<Linha> linha = context.LinhaRepository.Find(x => x.id_linha == trem.id_linha_atual_fk);
                if (linha.Count > 0)
                {
                    return linha[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        public Linha GetByID(int id)
        {
            return context.LinhaRepository.AsQueryable()
                            .Include(x => x.CentroTrabalho)
                            .Where(x => x.id_linha == id)
                            .SingleOrDefault();
        }

        public List<Linha> GetAll()
        {
            return context.LinhaRepository.GetAll();
        }

        public Linha Delete(Linha obj)
        {
            Linha linha = new Linha();
            linha.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                linha = context.LinhaRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    linha.BaseModel.Retorno = MessageType.Success;
                    linha.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    linha.BaseModel.Erro = true;
                }
                else
                {
                    linha.BaseModel.Retorno = MessageType.Warning;
                    linha.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    linha.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    linha.BaseModel.Retorno = MessageType.Error;
                }

                linha.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                linha.BaseModel.MensagemException = e;
            }

            return linha;
        }

        public Linha Add(Linha param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.LinhaRepository.Add(param);
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

        public Linha Update(Linha param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.LinhaRepository.Update(param);
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