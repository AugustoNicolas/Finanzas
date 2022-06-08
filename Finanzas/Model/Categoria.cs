using System.ComponentModel.DataAnnotations;

namespace Finanzas.Model
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cod { get; set; }
        [Required]
        public int UsuarioId { get; set; }
    }
}
