using OnePiece.Domain.Models;
using System.Security.Claims;

namespace OnePiece.Infraestrutura.Interfaces
{
    public interface IAdmin
    {
        Task<MangasModel> PublicarManga(MangasModel manga);
        Task<MangasModel> EditarMangas(MangasModel model);
        Task Remover(string capitulo);
        Task<MangasModel> PesquisarManga(string capitulo);
    }
}
