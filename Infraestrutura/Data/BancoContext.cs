using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Models;

namespace OnePiece.Infraestrutura.Data
{
    public class BancoContext : DbContext
    {


        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<MangasModel> manga { get; set; }
        public DbSet<AdministradorModel> administradores { get; set; }
    }
}
