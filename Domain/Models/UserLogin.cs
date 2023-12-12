namespace OnePiece.Domain.Models
{
    public class UserLogin
    {
        public UserLogin(string? usuario, string? senha)
        {
            this.usuario = usuario;
            this.senha = senha;
            
        }

        public string? usuario { get; set; }
        public string? senha { get; set; }
      

        
    }
}
