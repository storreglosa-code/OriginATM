using OriginATM.Dominio;

namespace OriginATM.Web.Servicios
{
    public interface ITarjetaServicio
    {
        Task<bool> ValidarPinAsync(string numeroTarjeta, string pinIngresado);
    }
}
