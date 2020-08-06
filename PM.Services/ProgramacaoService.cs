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
    public class ProgramacaoService
    {
        private DatabaseContext context;

        public ProgramacaoService()
        {
            context = new DatabaseContext();
        }

        public ProgramacaoService(DatabaseContext dbcontext)
        {
            context = dbcontext;
        }
        public Programacao GetByID(int id)
        {
            return context.ProgramacaoRepository.GetById(id);
        }
        public Programacao GetNavigationPropertiesByID(int id)
        {
            Programacao Programacao = context.ProgramacaoRepository.AsQueryable()
                .Include(x => x.Trem)
                .Include(x => x.CentroTrabalho)
                .Include(x => x.EmpregadoAutorizacao)
                .Include(x => x.EmpregadoCancelamento)
                .Include(x => x.EmpregadoProgramacao)
                .Include(x => x.EmpregadoLiberacao)
                .Include(x => x.Notas)
                .Where(x => x.id_programacao == id)
                .FirstOrDefault();
            return Programacao;
        }
        public List<Programacao> GetByProgramacao(int idLinha, int idPatio, int idTrem, int idMotivo, DateTime dtInicio, DateTime dtFinal)
        {
            List<Programacao> Programacao = new List<Programacao>();
            try
            {
                Programacao = context.ProgramacaoRepository.AsQueryable()
                    .Include(x => x.Trem)
                    .Include(x => x.CentroTrabalho)
                    .Include(x => x.EmpregadoAutorizacao)
                    .Include(x => x.EmpregadoCancelamento)
                    .Include(x => x.EmpregadoProgramacao)
                    .Include(x => x.EmpregadoLiberacao)
                    .Include(x => x.Notas)
                    .ToList()
                    .Where(c =>
                                c.id_lin_planej_entrega_fk.Equals(idLinha.Equals(0) ? c.id_lin_planej_entrega_fk : idLinha)
                             //&& c id_patio_fk.Equals(idPatio.Equals(0) ? c.id_patio_fk : idTrem)
                             //&& c.id_trem_fk.Equals(idTrem.Equals(0) ? c.id_trem_fk : idTrem)
                             //&& (c.id_motivo_Programacao_ocor_fk == (idMotivo.Equals(0) ? c.id_motivo_Programacao_ocor_fk : idMotivo) ||
                             //    c.id_motivo_Programacao_inspecao_fk == (idMotivo.Equals(0) ? c.id_motivo_Programacao_ocor_fk : idMotivo) ||
                             //    c.id_motivo_Programacao_prog_fk == (idMotivo.Equals(0) ? c.id_motivo_Programacao_ocor_fk : idMotivo)
                             //    )
                             && (c.dt_entrega.Date >= dtInicio.Date && c.dt_entrega  <= dtFinal.Date)
                    ).ToList();
            }
            catch (Exception ex)
            {
                ex = ex;
            }
            return Programacao.ToList();
        }
        public List<Programacao> GetAll()
        {
            return context.ProgramacaoRepository.GetAll();
        }
        public bool DeleteById(int id)
        {
            Programacao Programacao = new Programacao();

            try
            {
                Programacao = context.ProgramacaoRepository.GetById(id);
                var retorno = context.ProgramacaoRepository.Update(Programacao);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Programacao Add(Programacao param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    if (!param.Notas.Count.Equals(0))
                    {
                        #region --|Indica se a Programação sera executada antes ou depois de 48Horas|-- 
                        bool flgMaiorQue48Horas = (((param.dt_entrega - DateTime.Now).Days * 24) > 48);
                        #endregion

                        #region --|Gerando Programação no banco de dados|--
                        Programacao oProgramacao = new Programacao();
                        oProgramacao.id_programacao = param.id_programacao;
                        oProgramacao.cd_tp_programacao = param.cd_tp_programacao;
                        oProgramacao.id_trem_fk = param.id_trem_fk;
                        oProgramacao.id_entrega_trem_fk = null;
                        oProgramacao.dt_entrega = param.dt_entrega;
                        oProgramacao.dt_liberacao = param.dt_liberacao;
                        oProgramacao.id_rg_programacao = param.id_rg_programacao;
                        oProgramacao.id_tipo_manutencao_fk = param.id_tipo_manutencao_fk;
                        oProgramacao.ds_observacao = param.ds_observacao.ToUpper();
                        oProgramacao.id_ct_trab = param.id_ct_trab;
                        oProgramacao.BaseModel = param.BaseModel;
                        oProgramacao.st_programacao = (new StatusProgramacaoTremService()).GetByCdSap(flgMaiorQue48Horas ? "PROG" : "SOLI").id_st_programacao_trem;
                        context.ProgramacaoRepository.Add(oProgramacao);
                        context.SaveChanges();
                        // Gravação foi concluida com sucesso. 
                        oProgramacao.BaseModel.Erro = false;
                        oProgramacao.BaseModel.Retorno = MessageType.Success;
                        oProgramacao.BaseModel.MensagemUsuario = Mensagens.Registro_Adicionado;
                        #endregion

                        #region --|Criando instancias do Servicos Utilizados|--
                        NotaService notaService = new NotaService(this.context);
                        StatusUsuarioService statusUsuarioService = new StatusUsuarioService(this.context);
                        ProgramacaoService programacaoService = new ProgramacaoService(this.context);
                        MedidaNotaService medidaNotaService = new MedidaNotaService(this.context);
                        List<MedidaNota> lstMedidaNota = new List<MedidaNota>();
                        StatusUsuario StatusUsuarioRemover = new StatusUsuario();
                        int ContadorSequenciaMedida = 0;
                        #endregion

                        #region --|Percorrendo Array de Notas|--
                        foreach (Nota ItemNotaParam in param.Notas.ToList().OrderBy(c => c.id_nota))
                        {
                            #region --|Reestabeleço context de banco|-- 
                            notaService = new NotaService(this.context);
                            statusUsuarioService = new StatusUsuarioService(this.context);
                            programacaoService = new ProgramacaoService(this.context);
                            medidaNotaService = new MedidaNotaService(this.context);
                            lstMedidaNota = new List<MedidaNota>();
                            StatusUsuarioRemover = new StatusUsuario();
                            #endregion

                            #region --|Carrego a Nota com TODOS os seus Atributos|--
                            Nota itemNota = notaService.GetNavigationPropertiesByID(ItemNotaParam.id_nota);
                            #endregion

                            #region --|Encerrando Medidas Anterior|--                            
                            lstMedidaNota = itemNota.MedidasNota.ToList();
                            foreach (MedidaNota itemMedidaNota in lstMedidaNota.ToList())
                            {
                                StatusUsuarioRemover = itemMedidaNota.StatusUsuario;
                                itemMedidaNota.id_code_tx_fk = (new CodeService()).GetByCdSap("CANC").id_code;
                                itemMedidaNota.StatusMedida = (new StatusMedidaService(this.context)).GetByCdSap("ENCE");
                                ContadorSequenciaMedida = itemMedidaNota.sq_medida_nota;
                                medidaNotaService = new MedidaNotaService(this.context);
                                medidaNotaService.Update(itemMedidaNota);
                                if (itemMedidaNota.BaseModel.Erro)
                                {
                                    throw itemMedidaNota.BaseModel.MensagemException;
                                }
                            }
                            #endregion

                            #region --|Gerando Sequencial da Medida|--                            
                            if (lstMedidaNota == null) { ContadorSequenciaMedida = ContadorSequenciaMedida + 1; }
                            else { ContadorSequenciaMedida = lstMedidaNota.Count.Equals(0) ? 1 : ContadorSequenciaMedida + 1; }
                            #endregion

                            #region --|Criando Novas Medidas |--

                            #region --|Informando Centro de Trabalho|--
                            MedidaNota oMedidaNota = new MedidaNota();
                            oMedidaNota.id_code_tx_fk = (new CodeService()).GetByCdSap("ABER").id_code;
                            oMedidaNota.sq_medida_nota = ContadorSequenciaMedida;
                            oMedidaNota.StatusUsuario = (new StatusUsuarioService(this.context)).GetByCdSap("ABER");
                            oMedidaNota.StatusMedida = (new StatusMedidaService(this.context)).GetByCdSap("LIBE");
                            oMedidaNota.id_st_usuario_fk = oMedidaNota.StatusUsuario.id_st_usuario;
                            oMedidaNota.id_st_medida_fk = oMedidaNota.StatusMedida.id_st_medida;
                            oMedidaNota.id_cent_trab_responsavel_fk = param.id_ct_trab;
                            oMedidaNota.fn_responsavel = "ZA";
                            oMedidaNota.dt_programada = param.dt_entrega;
                            oMedidaNota.dt_hora_medida_nota = param.dt_entrega;
                            oMedidaNota.id_nota_fk = itemNota.id_nota;
                            oMedidaNota.id_empregado_responsavel_fk = null;
                            oMedidaNota.id_empregado_fk = null;
                            oMedidaNota.ds_motivo = "";
                            medidaNotaService = new MedidaNotaService(this.context);
                            medidaNotaService.Add(oMedidaNota);
                            if (oMedidaNota.BaseModel.Erro)
                            {
                                throw oMedidaNota.BaseModel.MensagemException;
                            }
                            #endregion
                            #region --|Informando RG do Programador|--
                            ContadorSequenciaMedida++;
                            oMedidaNota = new MedidaNota();
                            oMedidaNota.id_code_tx_fk = (new CodeService()).GetByCdSap((flgMaiorQue48Horas ? "PROG" : "SOLI")).id_code;
                            oMedidaNota.sq_medida_nota = ContadorSequenciaMedida;
                            oMedidaNota.StatusUsuario = (new StatusUsuarioService(this.context)).GetByCdSap((flgMaiorQue48Horas ? "PROG" : "SOLI"));
                            oMedidaNota.StatusMedida = (new StatusMedidaService(this.context)).GetByCdSap("LIBE");
                            oMedidaNota.id_st_medida_fk = oMedidaNota.StatusMedida.id_st_medida;
                            oMedidaNota.id_st_usuario_fk = oMedidaNota.StatusUsuario.id_st_usuario;
                            oMedidaNota.id_cent_trab_responsavel_fk = param.id_ct_trab;
                            oMedidaNota.fn_responsavel = "ZA";
                            oMedidaNota.dt_programada = param.dt_entrega;
                            oMedidaNota.dt_hora_medida_nota = param.dt_entrega;
                            oMedidaNota.id_nota_fk = itemNota.id_nota;
                            oMedidaNota.id_empregado_responsavel_fk = null;
                            oMedidaNota.id_empregado_fk = param.id_rg_programacao;
                            oMedidaNota.ds_motivo = "(TESTE NÃO APAGAR - 002)";
                            medidaNotaService = new MedidaNotaService(this.context);
                            medidaNotaService.Add(oMedidaNota);
                            if (oMedidaNota.BaseModel.Erro)
                            {
                                throw oMedidaNota.BaseModel.MensagemException;
                            }
                            ContadorSequenciaMedida = 0;
                            #endregion

                            #endregion

                            #region --|Atuando sobre Notas|--

                            #region --|Armazenando ID da Programação na Nota|--
                            Nota nota = notaService.GetNavigationPropertiesByID(int.Parse(itemNota.id_nota.ToString()));
                            nota.id_programacao_fk = oProgramacao.id_programacao;
                            notaService = new NotaService(this.context);
                            notaService.Update(nota);
                            if (nota.BaseModel.Erro)
                            {
                                throw nota.BaseModel.MensagemException;
                            }
                            #endregion

                            #region --|Removendo Ultimo Status do Usuario da Nota|--
                            nota.StatusUsuarios.Remove(StatusUsuarioRemover);
                            notaService = new NotaService(this.context);
                            notaService.Update(nota);
                            if (nota.BaseModel.Erro)
                            {
                                throw nota.BaseModel.MensagemException;
                            }
                            #endregion

                            #region --|Criando NOVO Status do Usuario da Nota|--
                            StatusUsuario stProg = new StatusUsuario();
                            stProg = statusUsuarioService.GetByCdSap("PROG");
                            notaService = new NotaService(this.context);
                            nota.StatusUsuarios.Add(stProg);
                            if (stProg.BaseModel.Erro)
                            {
                                throw stProg.BaseModel.MensagemException;
                            }

                            notaService = new NotaService(this.context);
                            notaService.Update(nota);
                            if (nota.BaseModel.Erro)
                            {
                                throw nota.BaseModel.MensagemException;
                            }
                            #endregion

                            #endregion
                        }
                        #endregion

                        #region --|Efetivando alterações no banco de dados|--                        
                        dbContextTransaction.Commit();
                        #endregion
                    }
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro = true;
                    param.BaseModel.Retorno = MessageType.Error;
                    param.BaseModel.MensagemUsuario = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException = e;
                    dbContextTransaction.Rollback();
                }
            }
            return param;
        }

        public Programacao Update(Programacao param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    if (!param.Notas.Count.Equals(0))
                    {

                        param.BaseModel.Erro = false;
                        //param.st_programacao  = (new StatusProgramacaoService(this.context)).GetAll().ToList().FirstOrDefault(c => c.ds_st_Programacao_trem.ToUpper().Equals("ENTREGUE")).id_st_Programacao_trem;  // ENTREGUE
                        context.ProgramacaoRepository.Update(param);
                        context.SaveChanges();
                        param.BaseModel.Erro                        = false;
                        param.BaseModel.Retorno                     = MessageType.Success;
                        param.BaseModel.MensagemUsuario             = Mensagens.Registro_Adicionado;

                        NotaService notaService                     = new NotaService(this.context);
                        StatusUsuarioService statusUsuarioService   = new StatusUsuarioService(this.context);
                        TremService tremService                     = new TremService(this.context);
                        ProgramacaoService programacaoService       = new ProgramacaoService(this.context);

                        foreach (Nota item in param.Notas.ToList().OrderBy(c => c.id_nota))
                        {
                            #region --|Vinculando e Mudando Status da Nota |--
                            Nota nota               = notaService.GetNavigationPropertiesByID(int.Parse(item.id_nota.ToString()));
                            nota.id_programacao_fk  = param.id_programacao;

                            StatusUsuario stAber    = new StatusUsuario();
                            stAber                  = statusUsuarioService.GetByCdSap("ENTRG");

                            nota.StatusUsuarios.Add(stAber);
                            notaService.Update(nota);
                            #endregion

                            #region --|Mudando Status do Trem|--
                            Trem trem       = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                            trem.StatusTrem = (new StatusTremService(this.context)).GetByID(3); // ENTREGUE PARA MANOBRA
                            tremService.Update(trem);
                            #endregion
                            stAber = null; nota = null; trem = null;
                        }

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
        public Programacao CancelaProgramacao(Programacao param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    param.BaseModel.Erro                        = false;
                    ProgramacaoService ProgramacaoService       = new ProgramacaoService(this.context);
                    TremService tremService                     = new TremService(this.context);
                    Programacao Programacao                     = new Programacao();
                    NotaService notaService                     = new NotaService(this.context);
                    StatusUsuarioService statusUsuarioService   = new StatusUsuarioService(this.context);

                    Programacao                     = ProgramacaoService.GetNavigationPropertiesByID(param.id_programacao);
                    Programacao.dt_cancelamento     = param.dt_cancelamento;
                    Programacao.hr_cancelamento     = param.dt_cancelamento;
                    Programacao.id_rg_cancelamento  = param.id_rg_cancelamento;
                    Programacao.ds_motivo_cancelamento = param.ds_motivo_cancelamento.ToUpper();
                    //param.st_programacao  = (new StatusProgramacaoService(this.context)).GetByID(1).id_st_Programacao_trem; // CANCELADO

                    //ProgramacaoService programacaoService = new ProgramacaoService(this.context);

                    foreach (Nota item in param.Notas.ToList().OrderBy(c => c.id_nota))
                    {
                        #region --|Vinculando e Mudando Status da Nota |--
                        Nota nota               = notaService.GetNavigationPropertiesByID(int.Parse(item.id_nota.ToString()));
                        nota.id_programacao_fk  = param.id_programacao;

                        StatusUsuario stAber    = new StatusUsuario();
                        stAber                  = statusUsuarioService.GetByCdSap("ABER");

                        nota.StatusUsuarios.Add(stAber);
                        notaService.Update(nota);
                        #endregion

                        #region --|Mudando Status do Trem|--
                        Trem trem           = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                        trem.StatusTrem     = (new StatusTremService(this.context)).GetByID(1); // LIBERADO
                        tremService.Update(trem);
                        #endregion
                        stAber = null; nota = null; trem = null;
                    }

                    context.ProgramacaoRepository.Update(Programacao);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    param.BaseModel.MensagemUsuario = Mensagens.Registro_Atualizado;
                    param.BaseModel.Retorno         = MessageType.Success;
                    param.BaseModel.Erro            = false;
                }
                catch (Exception e)
                {
                    param.BaseModel.Erro                = true;
                    param.BaseModel.Retorno             = MessageType.Error;
                    param.BaseModel.MensagemUsuario     = Mensagens.Erro_Processar;
                    param.BaseModel.MensagemException   = e;
                    dbContextTransaction.Rollback();
                    Console.Write("Erro");
                }
            }
            return param;
        }
        public Programacao LiberarProgramacao(Programacao param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    param.BaseModel.Erro = false;
                    ProgramacaoService ProgramacaoService = new ProgramacaoService(this.context);
                    Programacao Programacao = new Programacao();

                    Programacao                 = ProgramacaoService.GetNavigationPropertiesByID(param.id_programacao);
                    Programacao.dt_liberacao    = param.dt_liberacao;
                    Programacao.hr_liberacao    = param.dt_liberacao;
                    Programacao.id_rg_liberacao = param.id_rg_liberacao;


                    #region --|Mudando Status do Trem|--
                    TremService tremService = new TremService(this.context);
                    Trem trem = tremService.GetNavigationPropertiesByID(int.Parse(param.id_trem_fk.ToString()));
                    trem.StatusTrem = (new StatusTremService(this.context)).GetByID(int.Parse(param.Trem.st_trem.ToString()));
                    tremService.Update(trem);
                    #endregion
                    Programacao.st_programacao = param.st_programacao;
                    context.ProgramacaoRepository.Update(Programacao);
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
        public Programacao MudarLocalProgramacao(Programacao param)
        {
            using (var dbContextTransaction = this.context.Database.BeginTransaction())
            {
                try
                {
                    //param.BaseModel.Erro = false;
                    //ProgramacaoService ProgramacaoService = new ProgramacaoService(this.context);
                    //Programacao Programacao = new Programacao();

                    //Programacao = ProgramacaoService.GetNavigationPropertiesByID(param.id_Programacao);
                    //Programacao.id_patio_fk = param.id_patio_fk;
                    //Programacao.id_lin_Programacao = param.id_lin_Programacao;
                    //context.ProgramacaoRepository.Update(Programacao);
                    //context.SaveChanges();
                    //dbContextTransaction.Commit();

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

        public List<Programacao> AutoComplete(string campo, string term)
        {
            switch (campo)
            {
                case "ds_descricao_nota": return context.ProgramacaoRepository.AsQueryable().Where(x => x.ds_observacao.StartsWith(term)).ToList();
                default: return null;
            }
        }


    }
}