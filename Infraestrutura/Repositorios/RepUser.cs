using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Data;
using OnePiece.Infraestrutura.Interfaces;

namespace OnePiece.Infraestrutura.Repositorios
{
    public class RepUser : IUser
    {

        private readonly BancoContext _context;

        public RepUser(BancoContext context)
        {
            _context = context;
        }
        public Task<MangasModel> PesquisarManga(string capitulo)
        {
            var manga = _context.manga.SingleOrDefaultAsync(c => c.capitulo == capitulo);
            return manga;
            
            

        }

        public async Task<UsuarioModel> RegisterNewUser(UsuarioModel usuario)
        {
            await _context.usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
            
        }
    }
}
