using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOClassificacao")]
    public class Classificacao : EntityTypeConfiguration<Classificacao>
    {
        public Classificacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_classificacao { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_lc_instalacao_fk { get; set; }

        [ForeignKey("Equipamento")]
        public int? id_equipamento_fk { get; set; }

        [ForeignKey("CentroLocalizacao"), Column(Order = 1)]
        public int? id_centro_fk { get; set; }

        [ForeignKey("CentroTrabalho"), Column(Order = 2)]
        public int? id_ct_trabalho_fk { get; set; }

        [StringLength(18)]
        public string cd_classe { get; set; }

        [StringLength(30)]
        public string cd_caracteristica { get; set; }

        [StringLength(30)]
        public string cd_valor_caracteristica { get; set; }

        public bool st_classificacao { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de Navegação       
        public CentroLocalizacao CentroLocalizacao { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public CentroTrabalho CentroTrabalho { get; set; }
        public Equipamento Equipamento { get; set; }
    }
}
