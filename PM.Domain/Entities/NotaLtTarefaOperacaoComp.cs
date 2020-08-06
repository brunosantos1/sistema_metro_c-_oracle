using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OONotaLtTarefaOperacaoComp")]
    public class NotaLtTarefaOperacaoComp : EntityTypeConfiguration<NotaLtTarefaOperacaoComp>
    {
        public NotaLtTarefaOperacaoComp() { BaseModel = new BaseModel(); }

        [Key, Column(Order = 0)]
        [ForeignKey("ListaTarefaOperacaoComponente")]
        public int? id_lt_tar_op_comp_fk { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Nota")]
        public int? id_nota_fk { get; set; }

        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public ListaTarefaOperacaoComponente ListaTarefaOperacaoComponente { get; set; }
        public Nota Nota { get; set; }
    }
}
