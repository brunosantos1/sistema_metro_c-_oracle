using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPerfil")]
    public class Perfil : EntityTypeConfiguration<Perfil>
    {
        public Perfil() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_perfil { get; set; }

        [StringLength(9)]
        //[Index("IX_Perfil", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(30)]
        public string ds_perfil { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public virtual ICollection<Catalogo> Catalogos { get; set; }
    }
}
