using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOListaTarefaOperacaoComp")]
    public class ListaTarefaOperacaoComponente : EntityTypeConfiguration<ListaTarefaOperacaoComponente>
    {
        public ListaTarefaOperacaoComponente() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_lt_tar_op_comp { get; set; }
        
        [ForeignKey("Operacao")]
        public int? id_operacao_fk { get; set; }

        [ForeignKey("SubOperacao")]
        public int? id_sub_operacao_fk { get; set; }

        [ForeignKey("Material")]
        public int? id_material_fk { get; set; }

        public decimal nr_quantidade { get; set; }

        [ForeignKey("CategoriaItem")]
        public int? id_cg_item_fk { get; set; }

        [ForeignKey("Deposito")]
        public int? id_deposito_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação
        public Material Material { get; set; }
        public ListaTarefaOperacao Operacao { get; set; }
        public ListaTarefaOperacao SubOperacao { get; set; }
        public CategoriaItem CategoriaItem { get; set; }
        public Deposito Deposito { get; set; }
    }
}
