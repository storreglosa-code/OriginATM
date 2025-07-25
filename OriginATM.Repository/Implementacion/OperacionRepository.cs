using Microsoft.EntityFrameworkCore;
using OriginATM.Dominio;
using OriginATM.Infraestructura;
using OriginATM.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Repository.Implementacion
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly ApplicationDbContext _context;
        public OperacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task RegistrarAsync(Operacion operacion)
        {
            await _context.Operaciones.AddAsync(operacion);
            await _context.SaveChangesAsync();
        }
    }
}
