using OriginATM.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Repository.Interfaces
{
    public interface ITarjetaRepository
    {
        Task<Tarjeta> ObtenerPorNumeroAsync(string numero);
        Task ActualizarAsync(Tarjeta tarjeta);
    }
}
