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
    public class MAPService
    {
        private DatabaseContext context;

        public MAPService()
        {
            context = new DatabaseContext();
        }

        public MAP GetByID(int id)
        {
            return context.MapRepository.GetById(id);
        }

        public List<MAP> GetAll()
        {
            return context.MapRepository.GetAll();
        }

        public List<MAP> GetByOperacaoOrdem(int id)
        {
            List<MAP> maps = context.MapRepository.Find(x => x.id_operacao_fk == id);
            return maps;
        }

        public bool DeleteById(int id)
        {
            MAP MAP = new MAP();

            try
            {
                MAP = context.MapRepository.GetById(id);
                var retorno = context.MapRepository.Update(MAP);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MAP Add(MAP param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MapRepository.Add(param);
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

        public MAP Update(MAP param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MapRepository.Add(param);
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