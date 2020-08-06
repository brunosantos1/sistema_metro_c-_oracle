using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OONotaProgramacao")]
    public class NotaProgramacao : EntityTypeConfiguration<NotaProgramacao>
    {
        public NotaProgramacao() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("Nota")]
        public int? id_nota_fk { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Programacao")]
        public int? id_programacao_fk { get; set; }

        [ForeignKey("EntregaTrem")]
        public int? id_entrega_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Nota Nota { get; set; }
        public Programacao Programacao { get; set; }
        public EntregaTrem EntregaTrem { get; set; }
    }
}