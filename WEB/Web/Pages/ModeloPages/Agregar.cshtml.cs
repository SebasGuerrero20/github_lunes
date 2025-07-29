using Abstracciones.Reglas;
using Abstracciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.ModeloPages
{
    public class AgregarModel : PageModel
    {
        private readonly IConfiguracion _configuracion;

        public AgregarModel(IConfiguracion configuracion)
        {
            _configuracion = configuracion;
        }

        [BindProperty]
        public Modelos Modelo { get; set; }
        [BindProperty]
        public List<SelectListItem> Marcas { get; set; }
        [BindProperty]
        public Guid? IdMarca { get; set; }

        public async Task<IActionResult> OnGet()
        {
            await CargarMarcas();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "AgregarModelo");
            var cliente = new HttpClient();
            var solicitud = new HttpRequestMessage(HttpMethod.Post, endpoint);
            var respuesta = await cliente.PostAsJsonAsync(endpoint, Modelo);
            respuesta.EnsureSuccessStatusCode();
            return RedirectToPage("./IndexModelos");
        }

        private async Task CargarMarcas()
        {
            string endpoint = _configuracion.ObtenerMetodo("ApiEndPoints", "ObtenerMarcas");
            var cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(endpoint);
            if (respuesta.IsSuccessStatusCode)
            {
                var marcas = await respuesta.Content.ReadFromJsonAsync<List<Marca>>();
                Marcas = marcas.Select(m => new SelectListItem
                {
                    Value = m.IdMarca.ToString(),
                    Text = m.Nombre
                }).ToList();
            }
            else
            {
                Marcas = new List<SelectListItem>();
            }


        }
    }
}
