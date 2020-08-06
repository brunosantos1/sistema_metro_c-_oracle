using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOAreaOperacional")]
    public class AreaOperacional : EntityTypeConfiguration<AreaOperacional>
    {
        public AreaOperacional() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ar_operacional { get; set; }

        [StringLength(3)]
        //[Index("IX_AreaOperacional", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_ar_operacional { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}