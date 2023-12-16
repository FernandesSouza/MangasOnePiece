using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnePiece.Domain.DTOs;
using OnePiece.Domain.Models;
using OnePiece.Infraestrutura.Interfaces;
using System.Runtime.CompilerServices;

namespace OnePiece.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly IChatRepositorie _repositorie;
        private readonly IMapper _mapper;

        public ChatController(IChatRepositorie repositorie, IMapper mapper)
        {
            _repositorie = repositorie;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> PostarComentario(ComentarioDTO comentarioDTO)
        {
            var user = User.FindFirst("username")?.Value;
            var userID = User.FindFirst("id")?.Value;
            var comentario =  _mapper.Map<ComentarioModel>(comentarioDTO);
            comentario.nomeusuario = user;
            comentario.usuarioid= int.Parse(userID);
            await _repositorie.PostarComentario(comentario);
            return Ok(comentario);

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioDTO>>> FeedComentarios()
        {

            var comentarios = await _repositorie.Feed();

            var comentariosDTO = _mapper.Map<IEnumerable<ComentarioDTO>>(comentarios);

            return Ok(comentariosDTO);

        }
    }

}
