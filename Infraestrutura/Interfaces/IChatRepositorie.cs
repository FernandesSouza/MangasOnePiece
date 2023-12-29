using OnePiece.Domain.Models;

namespace OnePiece.Infraestrutura.Interfaces
{
    public interface IChatRepositorie
    {
        Task PostarComentario(ComentarioModel comentario);
        Task<IEnumerable<ComentarioModel>> Feed();
    }
}
