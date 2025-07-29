using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class MarcasFlujo : IMarcasFlujo
    {

        private IMarcasDA _marcasDA;

        public MarcasFlujo(IMarcasDA marcasDA)
        {
            _marcasDA = marcasDA;
        }

        public async Task<Guid> ActualizarMarca(Guid Id, Marcas marca)
        {
            return await _marcasDA.ActualizarMarca(Id, marca);
        }

        public async Task<Guid> CrearMarca(Marcas marca)
        {
            return await _marcasDA.CrearMarca(marca);
        }

        public async Task<Guid> EliminarMarca(Guid Id)
        {
            return await _marcasDA.EliminarMarca(Id);
        }

        public async Task<Marcas> ObtenerMarca(Guid Id)
        {
            var marca = await _marcasDA.ObtenerMarca(Id);
            return marca;
        }

        public async Task<IEnumerable<Marcas>> ObtenerMarcas()
        {
            return await _marcasDA.ObtenerMarcas();
        }
    }
}
