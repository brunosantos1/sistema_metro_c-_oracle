using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaLogOperacoes")]
    public class SistemaLogOperacoes : EntityTypeConfiguration<SistemaLogOperacoes>
    {
        public SistemaLogOperacoes() { BaseModel = new BaseModel(); }

        /*****************************************************************
         **
         ** Criado por : Alessandro Silvestre
         ** Criado em  : 08/04/2019
         ** Finalidade : Classe utilizada para gerenciar log de operacoes
         **
         *****************************************************************/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int id_log_operacoes { get; set; }

        [Required]
        [Display(Name = "Data Criação")]
        [DataType(DataType.DateTime)]
        public DateTime dt_ocorrencia { get; set; }

        [Required]
        [Display(Name = "ID Ação")]
        public int id_tipo_log_fk { get; set; }

        [Required]
        [Display(Name = "IP Address")]
        [StringLength(20)]
        public string ds_ipaddress { get; set; }

        [Required]
        [Display(Name = "Nome Equipamento")]
        [StringLength(50)]
        public string nm_machine { get; set; }

        [Required]
        [Display(Name = "Usuario do Login")]
        [StringLength(50)]
        public string nm_logon_user_identity_name { get; set; }

        [Required]
        [Display(Name = "Token do Usuario")]
        [StringLength(50)]
        public string id_logon_user_identity_token { get; set; }

        [Required]
        [Display(Name = "Controller")]
        [StringLength(50)]
        public string nm_controller { get; set; }

        [Required]
        [Display(Name = "Action")]
        [StringLength(50)]
        public string nm_action { get; set; }

        [Required]
        [Display(Name = "Url Completa")]
        [StringLength(500)]
        [DataType(DataType.Url)]
        public string ds_url_full { get; set; }

        [Required]
        [Display(Name = "JSon Origem")]
        [StringLength(8000)]
        public string ds_json_origem { get; set; }

        [Required]
        [Display(Name = "JSon Para")]
        [StringLength(8000)]
        public string ds_json_para { get; set; }

        [Required]
        [Display(Name = "ID Aplicação")]
        public int id_aplicacao { get; set; }

        public virtual List<SistemaLogOperacoesItem> Item { get; set; }

        #region Campos de retorno de erro em Add, Update, Delete
        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}
