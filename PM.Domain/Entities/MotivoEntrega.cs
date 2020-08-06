using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOMotivoEntrega")]
    public class MotivoEntrega : EntityTypeConfiguration<MotivoEntrega>
    {
        public MotivoEntrega() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_motivo_entrega { get; set; }

        [StringLength(20)]
        public string ds_motivo_entrega { get; set; }

        [StringLength(3)]
        //[Index("IX_MotivoEntrega", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}