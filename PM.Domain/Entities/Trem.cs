using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOTrem")]
    public class Trem : EntityTypeConfiguration<Trem>
    {
        public Trem() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_trem { get; set; }

        [StringLength(3)]
        public string cd_sap { get; set; }

        [ForeignKey("Documento")]
        public int? id_doc_medicao_fk { get; set; }

        [MaxLength(20)]
        public string nm_trem { get; set; }

        [ForeignKey("Frota")]
        public int? id_frota_fk { get; set; }

        [ForeignKey("LinhaOrigem")]
        public int? id_linha_origem_fk { get; set; }

        [ForeignKey("Patio")]
        public int? id_patio_fk { get; set; }

        [ForeignKey("LinhaAtual")]
        public int? id_linha_atual_fk { get; set; }

        public bool st_manobra { get; set; }

        [ForeignKey("StatusTrem")]
        public int? st_trem { get; set; }

        public bool st_disponivel { get; set; }
        
        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Frota Frota { get; set; }
        public Documento Documento { get; set; }
        public Linha LinhaOrigem { get; set; }
        public Linha LinhaAtual { get; set; }
        public Patio Patio { get; set; }
        public StatusTrem StatusTrem { get; set; }
    }
}
