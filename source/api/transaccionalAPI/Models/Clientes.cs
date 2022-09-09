using System.ComponentModel.DataAnnotations;

namespace transaccionalAPI.Models
{
    public class Clientes
    {
        [Key]
        public int codigo_cli { get; set; }
        public string contrasena_cli { get; set; }
        public bool estado_cli { get; set; }
        public int codigo_per { get; set; }

    }
}
