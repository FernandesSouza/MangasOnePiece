using Microsoft.IdentityModel.Tokens;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace OnePiece.Applications.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _chave;

        public TokenService(IConfiguration config)
        {
            _chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["chaveSecreta"]!));
        }

        public string GerarToken(AdministradorModel administrador)
        {
            var claims = new List<Claim>
            {
                new Claim("idusuario",administrador.idusuario.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, administrador.usuario),
                new Claim(JwtRegisteredClaimNames.Sub, administrador.senha!),
                new Claim(ClaimTypes.Role, "Administrador")

            };

            var credencials = new SigningCredentials(_chave, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(3),

                SigningCredentials = credencials,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
