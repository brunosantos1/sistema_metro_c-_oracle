using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOPrioridadeCentroTrabalho")]
    public class PrioridadeCentroTrabalho : EntityTypeConfiguration<PrioridadeCentroTrabalho>
    {
        public PrioridadeCentroTrabalho() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("Prioridade")]
        public int? id_prioridade_fk { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("CentroTrabalho")]
        public int? id_ct_resp { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_lc_instalacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Prioridade Prioridade { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
    }
}
