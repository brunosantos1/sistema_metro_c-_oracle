using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusOperacao")]
    public class StatusOperacao : EntityTypeConfiguration<StatusOperacao>
    {
        public StatusOperacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_operacao { get; set; }

        [StringLength(150)]
        public string ds_st_operacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}