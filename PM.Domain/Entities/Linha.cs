using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOLinha")]
    public class Linha : EntityTypeConfiguration<Linha>
    {
        public Linha() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_linha { get; set; }

        [MaxLength(20)]
        public string nm_linha { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_centro_trabalho_fk { get; set;}

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public CentroTrabalho CentroTrabalho { get; set; }
    }
}
