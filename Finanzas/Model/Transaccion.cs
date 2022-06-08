using System.ComponentModel.DataAnnotations;

namespace Finanzas.Model
{
    public class Transaccion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public float Monto { get; set; }
        public string Detalle { get; set; }
        public string tipo { get; set; }
        public Cuenta cuenta { get; set; }
        public Categoria categoria { get; set; }
    }
}
