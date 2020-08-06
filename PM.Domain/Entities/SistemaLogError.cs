using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOSistemaLogError")]
    public class SistemaLogError : EntityTypeConfiguration<SistemaLogError>
    {
        public SistemaLogError() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Log Operações Item")]
        public int id_log_error { get; set; }

        [Required]
        [Display(Name = "Data Ocorrencia")]
        [DataType(DataType.DateTime)]
        public DateTime dt_ocorrencia { get; set; }

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
        [Display(Name = "Local Arquivo")]
        [StringLength(1000)]
        public string ds_path_file { get; set; }

        [Required]
        [Display(Name = "Tipo Error")]
        [StringLength(8000)]
        public string ds_type_error { get; set; }
        
        [Display(Name = "Error Link")]
        [StringLength(500)]
        [DataType(DataType.Url)]
        public string ds_error_link { get; set; }

        [Required]
        [Display(Name = "Código Error")]
        public string ds_error_id { get; set; }
        
        [Required]
        [Display(Name = "Mensagem de Error")]
        [StringLength(8000)]        
        public string ds_error_message { get; set; }

        [Required]
        [Display(Name = "Origem Error")]
        [StringLength(8000)]
        public string ds_error_source { get; set; }

        [Required]
        [Display(Name = "StackTrace")]
        [StringLength(8000)]
        public string ds_stack_trace { get; set; }

        [Required]
        [Display(Name = "TargetSite")]
        [StringLength(8000)]
        public string ds_target_site { get; set; }
        
        [Display(Name = "InnerException")]
        [StringLength(8000)]
        public string ds_inner_exception { get; set; }

        [Required]
        [Display(Name = "ID Aplicação")]
        public int id_aplicacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}