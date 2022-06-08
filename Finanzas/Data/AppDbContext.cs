using Finanzas.Model;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Cuenta> cuenta { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Transaccion> transaccion { get; set; }

        public Usuario ValidarUsuario(string _correo, string _clave, string _nombre)
        {
            return usuarios.Where(u => u.Correo == _correo && u.Clave == _clave && u.Nombre == _nombre).FirstOrDefault();
        }

    }
}
