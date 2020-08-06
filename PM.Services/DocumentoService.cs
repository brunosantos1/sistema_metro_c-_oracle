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
    public class DocumentoService
    {
        private DatabaseContext context;

        public DocumentoService()
        {
            context = new DatabaseContext();
        }

        public Documento GetByID(int id)
        {
            return context.DocumentoRepository.GetById(id);
        }

        public List<Documento> GetAll()
        {
            return context.DocumentoRepository.GetAll();
        }

        public List<Documento> GetByNota(int id)
        {
            List<Documento> documentos = context.DocumentoRepository.Find(x => x.id_nota_fk == id);
            return documentos;
        }

        public List<Documento> GetNavigationPropertiesByNota(int id)
        {
            List<Documento> documentos = context.DocumentoRepository.AsQueryable()
                .Include(x => x.TipoDocumento)
                .Where(x => x.id_nota_fk == id)
                .ToList();

            return documentos;
        }

        public bool DeleteById(int id)
        {
            Documento documento = new Documento();

            try
            {
                documento = context.DocumentoRepository.GetById(id);
                var retorno = context.DocumentoRepository.Update(documento);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Documento Add(Documento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.DocumentoRepository.Add(param);
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

        public Documento Update(Documento param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.DocumentoRepository.Add(param);
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