using System.ComponentModel.DataAnnotations;

namespace OnePiece.Domain.DTOs
{
    public class UsuarioDTO
    {
        public UsuarioDTO(int id, string nome, string email, string senha, bool isModerador)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.isModerador = isModerador;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public bool isModerador { get; set; }
    }
}
