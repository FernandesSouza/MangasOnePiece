using OnePiece.Domain.Models;

namespace OnePiece.Infraestrutura.Interfaces
{
    public interface IUser
    {

        Task<MangasModel> PesquisarManga(string capitulo);
        Task<UsuarioModel> RegisterNewUser(UsuarioModel usuario);   
       

    }
}
