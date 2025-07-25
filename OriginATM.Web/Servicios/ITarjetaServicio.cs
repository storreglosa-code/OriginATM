using OriginATM.Dominio;

namespace OriginATM.Web.Servicios
{
    public interface ITarjetaServicio
    {
        Task<Tarjeta?> ObtenerSiExisteYNoEstaBloqueadaAsync(string numeroTarjeta);
        Task<bool> ValidarPinAsync(string numeroTarjeta, string pinIngresado);
    }
}
