using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Domain.Models
{
    public class UsuarioModel
    {
        public UsuarioModel(int id, string nome, string email, string senha, bool ismoderador)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.ismoderador = ismoderador;
        }

        public UsuarioModel()
        {
            
        }

        [Key]
        public int id { get; set; }

        [Column("nome")]
        public string nome { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("senha")]
        public string senha { get; set; }
        [Column("ismoderador")]
        public bool ismoderador { get; set; }  


        
    }
}
