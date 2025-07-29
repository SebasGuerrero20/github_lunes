using Abstracciones;
using Abstracciones.Reglas;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerMetodo(string seccion, string nombre)
        {
            var config = _configuration.GetSection(seccion).Get<ApiEndPoints>();

            if (config == null || config.Metodos == null)
            {
                throw new Exception($"No se encontro la configuracion para la seccion '{seccion}'");
            }

            var metodo = config.Metodos.FirstOrDefault(m => m.Nombre == nombre);
            if (metodo == null)
            {
                throw new Exception($"No se encontro el metodo '{nombre}' en la seccion '{seccion}'");
            }

            string UrlBase = config.UrlBase?.TrimEnd('/') ?? "";
            string valor = metodo.Valor?.TrimStart('/') ?? "";


            return $"{UrlBase}/{valor}";
        }

        private string ObtenerUrlBase(string seccion)
        {
            return _configuration.GetSection(seccion).Get<ApiEndPoints>().UrlBase;
        }

        public string ObtenerValor(string llave)
        {
            return _configuration.GetSection(llave).Value; ;
        }
    }
}
