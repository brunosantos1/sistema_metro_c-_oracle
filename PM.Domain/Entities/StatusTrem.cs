using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusTrem")]
    public class StatusTrem : EntityTypeConfiguration<StatusTrem>
    {
        public StatusTrem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_trem { get; set; }

        [StringLength(50)]
        public string ds_st_trem { get; set; }

        [StringLength(06)]
        public string ds_gr_st_trem { get; set; }
        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}