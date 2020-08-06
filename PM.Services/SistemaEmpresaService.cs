using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace PM.Services
{
    public class SistemaEmpresaService
    {
        private DatabaseContext context;

        public SistemaEmpresaService()
        {
            context = new DatabaseContext();
        }

        public SistemaEmpresa GetByID(int id)
        {
            return context.SistemaEmpresaRepository.GetById(id);
        }

        public List<SistemaEmpresa> GetAll()
        {
            return context.SistemaEmpresaRepository.GetAll();
        }

        public bool DeleteById(int id)
        {
            SistemaEmpresa SistemaEmpresa = new SistemaEmpresa();

            try
            {
                SistemaEmpresa = context.SistemaEmpresaRepository.GetById(id);
                var retorno = context.SistemaEmpresaRepository.Update(SistemaEmpresa);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                e = e;
                return false;
            }
        }

        public SistemaEmpresa Add(SistemaEmpresa param)
        {
            try
            {
                context.SistemaEmpresaRepository.Add(param);
                context.SaveChanges();
                return param;
            }
            catch (Exception e)
            {
                return param;
            }
        }

        public bool Update(SistemaEmpresa param)
        {
            try
            {
                context.SistemaEmpresaRepository.Update(param);
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