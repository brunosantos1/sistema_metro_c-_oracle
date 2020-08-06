using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOCalendarioFabrica")]
    public class CalendarioFabrica : EntityTypeConfiguration<CalendarioFabrica>
    {
        public CalendarioFabrica() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_calendario_fabrica { get; set; }

        public DateTime dt_valido_desde_ano { get; set; }

        public DateTime dt_valido_ate_ano { get; set; }

        public bool tb_segunda { get; set; }

        public bool tb_terca { get; set; }

        public bool tb_quarta { get; set; }

        public bool tb_quinta { get; set; }

        public bool tb_sexta { get; set; }

        public bool tb_sabado { get; set; }

        public bool tb_domingo { get; set; }

        public bool tb_feriado { get; set; }

        public DateTime dt_ativo_desde_ano { get; set; }

        public DateTime dt_ativo_ate_ano { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}
