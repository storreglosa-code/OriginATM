using OriginATM.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Repositorio.Interfaces
{
    public interface ITarjetaRepository
    {
        //bool esValida(string numeroTarjeta);
        //bool pinValido (string numeroPIN);

        Task<Tarjeta> ObtenerPorNumeroAsync(string numero);
        Task<bool> ValidarPINAsync(string numeroTarjeta, string pin);
    }
}
