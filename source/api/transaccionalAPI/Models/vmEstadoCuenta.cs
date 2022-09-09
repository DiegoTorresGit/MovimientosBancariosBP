using System.ComponentModel.DataAnnotations;

namespace transaccionalAPI.Models
{
    public class vmEstadoCuenta
    {
        [Key]

        public string fechaInicio { get; set; }
        public string Cliente { get; set; }
        public string numeroCuenta { get; set; }
        public string tipo { get; set; }
        public decimal saldoInicial { get; set; }
        public string estado { get; set; }
        public decimal movimiento { get; set; }
        public decimal saldoDisponible { get; set; }

        
    }
}
