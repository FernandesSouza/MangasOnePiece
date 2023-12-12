using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnePiece.Domain.Models
{
    [Table("administradores")]
    public class AdministradorModel
    {
        [Key]
      
        public int idusuario { get; set; }
        public string? nome { get; set; }
        public string? senha { get; init; }
        public string usuario { get; set; }

        public AdministradorModel(int idusuario, string nome, string senha, string usuario)
        {
            this.idusuario = idusuario;
            this.nome = nome;
            this.senha = senha;
            this.usuario = usuario;
        }



    }
}
