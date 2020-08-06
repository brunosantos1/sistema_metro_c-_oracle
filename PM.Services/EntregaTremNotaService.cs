using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using PM.Domain.Entities.Enum;
using System.Linq.Expressions;

namespace PM.Services
{
    public class EntregaTremNotaService
    {
        private DatabaseContext context;

        public EntregaTremNotaService()
        {
            context = new DatabaseContext();
        }

        public EntregaTremNotaService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public EntregaTremNota GetByID(int id)
        {
            return context.EntregaTremNotaRepository.GetById(id);
        }
        public List<EntregaTremNota> GetAll()
        {
            return context.EntregaTremNotaRepository.GetAll();
        }
        public bool DeleteById(int id)
        {
            EntregaTremNota EntregaTremNota = new EntregaTremNota();

            try
            {
                EntregaTremNota = context.EntregaTremNotaRepository.GetById(id);
                var retorno = context.EntregaTremNotaRepository.Update(EntregaTremNota);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public EntregaTremNota Add(EntregaTremNota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EntregaTremNotaRepository.Add(param);
                context.SaveChanges();
                param.BaseModel.Erro = false;
                param.BaseModel.Retorno = MessageType.Success;
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
                Console.Write("Erro");
            }

            return param;
        }
        public EntregaTremNota Update(EntregaTremNota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EntregaTremNotaRepository.Add(param);
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