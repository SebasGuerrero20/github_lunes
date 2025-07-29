using Abstracciones.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.DA
{
    public interface IModelosDA
    {
        public Task<IEnumerable<Modelo>> ObtenerModelos(Guid IdMarca);

        public Task<Modelo> ObtenerModelo(Guid Id);

        public Task<Guid> CrearModelo(Modelo modelo);

        public Task<Guid> ActualizarModelo(Guid Id, Modelo modelo);

        public Task<Guid> EliminarModelo(Guid Id);
    }
}
