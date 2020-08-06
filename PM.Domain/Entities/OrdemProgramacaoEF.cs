using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOOrdemProgramacaoEF")]
    public class OrdemProgramacaoEF : EntityTypeConfiguration<OrdemProgramacaoEF>
    {
        public OrdemProgramacaoEF() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("ProgramacaoEquipamentoFixo")]
        public int? id_programacao { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Ordem")]
        public int? id_ordem { get; set; }

        public string ds_sistema { get; set; }

        [ForeignKey("Nota")]
        public int? id_nota_fk { get; set; }

        public DateTime dt_planejada { get; set; }

        public DateTime dt_email { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public ProgramacaoEF ProgramacaoEquipamentoFixo { get; set; }
        public Ordem Ordem { get; set; }
        public Nota Nota { get; set; }
    }
}