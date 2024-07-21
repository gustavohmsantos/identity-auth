using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UsuarioDbContext:IdentityDbContext<UsuarioModel>
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options ):base(options)
        {
            
        }
    }
}
