using Abstracciones.Reglas;
using Abstracciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace Web.Pages.Marcas
{
    public class EditarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public EditarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public Marca marca { get; set; }


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
            if (respuesta.StatusCode == HttpStatusCode.OK)
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                marca = JsonSerializer.Deserialize<Marca>(resultado, opciones);

            }
            return Page();
        }

        public async Task<ActionResult> OnPut()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string endpoint = _configuracion.ObtenerMetodo("APIEndPoints", "EditarMarca");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Put, endpoint);
            var respuesta = await cliente.PostAsJsonAsync<Marca>(string.Format(endpoint, marca.IdMarca), new Marca
            {
                Nombre = marca.Nombre
            });
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./IndexMarcas");
        }
    }
}
