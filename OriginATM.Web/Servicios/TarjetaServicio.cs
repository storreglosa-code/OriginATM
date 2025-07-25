using OriginATM.Dominio;
using OriginATM.Repository.Interfaces;

namespace OriginATM.Web.Servicios
{
    public class TarjetaServicio : ITarjetaServicio

    {
        private readonly ITarjetaRepository _tarjetaRepository;

        public TarjetaServicio(ITarjetaRepository tarjetaRepository)
        {
            _tarjetaRepository = tarjetaRepository;
        }

        public async Task<bool> ValidarPinAsync(string numeroTarjeta, string pinIngresado)
        {
            var tarjeta = await _tarjetaRepository.ObtenerPorNumeroAsync(numeroTarjeta);
            if (tarjeta == null || tarjeta.EstaBloqueada)
                return false;

            return tarjeta.Pin == pinIngresado;
        }

    }
}
