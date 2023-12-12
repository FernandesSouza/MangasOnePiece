using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Data;
using OnePiece.Infraestrutura.Interfaces;

namespace OnePiece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _token;
        private readonly BancoContext _context;

        public AuthController(ITokenService token, BancoContext context)
        {
            _token = token;
            _context = context;
        }

        [HttpPost]
        [Route("LoginAdministrador")]
        public async Task<ActionResult<dynamic>> AutenticarAdministrador(UserLogin login)
        {
            try
            {
                var administrador = await _context.administradores.SingleOrDefaultAsync(c => c.usuario == login.usuario && c.senha == login.senha);

                if (administrador != null)
                {
                    var token = _token.GerarToken(administrador);
                    return Ok(new { Token = token, Administrador = administrador });
                }
                else
                {
                    return BadRequest("Usuário ou senha inválidos");

                }
            }
            catch
            {
                return BadRequest("ERRO INTERNO");
            }

        }
    }
}
