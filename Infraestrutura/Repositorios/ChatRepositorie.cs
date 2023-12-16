using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Data;
using OnePiece.Infraestrutura.Interfaces;

namespace OnePiece.Infraestrutura.Repositorios
{
    public class ChatRepositorie : IChatRepositorie
    {
        private readonly BancoContext _context;

        public ChatRepositorie(BancoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ComentarioModel>> Feed()
        {

            return await _context.comentario.ToListAsync();
        }

        public async Task PostarComentario(ComentarioModel comentario)
        {
            await _context.comentario.AddAsync(comentario);
            await _context.SaveChangesAsync();
        }
    }
}
