namespace OnePiece.Domain.Models
{
    public class UserLogin
    {
        public UserLogin(string? usuario, string? senha, string? email)
        {
            this.usuario = usuario;
            this.senha = senha;
            this.email = email;
        }

        public string? usuario { get; set; }
        public string? senha { get; set; }
        public string? email { get; set; }
      

        
    }
}
