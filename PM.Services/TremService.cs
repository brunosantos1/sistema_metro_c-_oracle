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
    public class TremService
    {
        private DatabaseContext context;

        public TremService()
        {
            context = new DatabaseContext();
        }
        public TremService(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public Trem GetByID(int id)
        {
            return context.TremRepository.GetById(id);
        }
        public Trem GetNavigationPropertiesByID(int id)
        {
            Trem trem = new Trem();

            trem = context.TremRepository.AsQueryable()
                    .Include(x => x.Documento)
                    .Include(x => x.Frota)
                    .Include(x => x.LinhaAtual)
                    .Include(x => x.LinhaOrigem)
                    .Include(x => x.Patio)
                    .Include(x => x.StatusTrem)
                    .FirstOrDefault(c => c.id_trem.Equals(id));
            return trem;
        }

        public List<Trem> GetAll()
        {
            return context.TremRepository.GetAll();
        }

        public List<Trem> GetByFrota(int id)
        {
            List<Trem> trens = context.TremRepository.Find(x => x.id_frota_fk == id);
            return trens;
        }

        public List<Trem> GetByPatioLinhaStatus(int idLinha, int idPatio, int idStatus, int Manobra)
        {
            List<Trem> trens = context.TremRepository.AsQueryable()
                .Include(x => x.Frota)
                .Include(x => x.Documento)
                .Include(x => x.LinhaOrigem)
                .Include(x => x.LinhaAtual)
                .Include(x => x.Patio)
                .Include(x => x.StatusTrem)
                .Where(
                        x => x.id_linha_atual_fk    == (idLinha.Equals(0)   ? x.id_linha_atual_fk   : idLinha) &&
                        x.id_patio_fk               == (idPatio.Equals(0)   ? x.id_patio_fk         : idPatio) &&
                        x.st_trem                   == (idStatus.Equals(0)  ? x.st_trem             : idStatus) &&
                        x.st_manobra                == (Manobra > 0)        ? true : false
                      ).ToList();
            return trens;
        }

        public List<Trem> GetByLinhaPatioTrem(int idLinha, int idPatio, int idTrem)
        {
            List<Trem> trens = context.TremRepository.AsQueryable()
                .Include(x => x.Frota       )
                .Include(x => x.Documento   )
                .Include(x => x.LinhaOrigem )
                .Include(x => x.LinhaAtual  )
                .Include(x => x.Patio       )
                .Include(x => x.StatusTrem  )
                .Where(
                           x => x.id_linha_atual_fk == (idLinha.Equals(0) ? x.id_linha_atual_fk : idLinha) 
                        && x.id_patio_fk            == (idPatio.Equals(0) ? x.id_patio_fk       : idPatio) 
                    //  && x.id_trem                == (idTrem.Equals(0)  ? x.id_trem           : idTrem)
                      ).ToList();
            return trens;
        }

        public Trem Delete(Trem obj)
        {
            Trem trem = new Trem();
            trem.BaseModel.Erro = false;

            try
            {
                string mensagem = string.Empty;
                trem = context.TremRepository.Delete(obj);

                if (context.SaveChanges() > 0)
                {
                    trem.BaseModel.Retorno = MessageType.Success;
                    trem.BaseModel.MensagemUsuario = Mensagens.Registro_Deletado;
                    trem.BaseModel.Erro = true;
                }
                else
                {
                    trem.BaseModel.Retorno = MessageType.Warning;
                    trem.BaseModel.MensagemUsuario = Mensagens.Registro_NaoDeletado;
                }

            }
            catch (Exception e)
            {
                if (e.HResult == -2146233087)
                {
                    trem.BaseModel.Retorno = MessageType.Warning;
                }
                else
                {
                    trem.BaseModel.Retorno = MessageType.Error;
                }

                trem.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                trem.BaseModel.MensagemException = e;
            }

            return trem;
        }

        public Trem Add(Trem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TremRepository.Add(param);
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

        public Trem Update(Trem param)
        {
            try
            {
                param.BaseModel.Erro = false;
                context.TremRepository.Update(param);
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