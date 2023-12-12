using OnePiece.Domain.Models;

namespace OnePiece.Infraestrutura.Interfaces
{
    public interface ITokenService
    {

        string GerarToken(AdministradorModel administrador);

    }
}
