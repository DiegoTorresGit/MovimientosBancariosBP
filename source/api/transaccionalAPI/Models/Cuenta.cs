using System.ComponentModel.DataAnnotations;

namespace transaccionalAPI.Models
{
    public class Cuenta
    {
        [Key]
        public int codigo_cue { get; set; }
        public string numero_cue { get; set; }
        public decimal saldo_inicial_cue { get; set; }
        public int codigo_tc { get; set; }
        public int codigo_cli { get; set; }
        public int codigo_est { get; set; }

    }
}
