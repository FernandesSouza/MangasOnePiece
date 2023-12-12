using OnePiece.Domain.Models;

namespace OnePiece.Infraestrutura.Interfaces
{
    public interface IUser
    {

        Task<MangasModel> PesquisarManga(string capitulo);
            
       

    }
}
