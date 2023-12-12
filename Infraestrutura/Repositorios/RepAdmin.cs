using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Data;
using OnePiece.Infraestrutura.Interfaces;

namespace OnePiece.Infraestrutura.Repositorios
{
    public class RepAdmin : IAdmin
    {

        private readonly BancoContext _context;

        public RepAdmin(BancoContext context)
        {
            _context = context;
        }

        public async Task<MangasModel> EditarMangas(MangasModel model)
        {

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model;

        }

        public Task<MangasModel> PesquisarManga(string capitulo)
        {
            var manga = _context.manga.FirstOrDefaultAsync(m => m.capitulo == capitulo);
            return manga!;
        }

        public async Task<MangasModel> PublicarManga(MangasModel manga)
        {
            await _context.manga.AddAsync(manga);
            await _context.SaveChangesAsync();

            return manga;
        }


        public async Task Remover(string capitulo)
        {
            var remove = await _context.manga.SingleOrDefaultAsync(c => c.capitulo == capitulo);

            if (remove != null)
            {
                _context.manga.Remove(remove);
                await _context.SaveChangesAsync();
            }
        }


    }
}
