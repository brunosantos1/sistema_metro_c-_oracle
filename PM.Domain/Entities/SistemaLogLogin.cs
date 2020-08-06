using PM.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaLogLogin")]
    public class SistemaLogLogin : EntityTypeConfiguration<SistemaLogLogin>
    {
        public SistemaLogLogin() { BaseModel = new BaseModel(); }

        /*****************************************************************
         **
         ** Criado por : Alessandro Silvestre
         ** Criado em  : 08/04/2019
         ** Finalidade : Classe utilizada para gerenciar log de login
         **
         *****************************************************************/

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int id_log_login { get; set; }

        [Required]
        [Display(Name = "DataOcorrencia")]
        [DataType(DataType.DateTime)]
        public DateTime dt_ocorrencia { get; set; }

        [Required]
        [Display(Name = "IP Address")]
        public string ds_ipaddress { get; set; }

        [Required]
        [Display(Name = "Nome Equipamento")]
        public string nm_machine { get; set; }

        [Required]
        [Display(Name = "Usuario do Login")]
        public string nm_logon_user_identity_name { get; set; }

        [Required]
        [Display(Name = "Token do Usuario")]
        public string id_logon_user_identity_token { get; set; }

        [Required]
        [Display(Name = "Navegador")]
        public string nm_browser_name { get; set; }

        [Required]
        [Display(Name = "Versao")]
        public string nm_browser_version { get; set; }

        [Required]
        [Display(Name = "Aceita Cookie?")]
        public bool is_browser_cookies { get; set; }

        [Required]
        [Display(Name = "Sistema Operacoinal")]
        public string nm_platforma { get; set; }

        [Required]
        [Display(Name = "SO 16bits?")]
        public bool is_win16 { get; set; }

        [Required]
        [Display(Name = "SO 32bits?")]
        public bool is_win32 { get; set; }
        
        [Required]
        [Display(Name = "URL de acesso")]
        public string ds_url_full { get; set; }

        [Required]
        [Display(Name = "ID Aplicação")]
        public int id_aplicacao { get; set; }

        #region Campos de retorno de erro em Add, Update, Delete

        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}
