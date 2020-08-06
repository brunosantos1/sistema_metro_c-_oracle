using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
namespace PM.Domain.Entities
{
    [Table("OOSistemaPerfil")]
    public class SistemaPerfil : EntityTypeConfiguration<SistemaPerfil>
    {
        public SistemaPerfil() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int id_perfil { get; set; }

        [Display(Name = "Registro Ativo?")]
        public bool flg_ativo { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Descrição")]
        public string ds_descricao { get; set; }

        public virtual List<SistemaPerfilItem> Item { get; set; }

        [Required]
        [StringLength(8000)]
        [Display(Name = "HTML Menu")]
        public string HTMLStringMenu { get; set; }

        [Display(Name = "Num. Usuários")]
        public int num_Usuarios { get; set; }

        [Display(Name = "Usuários Logados ")]
        public int num_Usuarios_logados { get; set; }

        [Required]
        [Display(Name = "ID Aplicação")]
        public int id_aplicacao { get; set; }

        #region Campos de retorno de erro em Add, Update, Delete
        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}
