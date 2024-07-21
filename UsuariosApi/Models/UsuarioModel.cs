using Microsoft.AspNetCore.Identity;

namespace UsuariosApi.Models
{
    public class UsuarioModel:IdentityUser
    {
        public DateTime DataNascimento { get; set; }

        public UsuarioModel():base()
        {
            
        }
    }
}
