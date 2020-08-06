using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOParceiro")]
    public class Parceiro : EntityTypeConfiguration<Parceiro>
    {
        public Parceiro() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_parceiro { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_local_inst_fk { get; set; }

        [ForeignKey("Equipamento")]
        public int? id_equipamento_fk { get; set; }

        [ForeignKey("CentroTrabalho")]
        public int? id_ct_trabalho_fk { get; set; }

        [StringLength(2)]
        public string sg_funcao_parceiro { get; set; }

        [StringLength(12)]
        //[Index("IX_Parceiro", IsClustered = true, IsUnique = true)]
        public string cd_sap { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public LocalInstalacao LocalInstalacao { get; set; }
        public Equipamento Equipamento { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
    }
}
