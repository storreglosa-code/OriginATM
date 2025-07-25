using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace OriginATM.Web.Models
{
    public class OperacionesViewModel
    {
        public int TarjetaId { get; set; }
        public DateTime FechaOperacion { get; set; }
        public int CodigoOperacion { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimientoTarjeta { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal Balance { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")] 
        public decimal? MontoRetirado { get; set; }
        public string BalanceFormateado => string.Format(new CultureInfo("es-AR"), "{0:N2}", Balance);
        public string MontoRetiradoFormateado => string.Format(new CultureInfo("es-AR"), "{0:N2}", Balance);


        public string NumeroTarjetaFormateado => string.IsNullOrWhiteSpace(NumeroTarjeta) ? 
            "" : string.Join("-", Enumerable.Range(0, 4)
            .Select(i => NumeroTarjeta.Substring(i * 4, 4)));
    }
}
