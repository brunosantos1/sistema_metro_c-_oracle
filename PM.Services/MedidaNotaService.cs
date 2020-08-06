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
    public class MedidaNotaService
    {
        private DatabaseContext context;

        public MedidaNotaService()
        {
            context = new DatabaseContext();
        }

        public MedidaNotaService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public MedidaNota GetByID(int id)
        {
            return context.MedidaNotaRepository.GetById(id);
        }

        public List<MedidaNota> GetAll()
        {
            return context.MedidaNotaRepository.GetAll();
        }

        public List<MedidaNota> GetByNota(int id)
        {
            List<MedidaNota> medidasNota = context.MedidaNotaRepository.Find(x => x.id_nota_fk == id);
            return medidasNota;
        }

        public List<MedidaNota> GetNavigationPropertiesByNota(int id)
        {
            List<MedidaNota> medidasNota = context.MedidaNotaRepository.AsQueryable()
                //.Include(x => x.Nota)
                .Include(x => x.StatusMedida)
                .Include(x => x.Empregado)
                .Include(x => x.CodeTx)
                .Include(x => x.EmpregadoResponsavel)
                .Include(x => x.CentroTrabalho)
                .Where(x => x.id_nota_fk == id)
                .ToList();

            return medidasNota;
        }

        public bool DeleteById(int id)
        {
            MedidaNota medidaNota = new MedidaNota();

            try
            {
                medidaNota = context.MedidaNotaRepository.GetById(id);
                var retorno = context.MedidaNotaRepository.Update(medidaNota);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public MedidaNota Add(MedidaNota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MedidaNotaRepository.Add(param);
                context.SaveChanges();
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                param.BaseModel.Retorno = MessageType.Success;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
            }

            return param;
        }

        public MedidaNota Update(MedidaNota param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.MedidaNotaRepository.Update(param);
                param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                param.BaseModel.Retorno = MessageType.Success;
            }
            catch (Exception e)
            {
                param.BaseModel.Erro = true;
                param.BaseModel.Retorno = MessageType.Error;
                param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                param.BaseModel.MensagemException = e;
            }

            return param;
        }
    }
}