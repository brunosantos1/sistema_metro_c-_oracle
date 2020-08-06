using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaLogOperacoesItem")]
    public class SistemaLogOperacoesItem : EntityTypeConfiguration<SistemaLogOperacoesItem>
    {
        public SistemaLogOperacoesItem() { BaseModel = new BaseModel(); }

        /*****************************************************************
         **
         ** Criado por : Alessandro Silvestre
         ** Criado em  : 08/04/2019
         ** Finalidade : Classe utilizada para gerenciar log de operacoes
         **
         *****************************************************************/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Log Operações Item")]
        public int id_log_operacoes_item { get; set; }
        
        [Required]
        [Display(Name = "ID Log Operações")]
        public int id_log_operacoes { get; set; }

        [Required]
        [Display(Name = "Nome Propriedade")]
        [StringLength(50)]
        public string ds_propriedade { get; set; }

        [Required]
        [Display(Name = "Nome Amigavél da Propriedade")]
        [StringLength(50)]
        public string nm_amigavel { get; set; }

        [Required]
        [Display(Name = "Valor Original")]
        [StringLength(200)]
        public string ds_valor_origem { get; set; }

        [Display(Name = "Valor Alterado")]
        [StringLength(200)]
        public string ds_valor_para { get; set; }

        [Required]
        [Display(Name = "Ordem Exibição")]
        public int nu_ordem{ get; set; }

        #region Campos de retorno de erro em Add, Update, Delete

        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}
