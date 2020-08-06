using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PM.Services
{
    public class CentroTrabalhoService
    {
        private DatabaseContext context;

        public CentroTrabalhoService()
        {
            context = new DatabaseContext();
        }

        public CentroTrabalho GetByID(int id)
        {
            return context.CentroTrabalhoRepository.GetById(id);
        }

        public CentroTrabalho GetByLinha(int id)
        {
            LinhaService linhaService = new LinhaService();
            Linha linha;
            linha = linhaService.GetByID(id);
            if(linha!=null)
            {
                CentroTrabalho centro;
                CentroTrabalhoService centroService = new CentroTrabalhoService();
                centro = centroService.GetByID(linha.id_centro_trabalho_fk.GetValueOrDefault());
                return centro;
            } else
            {
                return null;
            }
            
        }

        public List<CentroTrabalho> GetAll()
        {
            return context.CentroTrabalhoRepository.GetAll();
        }

        public CentroTrabalho Delete(CentroTrabalho obj)
        {
            CentroTrabalho centroTrabalho = new CentroTrabalho();
            centroTrabalho.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                centroTrabalho = context.CentroTrabalhoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    centroTrabalho.BaseModel.Retorno = MessageType.Success;
                    centroTrabalho.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    centroTrabalho.BaseModel.Erro = true;
                }
                else
                {
                    centroTrabalho.BaseModel.Retorno = MessageType.Warning;
                    centroTrabalho.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    centroTrabalho.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    centroTrabalho.BaseModel.Retorno = MessageType.Error;
                }

                centroTrabalho.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                centroTrabalho.BaseModel.MensagemException = e;
            }

            return centroTrabalho;
        }

        public CentroTrabalho Add(CentroTrabalho param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CentroTrabalhoRepository.Add(param);
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

        public CentroTrabalho Update(CentroTrabalho param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.CentroTrabalhoRepository.Update(param);
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