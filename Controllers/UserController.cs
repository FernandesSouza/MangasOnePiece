using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnePiece.Domain.DTOs;
using OnePiece.Infraestrutura.Interfaces;

namespace OnePiece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IMapper _mapper;

        public UserController(IUser user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        [HttpGet("usuario/{capitulo}")]
        public async Task<IActionResult> GetByCapitulo(string capitulo)
        {
            var manga = await _user.PesquisarManga(capitulo);

            var mangaDTO = _mapper.Map<MangaDto>(manga);

            if (mangaDTO is null)
            {
                return NotFound();
            }
            else
            {
                
                return Ok(new { Titulo = mangaDTO.titulo, DataPublicacao = mangaDTO.datapublicacao, Capitulo = mangaDTO.capitulo});
            }
        }

        [HttpGet("imagem/{capitulo}")]
        public async Task<IActionResult> GetImageManga(string capitulo, int indice)
        {
            var manga = await _user.PesquisarManga(capitulo);
            var mangaDTO = _mapper.Map<MangaDto>(manga);

            if (mangaDTO is null || mangaDTO.imagens is null || indice < 0 || indice >= mangaDTO.imagens.Count)
            {
                return NotFound();
            }
            else
            {
                return File(mangaDTO.imagens[indice], "image/webp");
            }

        }

    }
}
