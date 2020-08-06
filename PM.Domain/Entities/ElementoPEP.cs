using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOElementoPEP")]
    public class ElementoPEP : EntityTypeConfiguration<ElementoPEP>
    {
        public ElementoPEP() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_elemento_pep { get; set; }

        [StringLength(150)]
        public string ds_elemento_pep { get; set; }

        [StringLength(12)]
        public string cd_sap { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}