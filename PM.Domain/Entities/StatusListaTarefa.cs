using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOStatusListaTarefa")]
    public class StatusListaTarefa : EntityTypeConfiguration<StatusListaTarefa>
    {
        public StatusListaTarefa() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_st_lt_tarefa { get; set; }

        [StringLength(2)]
        //[Index("IX_StatusListaTarefa", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(150)]
        public string ds_st_lt_operacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}