using System.ComponentModel.DataAnnotations;

namespace Finanzas.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        public string Rol { get; set; }
    }
}
