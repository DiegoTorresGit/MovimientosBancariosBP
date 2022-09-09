using System.ComponentModel.DataAnnotations;

namespace transaccionalAPI.Models
{
    public class Persona
    {
        [Key]
        public int codigo_per { get; set; }
        public string nombre_per { get; set; }
        public bool genero_per { get; set; }
        public int edad_per { get; set; }
        public string identificacion_per { get; set; }
        public string direccion_per { get; set; }
        public string telefono_per { get; set; }
    }
}
