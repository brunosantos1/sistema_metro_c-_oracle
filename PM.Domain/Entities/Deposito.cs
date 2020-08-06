using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OODeposito")]
    public class Deposito : EntityTypeConfiguration<Deposito>
    {
        public Deposito() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_deposito { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
