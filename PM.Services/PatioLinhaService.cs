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
    public class PatioLinhaService
    {
        private DatabaseContext context;

        public PatioLinhaService()
        {
            context = new DatabaseContext();
        }

        public PatioLinha GetByID(int id)
        {
            return context.PatioLinhaRepository.GetById(id);
        }

        public List<PatioLinha> GetByLinhaID(int id)
        {
            return context.PatioLinhaRepository.AsQueryable()
               .Include(x => x.Linha)
               .Include(x => x.Patio)
               .Where(x => x.id_linha_fk == id)               
               .ToList();
        }

        public List<PatioLinha> GetAll()
        {
            //return context.PatioLinhaRepository.GetAll();
            return context.PatioLinhaRepository.AsQueryable()
              .Include(x => x.Linha)
              .Include(x => x.Patio)              
              .ToList();
        }

        public PatioLinha Delete(PatioLinha obj)
        {
            PatioLinha PatioLinha = new PatioLinha();

            try
            {
                string mensagem = string.Empty;
                PatioLinha = context.PatioLinhaRepository.Delete(obj);
                PatioLinha.BaseModel.Erro = false;

                if (context.SaveChanges() > 0)
                {
                    PatioLinha.BaseModel.Retorno = MessageType.Success;
                    PatioLinha.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    PatioLinha.BaseModel.Erro = true;
                }
                else
                {
                    PatioLinha.BaseModel.Retorno = MessageType.Warning;
                    PatioLinha.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    PatioLinha.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    PatioLinha.BaseModel.Retorno = MessageType.Error;
                }

                PatioLinha.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                PatioLinha.BaseModel.MensagemException = e;
            }

            return PatioLinha;
        }

        public PatioLinha Add_Update(PatioLinha param)
        {
            try
            {
                param.BaseModel.Erro = false;

                if (!param.id_patio_fk.Equals(0))
                {
                    context.PatioLinhaRepository.Update(param);
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
                }
                else
                {
                    context.PatioLinhaRepository.Add(param);
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                }
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

        public PatioLinha Update(PatioLinha param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.PatioLinhaRepository.Update(param);
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
