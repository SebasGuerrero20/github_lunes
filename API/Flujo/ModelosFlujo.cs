using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace Flujo
{
    public class ModelosFlujo : IModelosFlujo
    {
        private IModelosDA _modelosDA;

        public ModelosFlujo(IModelosDA modelosDA)
        {
            _modelosDA = modelosDA;
        }

        public async Task<Guid> ActualizarModelo(Guid IdModelo, Modelo modelo)
        {
            return await _modelosDA.ActualizarModelo(IdModelo, modelo);
        }

        public async Task<Guid> CrearModelo(Modelo modelo)
        {
            return await _modelosDA.CrearModelo(modelo);
        }

        public async Task<Guid> EliminarModelo(Guid IdModelo)
        {
            return await _modelosDA.EliminarModelo(IdModelo);
        }

        public Task<Modelo> ObtenerModelo(Guid IdModelo)
        {
            var modelo = _modelosDA.ObtenerModelo(IdModelo);
            return modelo;
        }

        public async Task<IEnumerable<Modelo>> ObtenerModelos(Guid IdMarca)
        {
            return await _modelosDA.ObtenerModelos(IdMarca);
        }
    }
}

