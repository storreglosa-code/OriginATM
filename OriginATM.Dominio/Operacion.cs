using OriginATM.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Dominio
{
    public class Operacion
    {
        public int Id { get; set; }
        [Required]
        public int TarjetaId { get; set; }
        public Tarjeta Tarjeta { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public TipoOperacion Tipo { get; set; }
        
        public decimal? Monto { get; set; } 
    }
}
