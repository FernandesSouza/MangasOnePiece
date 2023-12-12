using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Domain.Models
{
    [Table("manga")]
    public class MangasModel
    {
        [Key]
        public int? iddocumento { get; set; }
        public string? capitulo { get; set; }
        public List<byte[]>? imagens { get; set; }
        public string? titulo { get; set;}
        public string? datapublicacao { get; set; }


        public MangasModel()
        {
            imagens = new List<byte[]>();
        }


    }
}
