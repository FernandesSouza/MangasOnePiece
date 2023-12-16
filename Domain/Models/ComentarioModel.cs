using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Domain.Models
{

    [Table("comentarios")]
    public class ComentarioModel
    {
      

        [Key]
        public int id { get; set; }
        [Column("conteudo")]
        public string? conteudo { get; set; }
        [Column("usuarioid")]
        public int? usuarioid { get; set; }
        [Column("datacriacao")]
        public DateTime datacriacao { get; set; }
        [Column("nomeusuario")]
        public string? nomeusuario { get; set; } 
    }
}
