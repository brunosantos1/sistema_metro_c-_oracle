using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOMaterialOperacao")]
    public class MaterialOperacao : EntityTypeConfiguration<MaterialOperacao>
    {
        public MaterialOperacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_materialop { get; set; }

        [ForeignKey("OperacaoOrdem")]
        public int? id_operacao_fk { get; set; }

        [StringLength(40)]
        public string dn_material { get; set; }

        public decimal qt_material { get; set; }

        [ForeignKey("UnidadeMedida")]
        public int? id_unidade_fk { get; set; }

        [ForeignKey("CategoriaItem")]
        public int? id_categoria_item_fk { get; set; }

        [ForeignKey("Deposito")]
        public int? id_deposito_fk { get; set; }

        [ForeignKey("CentroLocalizacao")]
        public int? id_ct_localizacao_fk { get; set; }

        public bool rl_reserva { get; set; }

        public string ds_local_entrega { get; set; }

        [StringLength(50)]
        public string nm_recebedor { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public CategoriaItem CategoriaItem { get; set; }
        public OperacaoOrdem OperacaoOrdem { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public Deposito Deposito { get; set; }
    }
}