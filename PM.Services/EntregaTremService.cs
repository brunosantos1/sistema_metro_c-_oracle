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
    public class EntregaTremService
    {
        private DatabaseContext context;

        public EntregaTremService()
        {
            context = new DatabaseContext();
        }

        public EntregaTremService(DatabaseContext dbcontext)
        {
            context = dbcontext;
        }
        public EntregaTrem GetByID(int id)
        {
            return context.EntregaTremRepository.GetById(id);
        }
        public EntregaTrem GetNavigationPropertiesByID(int id)
        {
            EntregaTrem EntregaTrem = context.EntregaTremRepository.AsQueryable()
                .Include(x => x.Trem)
                .Include(x => x.MotivoEntregaInspecao)
                .Include(x => x.MotivoEntregaOcorrencia)
                .Include(x => x.MotivoEntregaProgramacao)
                .Include(x => x.Patio)
                .Include(x => x.Linha)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.RespCancelamento)
                .Include(x => x.RespLiberacao)
                .Where(x => x.id_entrega == id)
                .FirstOrDefault();
            return EntregaTrem;
        }
        public List<EntregaTrem> GetAll()
        {
            return context.EntregaTremRepository.GetAll();
        }
        public bool DeleteById(int id)
        {
            EntregaTrem EntregaTrem = new EntregaTrem();

            try
            {
                EntregaTrem = context.EntregaTremRepository.GetById(id);
                var retorno = context.EntregaTremRepository.Update(EntregaTrem);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public EntregaTrem Add(EntregaTrem param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    if (!param.Notas.Count.Equals(0) || !param.Programacao.Count.Equals(0))
                    {

                        param.BaseModel.Erro    = false;
                        param.st_entrega_trem   = (new StatusEntregaTremService(this.context)).GetAll().ToList().FirstOrDefault(c => c.ds_st_entrega_trem.ToUpper().Equals("ENTREGUE")).id_st_entrega_trem;  // ENTREGUE
                        context.EntregaTremRepository.Add(param);
                        context.SaveChanges();
                        param.BaseModel.Erro = false;
                        param.BaseModel.Retorno = MessageType.Success;
                        param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;

                        NotaService notaService = new NotaService(this.context);
                        StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);
                        TremService tremService = new TremService(this.context);

                        //ProgramacaoService programacaoService = new ProgramacaoService(this.context);

                        foreach (Nota item in param.Notas.ToList().OrderBy(c => c.id_nota))
                        {
                            #region --|Vinculando e Mudando Status da Nota |--
                            Nota nota = notaService.GetNavigationPropertiesByID(int.Parse(item.id_nota.ToString()));
                            nota.id_entrega_trem_fk = param.id_entrega;

                            StatusUsuario stAber = new StatusUsuario();
                            stAber = statusUsuarioService.GetByCdSap("RECB");

                            nota.StatusUsuarios.Add(stAber);
                            notaService.Update(nota);
                            #endregion

                            #region --|Mudando Status do Trem|--
                                Trem trem = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                                trem.StatusTrem = (new StatusTremService(this.context)).GetByID(3); // ENTREGUE PARA MANOBRA
                                tremService.Update(trem);
                            #endregion
                            stAber = null; nota = null;
                        }

                        //foreach (EntregaTremProg item in param.EntregaTremProg.ToList().OrderBy(c => c.id_programacao_fk))
                        //{
                        //    item.id_entrega_fk = param.id_entrega;
                        //    entregaTremProg.Add(item);
                        //}
                        dbContextTransaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    dbContextTransaction.Rollback();
                    Console.Write("Erro");
                }
            }
                return param;
        }

        public EntregaTrem Update(EntregaTrem param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    if (!param.Notas.Count.Equals(0) || !param.Programacao.Count.Equals(0))
                    {

                        param.BaseModel.Erro = false;
                        param.st_entrega_trem = (new StatusEntregaTremService(this.context)).GetAll().ToList().FirstOrDefault(c => c.ds_st_entrega_trem.ToUpper().Equals("ENTREGUE")).id_st_entrega_trem;  // ENTREGUE
                        context.EntregaTremRepository.Update(param);
                        context.SaveChanges();
                        param.BaseModel.Erro = false;
                        param.BaseModel.Retorno = MessageType.Success;
                        param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;

                        NotaService notaService = new NotaService(this.context);
                        StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);
                        TremService tremService = new TremService(this.context);

                        //ProgramacaoService programacaoService = new ProgramacaoService(this.context);

                        foreach (Nota item in param.Notas.ToList().OrderBy(c => c.id_nota))
                        {
                            #region --|Vinculando e Mudando Status da Nota |--
                            Nota nota = notaService.GetNavigationPropertiesByID(int.Parse(item.id_nota.ToString()));
                            nota.id_entrega_trem_fk = param.id_entrega;

                            StatusUsuario stAber = new StatusUsuario();
                            stAber = statusUsuarioService.GetByCdSap("RECB");

                            nota.StatusUsuarios.Add(stAber);
                            notaService.Update(nota);
                            #endregion

                            #region --|Mudando Status do Trem|--
                            Trem trem = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                            trem.StatusTrem = (new StatusTremService(this.context)).GetByID(3); // ENTREGUE PARA MANOBRA
                            tremService.Update(trem);
                            #endregion
                            stAber = null; nota = null;
                        }

                        //foreach (EntregaTremProg item in param.EntregaTremProg.ToList().OrderBy(c => c.id_programacao_fk))
                        //{
                        //    item.id_entrega_fk = param.id_entrega;
                        //    entregaTremProg.Add(item);
                        //}
                        dbContextTransaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    dbContextTransaction.Rollback();
                    Console.Write("Erro");
                }
            }
            //try
            //{
            //    param.BaseModel.Erro = false;
            //    context.EntregaTremRepository.Add(param);
            //    param.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
            //    param.BaseModel.Retorno = MessageType.Success;
            //    param.BaseModel.Erro = true;
            //}
            //catch (Exception e)
            //{
            //    param.BaseModel.Retorno = MessageType.Error;
            //    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
            //    param.BaseModel.MensagemException = e;
            //}

            return param;
        }

        public EntregaTrem CancelaEntregaTrem(EntregaTrem param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    param.BaseModel.Erro = false;
                    EntregaTremService entregaTremService = new EntregaTremService(this.context);
                    TremService tremService = new TremService(this.context);
                    EntregaTrem entregaTrem = new EntregaTrem();
                    NotaService notaService = new NotaService(this.context);
                    StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);

                    entregaTrem                         = entregaTremService.GetNavigationPropertiesByID(param.id_entrega);
                    entregaTrem.dt_cancelamento         = param.dt_cancelamento;
                    entregaTrem.hr_cancelamento         = param.dt_cancelamento;
                    entregaTrem.id_resp_cancelamento    = param.id_resp_cancelamento;
                    entregaTrem.ds_motivo_cancelamento  = param.ds_motivo_cancelamento.ToUpper();
                    param.st_entrega_trem               = (new StatusEntregaTremService(this.context)).GetByID(1).id_st_entrega_trem; // CANCELADO

                    //ProgramacaoService programacaoService = new ProgramacaoService(this.context);

                    foreach (Nota item in param.Notas.ToList().OrderBy(c => c.id_nota))
                    {
                        #region --|Vinculando e Mudando Status da Nota |--
                        Nota nota = notaService.GetNavigationPropertiesByID(int.Parse(item.id_nota.ToString()));
                        nota.id_entrega_trem_fk = param.id_entrega;

                        StatusUsuario stAber = new StatusUsuario();
                        stAber = statusUsuarioService.GetByCdSap("ABER");

                        nota.StatusUsuarios.Add(stAber);
                        notaService.Update(nota);
                        #endregion

                        #region --|Mudando Status do Trem|--
                        Trem trem = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                        trem.StatusTrem = (new StatusTremService(this.context)).GetByID(1); // LIBERADO
                        tremService.Update(trem);
                        #endregion
                        stAber = null; nota = null;
                    }

                    //foreach (EntregaTremProg item in param.EntregaTremProg.ToList().OrderBy(c => c.id_programacao_fk))
                    //{
                    //    item.id_entrega_fk = param.id_entrega;
                    //    entregaTremProg.Add(item);
                    //}
                    context.EntregaTremRepository.Update(entregaTrem);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.Erro = false;
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    dbContextTransaction.Rollback();
                    Console.Write("Erro");
                }
            }
            return param;
        }
        public EntregaTrem LiberarEntregaTrem(EntregaTrem param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    param.BaseModel.Erro = false;
                    EntregaTremService entregaTremService = new EntregaTremService(this.context);
                    EntregaTrem entregaTrem = new EntregaTrem();

                    entregaTrem = entregaTremService.GetNavigationPropertiesByID(param.id_entrega);
                    entregaTrem.dt_liberacao        = param.dt_liberacao;
                    entregaTrem.hr_liberacao        = param.dt_liberacao;
                    entregaTrem.id_resp_liberacao   = param.id_resp_liberacao;
                    

                    #region --|Mudando Status do Trem|--
                    TremService tremService = new TremService(this.context);
                        Trem trem = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                        trem.StatusTrem = (new StatusTremService(this.context)).GetByID(int.Parse(param.Trem.st_trem.ToString()));
                        tremService.Update(trem);
                    #endregion
                    entregaTrem.st_entrega_trem = param.st_entrega_trem;
                    context.EntregaTremRepository.Update(entregaTrem);
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.Erro = false;
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    dbContextTransaction.Rollback();
                    Console.Write("Erro");
                }
            }

            return param;
        }
        public EntregaTrem MudarLocalEntregaTrem(EntregaTrem param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    param.BaseModel.Erro = false;
                    EntregaTremService entregaTremService = new EntregaTremService(this.context);
                    EntregaTrem entregaTrem = new EntregaTrem();

                    entregaTrem                 = entregaTremService.GetNavigationPropertiesByID(param.id_entrega);
                    entregaTrem.id_patio_fk     = param.id_patio_fk;
                    entregaTrem.id_lin_entrega  = param.id_lin_entrega;
                    context.EntregaTremRepository.Update(entregaTrem);
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
                    param.BaseModel.Retorno = MessageType.Success;
                    param.BaseModel.Erro = false;
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    dbContextTransaction.Rollback();
                    Console.Write("Erro");
                }
            }
            return param;
        }

        public List<EntregaTrem> GetByEntrega(int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
        {
            List<EntregaTrem> EntregaTrem = new List<EntregaTrem>();
            try
            {
                EntregaTrem = context.EntregaTremRepository.AsQueryable()
                    .Include(x => x.Linha)
                    .Include(x => x.Patio)
                    .Include(x => x.Trem)
                    .Include(x => x.Trem.StatusTrem)
                    .Include(x => x.MotivoEntregaInspecao)
                    .Include(x => x.MotivoEntregaOcorrencia)
                    .Include(x => x.MotivoEntregaProgramacao)
                    .Include(x => x.RespCancelamento)
                    .Include(x => x.RespLiberacao)
                    .Include(x => x.RespEntrega)
                    .ToList()
                    .Where(c => 
                                c.id_lin_entrega.Equals(idLinha.Equals(0)   ? c.id_lin_entrega  : idTrem)
                             && c.id_patio_fk.Equals(idPatio.Equals(0)      ? c.id_patio_fk     : idTrem)
                             && c.id_trem_fk.Equals(idTrem.Equals(0)        ? c.id_trem_fk      : idTrem)
                             && (c.id_motivo_entrega_ocor_fk     == (idMotivo.Equals(0) ? c.id_motivo_entrega_ocor_fk : idMotivo) ||
                                 c.id_motivo_entrega_inspecao_fk == (idMotivo.Equals(0) ? c.id_motivo_entrega_ocor_fk : idMotivo) ||
                                 c.id_motivo_entrega_prog_fk     == (idMotivo.Equals(0) ? c.id_motivo_entrega_ocor_fk : idMotivo)
                                 )
                             && (c.dt_entrega.Date >= dtInicio.Date &&  c.dt_entrega <= dtFinal.Date )
                    ).ToList();
            }
            catch (Exception ex)
            {
                ex = ex;
            }
            return EntregaTrem.ToList();
        }
    }
}