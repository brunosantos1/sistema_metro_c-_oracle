using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusEntregaTrem")]
    public class StatusEntregaTrem : EntityTypeConfiguration<StatusEntregaTrem>
    {
        public StatusEntregaTrem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_entrega_trem { get; set; }

        [StringLength(50)]
        public string ds_st_entrega_trem { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}