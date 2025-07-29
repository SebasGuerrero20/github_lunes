using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class MarcasDA : IMarcasDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private SqlConnection _conexionBase;

        public MarcasDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _conexionBase = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> ActualizarMarca(Guid Id, Marcas marca)
        {
            string query = @"ActualizarMarca";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = marca.Nombre
            });
            return resultado;
        }

        public async Task<Guid> CrearMarca(Marcas marca)
        {
            string query = @"CrearMarca";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Nombre = marca.Nombre
            });
            return resultado;
        }

        public async Task<Guid> EliminarMarca(Guid Id)
        {
            string query = @"EliminarMarca";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new { Id = Id });
            return resultado;
        }

        public async Task<Marcas> ObtenerMarca(Guid Id)
        {
            string query = @"ObtenerMarca";
            var resultado = await _conexionBase.QueryAsync<Marcas>(query, new { Id = Id });
            return resultado.FirstOrDefault();
        }

        public async Task<IEnumerable<Marcas>> ObtenerMarcas()
        {
            string query = @"ObtenerMarcas";
            var resultado = await _conexionBase.QueryAsync<Marcas>(query);
            return resultado;
        }
    }
}
