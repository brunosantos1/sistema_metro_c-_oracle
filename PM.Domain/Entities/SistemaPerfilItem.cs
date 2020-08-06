using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOSistemaPerfilItem")]
    public class SistemaPerfilItem : EntityTypeConfiguration<SistemaPerfilItem>
    {
        public SistemaPerfilItem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Registro")]
        public int id_perfilItem { get; set; }
        [Display(Name = "ID Perfil")]
        public int id_perfil_fk { get; set; }

        [Display(Name = "Acessar Módulo")]
        public bool flg_Acessar { get; set; }

        [Display(Name = "Incluir?")]
        public bool flg_Incluir { get; set; }

        [Display(Name = "Alterar?")]
        public bool flg_Alterar { get; set; }

        [Display(Name = "Exportar?")]
        public bool flg_Exportar { get; set; }

        [Display(Name = "Imprimir?")]
        public bool flg_Imprimir { get; set; }

        #region Campos de retorno de erro em Add, Update, Delete
        [NotMapped]
        public BaseModel BaseModel { get; set; }
        #endregion
    }
}
