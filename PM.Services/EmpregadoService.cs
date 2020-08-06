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
    public class EmpregadoService
    {
        private DatabaseContext context;

        public EmpregadoService()
        {
            context = new DatabaseContext();
        }

        public Empregado GetByID(int id)
        {
            return context.EmpregadoRepository.GetById(id);
        }

        public List<Empregado> GetAll()
        {
            return context.EmpregadoRepository.GetAll();
        }

        public List<Empregado> GetByNomeOrRG(String nome_rg)
        {
            List<Empregado> empregados = context.EmpregadoRepository.AsQueryable()
                .Where(x =>
                x.rg_empregado.ToLower().Trim()
                .Contains(nome_rg.ToLower().Trim()) ||
                String.Concat(x.nm_funcionario.ToLower().Trim(), " ", x.sb_funcionario.ToLower().Trim())
                .Contains(nome_rg.ToLower().Trim())).ToList();

            return empregados;
        }

        public Empregado Delete(Empregado obj)
        {
            Empregado empregado = new Empregado();
            empregado.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                empregado = context.EmpregadoRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    empregado.BaseModel.Retorno = MessageType.Success;
                    empregado.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    empregado.BaseModel.Erro = true;
                }
                else
                {
                    empregado.BaseModel.Retorno = MessageType.Warning;
                    empregado.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    empregado.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    empregado.BaseModel.Retorno = MessageType.Error;
                }

                empregado.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                empregado.BaseModel.MensagemException = e;
            }

            return empregado;
        }

        public Empregado Add(Empregado param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EmpregadoRepository.Add(param);
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

        public Empregado Update(Empregado param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.EmpregadoRepository.Add(param);
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
