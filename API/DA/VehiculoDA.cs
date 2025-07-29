using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class VehiculoDA : IVehiculoDA
    {
        private readonly IRepositorioDapper _repositorioDapper;
        private SqlConnection _conexionBase;
        public VehiculoDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _conexionBase = _repositorioDapper.ObtenerRepositorio();
        }
        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultado = await _conexionBase.QueryAsync<VehiculoResponse>(query);
            return resultado;
        }
        public async Task<VehiculoResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerVehiculo";
            var resultado = await _conexionBase.QueryAsync<VehiculoResponse>(query, new { Id = Id });
            return resultado.FirstOrDefault();
        }
        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            string query = @"AgregarVehiculo";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultado;
        }
        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            await verficarVehiculoExiste(Id);
            string query = @"EditarVehiculo";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id,
                IdModelo = vehiculo.IdModelo,
                Placa = vehiculo.Placa,
                Color = vehiculo.Color,
                Anio = vehiculo.Anio,
                Precio = vehiculo.Precio,
                CorreoPropietario = vehiculo.CorreoPropietario,
                TelefonoPropietario = vehiculo.TelefonoPropietario
            });
            return resultado;
        }
        public async Task<Guid> Eliminar(Guid Id)
        {
            await verficarVehiculoExiste(Id);
            string query = @"EliminarVehiculo";
            var resultado = await _conexionBase.ExecuteScalarAsync<Guid>(query, new { Id = Id });
            return resultado;
        }

        #region Helpers
        private async Task verficarVehiculoExiste(Guid Id)
        {
            VehiculoResponse? resultadoConsultaVehiculo = await Obtener(Id);
            if (resultadoConsultaVehiculo == null)
                throw new Exception("No se encontro el vehiculo");
        }
        #endregion
    }
}
