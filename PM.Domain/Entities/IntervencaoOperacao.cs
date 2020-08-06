using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOIntervencaoOperacao")]
    public class IntervencaoOperacao : EntityTypeConfiguration<IntervencaoOperacao>
    {
        public IntervencaoOperacao() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_intervencao { get; set; }

        [ForeignKey("OperacaoOrdem")]
        public int? id_operacao_fk { get; set; }

        [ForeignKey("LocalInstalacao")]
        public int? id_local_instalacao_fk { get; set; }

        [ForeignKey("CodeParteObjeto")]
        public int? id_code_parte_objeto_fk { get; set; }

        [ForeignKey("CodeDefeito")]
        public int? id_code_defeito_fk { get; set; }

        [ForeignKey("CodeReparo")]
        public int? id_code_reparo_fk { get; set; }

        public int qt_intervencao { get; set; }

        [ForeignKey("Marco")]
        public int? mc_invervencao { get; set; }

        public decimal di_intervencao { get; set; }

        public decimal co_intervencao { get; set; }

        [ForeignKey("EquipamentoDesinstalado")]
        public int? id_equipamento_desinstalado_fk { get; set; }

        [ForeignKey("EquipamentoInstalado")]
        public int? id_equipamento_instalado_fk { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }

        //Propriedade de navegação
        public OperacaoOrdem OperacaoOrdem { get; set; }
        public Equipamento EquipamentoDesinstalado { get; set; }
        public Equipamento EquipamentoInstalado { get; set; }
        public Code CodeDefeito { get; set; }
        public Code CodeReparo { get; set; }
        public Code CodeParteObjeto { get; set; }
        public LocalInstalacao LocalInstalacao { get; set; }
        public Marco Marco { get; set; }
    }
}