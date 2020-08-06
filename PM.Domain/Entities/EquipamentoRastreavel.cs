using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEquipamentoRastreavel")]
    public class EquipamentoRastreavel : EntityTypeConfiguration<EquipamentoRastreavel>
    {
        public EquipamentoRastreavel() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_eq_rastreavel { get; set; }

        [ForeignKey("Nota")]
        public int? id_nota_fk { get; set; }

        public DateTime dt_subs_equip { get; set; }

        public DateTime hr_subs_equip { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_local_inst_fk { get; set; }

        [ForeignKey("EquipamentoRemovido")]
        public int? id_equip_removido_fk { get; set; }

        [ForeignKey("EquipamentoInstalado")]
        public int? id_equip_instalado_fk { get; set; }

        [ForeignKey("DocumentoMedicao")]
        public int? id_doc_medicao_fk { get; set; }

        [ForeignKey("Empregado")]
        public int? id_empregado_fk { get; set; }

        [StringLength(150)]
        public string ds_st_pericia { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public Nota Nota { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public Equipamento EquipamentoRemovido { get; set; }
        public Equipamento EquipamentoInstalado { get; set; }
        public Documento DocumentoMedicao { get; set; }
        public Empregado Empregado { get; set; }
    }
}