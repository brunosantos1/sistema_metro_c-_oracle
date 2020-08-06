using PM.Data.UnitOfWork;
using PM.Domain.Entities;
using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;



namespace PM.Services
{
    public class SistemaService
    {
        private DatabaseContext context;

        public SistemaService()
        {
            context = new DatabaseContext();
        }

        public Sistema GetByID(int id)
        {
            return context.SistemaRepository.GetById(id);
        }

        public List<Sistema> GetAll()
        {
            return context.SistemaRepository.GetAll();
        }

        public List<Sistema> GetByFrota(int id)
        {
            List<Sistema> sistemas = context.SistemaRepository.Find(x => x.id_frota_fk == id);
            return sistemas;
        }


        public List<GrupoCode> GetSistemas(int idPerfil)
        {
            List<GrupoCode> grupos = new List<GrupoCode>();
            Perfil perfil = context.PerfilRepository.AsQueryable().Include(x => x.Catalogos).Include(x => x.Catalogos.Select(q => q.GruposCode)).Where(x => x.id_perfil == idPerfil && x.Catalogos.Any(i => i.cd_sap == "D")).FirstOrDefault();
            Catalogo catalogo;
            if (perfil != null && perfil.Catalogos != null && perfil.Catalogos.Count > 0)
            {
                catalogo = perfil.Catalogos.ToList()[0];
                if (catalogo.GruposCode != null && catalogo.GruposCode.Count > 0)
                {
                    grupos = catalogo.GruposCode.Where(x => x.cd_sap != "SERVICO").ToList();
                }
            }
            return grupos;
        }

        public List<Code> GetSintomas(int idSistema)
        {
            List<Code> codes = new List<Code>();
            codes = context.CodeRepository.Find(x => x.id_gr_code_fk == idSistema);
            return codes;
        }

        public Nota GetNavigationPropertiesByID(int id)
        {
            Nota nota = context.NotaRepository.AsQueryable()
                .Include(x => x.TipoNota)
                .Include(x => x.LocalInstalacao)
                .Include(x => x.LocalInstPrinc)
                .Include(x => x.NotaReferencia)
                .Include(x => x.StatusSistema)
                .Include(x => x.CodeSintoma)
                .Include(x => x.Prioridade)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.ElementoPEP)
                .Include(x => x.Equipamento)
                .Include(x => x.Material)
                .Include(x => x.UnidadeMedidaTempoPrevisto)
                .Include(x => x.StatusPericia)
                .Include(x => x.EventoGerador)
                .Include(x => x.Diagnostico)
                .Where(x => x.id_nota == id)
                .FirstOrDefault();

            return nota;
        }

        public Sistema Delete(Sistema obj)
        {
            Sistema sistema = new Sistema();

            try
            {
                string mensagem = string.Empty;
                sistema = context.SistemaRepository.Delete(obj);
                sistema.BaseModel.Erro = false;

                if (context.SaveChanges() > 0)
                {
                    sistema.BaseModel.Retorno = MessageType.Success;
                    sistema.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    sistema.BaseModel.Erro = true;
                }
                else
                {
                    sistema.BaseModel.Retorno = MessageType.Warning;
                    sistema.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }
            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    sistema.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    sistema.BaseModel.Retorno = MessageType.Error;
                }

                sistema.BaseModel.MensagemUsuario = e.Message;
                sistema.BaseModel.MensagemException = e;
            }

            return sistema;
        }

        public Sistema Add(Sistema param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.SistemaRepository.Add(param);
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

        public Sistema Update(Sistema param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.SistemaRepository.Update(param);
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