using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Dominio
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Pin { get; set; } 
        public decimal Balance { get; set; }
        public bool EstaBloqueada { get; set; }
        public ushort IntentosFallidos { get; set; }

        public List<Operacion> Operaciones { get; set; }
    }
}
