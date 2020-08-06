using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace PM.Domain.Entities
{
    [Table("OOMAP")]
    public class MAP : EntityTypeConfiguration<MAP>
    {
        public MAP() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_map { get; set; }

        [ForeignKey("OperacaoOrdem")]
        public int? id_operacao_fk { get; set; }

        [StringLength(40)]
        public string dn_map { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public OperacaoOrdem OperacaoOrdem { get; set; }
    }
}