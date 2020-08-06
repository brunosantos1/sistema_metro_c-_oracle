using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace PM.Services
{
    public class SistemaLogErrorService
    {
        private DatabaseContext context;

        public SistemaLogErrorService()
        {
            context = new DatabaseContext();
        }

        public SistemaLogError GetByID(int id)
        {
            return context.SistemaLogErrorRepository.GetById(id);
        }

        public List<SistemaLogError> GetAll()
        {
            return context.SistemaLogErrorRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaLogError SistemaLogError = new SistemaLogError();

            try
            {
                SistemaLogError = context.SistemaLogErrorRepository.GetById(id);
                var retorno = context.SistemaLogErrorRepository.Update(SistemaLogError);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                e = e;
                return false;
            }
        }

        public SistemaLogError Add(SistemaLogError param)
        {
            try
            {
                context.SistemaLogErrorRepository.Add(param);
                context.SaveChanges();
                return param;
            }
            catch (Exception e)
            {
                return param;
            }
        }

        public bool Update(SistemaLogError param)
        {
            try
            {
                context.SistemaLogErrorRepository.Update(param);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}