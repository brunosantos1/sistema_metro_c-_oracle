using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPrioridade")]
    public class Prioridade : EntityTypeConfiguration<Prioridade>
    {
        public Prioridade() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_prioridade { get; set; }

        [StringLength(150)]
        public string ds_prioridade { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
