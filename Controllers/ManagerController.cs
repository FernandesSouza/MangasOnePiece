using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnePiece.Domain.DTOs;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Interfaces;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace OnePiece.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {

        private readonly IAdmin _admin;
        private readonly IMapper _mapper;

        public ManagerController(IAdmin admin, IMapper mapper)
        {
            _admin = admin;
            _mapper = mapper;
        }

        private int? ObterUsarioAutenticado()
        {
            var claimMatricula = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "idusuario");
            if (claimMatricula != null && int.TryParse(claimMatricula.Value, out int matricula))
            {
                return matricula;
            }

            return null;
        }
        [HttpPost("publicar")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<MangasModel>> PublicarCapitulos([FromForm] MangasModel model, List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("Nenhuma imagem enviada");
            }
            else
            {
                foreach (var file in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        model.imagens?.Add(memoryStream.ToArray());
                    }
                }

                var newManga = await _admin.PublicarManga(model);
                var newMangaDto = _mapper.Map<MangaDto>(newManga);
                return CreatedAtAction(nameof(PublicarCapitulos), new { id = newMangaDto.iddocumento }, newMangaDto);
            }
        }
        [HttpGet("imagens/{capitulo}/{indice}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetImagem(string capitulo, int indice)
        {
            try
            {
                var idUser = ObterUsarioAutenticado();

                var manga = await _admin.PesquisarManga(capitulo);
                var mangaDTO = _mapper.Map<MangaDto>(manga);

                if (mangaDTO is null || mangaDTO.imagens is null || indice < 0 || indice >= mangaDTO.imagens.Count)
                {
                    return NotFound();
                }
                else
                {
                    return File(mangaDTO.imagens[indice], "image/webp");
                }

            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("deletar/{capitulo}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Deletar(string capitulo)
        {
            var remove = await _admin.PesquisarManga(capitulo);
            if( remove == null)
            {
                return BadRequest();

            } else
            {
                await _admin.Remover(remove.capitulo!);
                return Ok();
            }               

        }
        [HttpPut("editar/{capitulo}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Editar(string capitulo, [FromForm] MangasModel model, IFormFile file)
        {
            //Pesquisa se existe algum manga existente
            var mangaExistente = await _admin.PesquisarManga(capitulo);
            var mangaExistenteDto = _mapper.Map<MangaDto>(mangaExistente);
            if (mangaExistenteDto is null) {
                return NotFound();          
            
            } else
            {
                // o manga existente vai receber as informações da model
                mangaExistenteDto.titulo = model.titulo;
                mangaExistenteDto.capitulo = model.capitulo;
                mangaExistenteDto.datapublicacao = model.datapublicacao;

                // TROCAR AS IMAGENS TAMBÉM
                if (file != null && file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        byte[] novoArrayDeBytes = memoryStream.ToArray();
                        mangaExistenteDto.imagens?.Add(novoArrayDeBytes); 
                    }
                }
                var mangaUpdateModel = _mapper.Map<MangasModel>(mangaExistenteDto);
                var mangaUpdate = await _admin.EditarMangas(mangaUpdateModel);

                return Ok(mangaUpdate);

            }
        }
    }
}
