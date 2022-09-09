using System;
using System.ComponentModel.DataAnnotations;

namespace transaccionalAPI.Models
{
    public class Movimientos
    {
        [Key]
        public long codigo_mov { get; set; }
        public DateTime fecha_mov { get; set; }
        public decimal valor_mov { get; set; }      
        public decimal saldo_mov { get; set; }
        public int codigo_cue { get; set; }
        public int codigo_tm { get; set; }
    }
}
