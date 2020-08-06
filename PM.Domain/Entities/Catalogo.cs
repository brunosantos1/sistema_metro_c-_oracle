using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCatalogo")]
    public class Catalogo : EntityTypeConfiguration<Catalogo>
    {
        public Catalogo() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_catalogo { get; set; }
        
        [StringLength(9)]
        //[Index("IX_Catalogo", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        public virtual ICollection<GrupoCode> GruposCode { get; set; }

        public virtual ICollection<Perfil> Perfis { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
