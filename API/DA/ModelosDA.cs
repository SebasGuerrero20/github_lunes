using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class ModelosDA : IModelosDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private SqlConnection _conexionBase;

        public ModelosDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _conexionBase = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<Guid> ActualizarModelo(Guid Id, Modelo modelo)
        {
            string query = "EditarModelos";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                Nombre = modelo.Nombre
            });
            return resultado;
        }

        public async Task<Guid> CrearModelo(Modelo modelo)
        {
            string query = "AgregarModelos";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Nombre = modelo.Nombre,
                IdMarca = modelo.IdMarca
            });
            return resultado;
        }

        public async Task<Guid> EliminarModelo(Guid Id)
        {
            string query = "BorrarModelo";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            });
            return resultado;
        }

        public async Task<Modelo> ObtenerModelo(Guid Id)
        {
            string query = "ObtenerModelo";
            var resultado = await _conexionBase.QueryAsync<Modelo>(query, new
            {
                Id = Id
            });
            return resultado.FirstOrDefault();
        }

        public async Task<IEnumerable<Modelo>> ObtenerModelos(Guid IdMarca)
        {
            string query = "ObtenerModelos";
            var resultado = await _conexionBase.QueryAsync<Modelo>(query, new { IdMarca });
            return resultado;
        }
    }
}
