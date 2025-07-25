namespace OriginATM.Web.Models
{
    public class BalanceViewModel
    {
        public int TarjetaId { get; set; }
        public DateTime FechaOperacion { get; set; }
        public int CodigoOperacion { get; set; }
        public string NumeroTarjeta { get; set; }
        public DateTime FechaVencimientoTarjeta { get; set; }
        public decimal Balance { get; set; }
    }
}
