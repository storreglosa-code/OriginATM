using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Dominio
{
    public class Tarjeta
    {
        public int Id { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 16)]
        [RegularExpression("^[0-9]{16}$")]
        public string Numero { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3)]
        [RegularExpression("^[0-9]{16}$")]
        public string Pin { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public bool EstaBloqueada { get; set; }
        [Required]
        public DateTime FechaVencimiento { get; set; }
        [Required]
        public ushort IntentosFallidos { get; set; }

        public List<Operacion> Operaciones { get; set; }
    }
}
