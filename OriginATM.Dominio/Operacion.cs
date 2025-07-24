using OriginATM.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Dominio
{
    public class Operacion
    {
        public int Id { get; set; }

        public int TarjetaId { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public DateTime Fecha { get; set; }
        public TipoOperacion Tipo { get; set; }
        public decimal? Monto { get; set; } 
    }
}
