using OriginATM.Repository.Interfaces;
using OriginATM.Dominio;
using OriginATM.Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OriginATM.Repository.Implementacion
{
    public class TarjetaRepository : ITarjetaRepository
    {
        private readonly ApplicationDbContext _context;
        public TarjetaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tarjeta> ObtenerPorNumeroAsync(string numeroTarjeta)
        {
            return await _context.Tarjetas.FirstOrDefaultAsync(t => t.Numero == numeroTarjeta);
        }

        public async Task ActualizarAsync(Tarjeta tarjeta)
        {
            _context.Tarjetas.Update(tarjeta);
            await _context.SaveChangesAsync();
        }


    }

}
