using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCode")]
    public class Code : EntityTypeConfiguration<Code>
    {
        public Code() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_code { get; set; }

        [StringLength(4)]
        //[Index("IX_Code", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [StringLength(40)]
        public string ds_code { get; set; }

        [ForeignKey("GrupoCode")]
        public int? id_gr_code_fk { get; set; }

        [ForeignKey("Prioridade")]
        public int? id_prioridade_fk { get; set; } 

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public GrupoCode GrupoCode { get; set; }
        public Prioridade Prioridade { get; set; }
    }
}
