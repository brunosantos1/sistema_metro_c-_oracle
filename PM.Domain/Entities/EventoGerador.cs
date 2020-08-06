using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PM.Domain.Entities
{
    [Table("OOEventoGerador")]
    public class EventoGerador : EntityTypeConfiguration<EventoGerador>
    {
        public EventoGerador() { BaseModel = new BaseModel(); }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_evento_gerador { get; set; }

        [StringLength(150)]
        public string ds_evento_gerador { get; set; }

        [NotMapped]
        public BaseModel BaseModel { get; set; }
    }
}