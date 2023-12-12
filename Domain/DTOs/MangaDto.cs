namespace OnePiece.Domain.DTOs
{
    public class MangaDto
    {

        public int? iddocumento { get; set; }
        public string? capitulo { get; set; }
        public List<byte[]>? imagens { get; set; }
        public string? titulo { get; set; }
        public string? datapublicacao { get; set; }


        public MangaDto()
        {
            imagens = new List<byte[]>();
        }
    }
}
