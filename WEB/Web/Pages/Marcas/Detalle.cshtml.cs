using Abstracciones.Reglas;
using Abstracciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class DetalleModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public Marca marca { get; set; } = default!;

        public DetalleModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public async Task OnGet(Guid? IdMarca)
        {
            string endpont = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarca");
            var client = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpont, IdMarca));
            var respuesta = await client.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            marca = JsonSerializer.Deserialize<Marca>(resultado, opciones);
        }
    }
}
