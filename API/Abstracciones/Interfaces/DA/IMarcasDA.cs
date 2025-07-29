using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IMarcasDA
    {
        Task<IEnumerable<Marcas>> ObtenerMarcas();
        Task<Marcas> ObtenerMarca(Guid Id);
        Task<Guid> CrearMarca(Marcas marca);
        Task<Guid> ActualizarMarca(Guid Id, Marcas marca);
        Task<Guid> EliminarMarca(Guid Id);
    }
}
