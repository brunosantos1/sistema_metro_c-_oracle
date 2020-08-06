using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusCopese")]
    public class StatusCopese : EntityTypeConfiguration<StatusCopese>
    {
        public StatusCopese() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_copese { get; set; }

        [StringLength(150)]
        public string ds_st_copese { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}