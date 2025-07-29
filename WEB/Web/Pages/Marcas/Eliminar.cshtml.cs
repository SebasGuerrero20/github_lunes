using Abstracciones.Reglas;
using Abstracciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class EliminarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EliminarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public Marca marca { get; set; } = default!;

        public async Task<ActionResult> OnGet(Guid? IdMarca)
        {
            if (IdMarca == Guid.Empty)
            {
                return NotFound();
            }
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarca");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Get, string.Format(endpoint, IdMarca));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();

            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            marca = JsonSerializer.Deserialize<Marca>(resultado, opciones);
            return Page();
        }

        public async Task<ActionResult> OnPost(Guid? IdMarca)
        {
            if (IdMarca == Guid.Empty)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "EliminarMarca");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Delete, string.Format(endpoint, IdMarca));
            var respuesta = await cliente.SendAsync(solicitud);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./IndexMarcas");
        }
    }
}
