using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Dtos
{
    public class LoginUsuarioDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
