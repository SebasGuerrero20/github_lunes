using Abstracciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.ModeloPages
{
    public class BorrarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public BorrarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        public Modelos modelos { get; set; } = default!;

        public async Task<IActionResult> OnGet(Guid IdModelo)
        {
            if (IdModelo == Guid.Empty)
            {
                return NotFound();
            }
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerModeloPorId");
            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync($"{endpoint}/{id}");
            if (respuesta.IsSuccessStatusCode)
            {
                modelos = await respuesta.Content.ReadFromJsonAsync<Modelos>();
                return Page();
            }
            else
            {
                return RedirectToPage("./IndexModelos");
            }
        }
    }
}
