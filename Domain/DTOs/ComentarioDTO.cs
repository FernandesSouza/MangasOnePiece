namespace OnePiece.Domain.DTOs
{
    public class ComentarioDTO
    {

        public int Id { get; set; }
        public string? Conteudo { get; set; }
        public int? UsuarioId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? NomeUsuario { get; set; }
    }
}

