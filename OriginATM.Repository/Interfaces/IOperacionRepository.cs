using OriginATM.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OriginATM.Repository.Interfaces
{
    public interface IOperacionRepository
    {
        Task RegistrarAsync(Operacion operacion);
    }
}
