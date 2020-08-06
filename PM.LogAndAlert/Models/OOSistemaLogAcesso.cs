using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.LogAndAlert.Models
{
    [Table("OOSistemaLogAcesso")]
    public class SistemaLogAcesso : EntityTypeConfiguration<SistemaLogAcesso>
    {
        [Key]
        [Required]
        [Display(Name = "ID Registro")]
        public int id_log { get; set; }

        [Required]
        [Display(Name = "IDUsuario")]
        public int id_usuario { get; set; }

        [Required]
        [Display(Name = "IDModulo")]
        public int id_modulo { get; set; }

        [Required]
        [Display(Name = "Data Criação Log")]
        public DateTime dt_criacao { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "URL Acessada")]
        public string ds_UrlAcessada { get; set; }
    }
}