using System.ComponentModel.DataAnnotations;

namespace transaccionalAPI.Models
{
    public class TipoCuenta
    {
        [Key]
        public int codigo_tc { get; set; }
        public string cuenta_tc { get; set; }
        public bool estado{ get; set; }
    }
}
