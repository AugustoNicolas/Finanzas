using System.ComponentModel.DataAnnotations;

namespace Finanzas.Model
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Saldo { get; set; }
        public int NCuenta { get; set; }
        public Usuario usuario { get; set; }
    }
}
