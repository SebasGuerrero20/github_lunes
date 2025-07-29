using Microsoft.AspNetCore.Mvc;
using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : Controller, IMarcasController
    {

        private IMarcasFlujo _marcasFlujo;
        private ILogger<MarcasController> _logger;

        public MarcasController(IMarcasFlujo marcasFlujo, ILogger<MarcasController> logger)
        {
            _marcasFlujo = marcasFlujo;
            _logger = logger;
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> ActualizarMarca([FromRoute] Guid Id,[FromBody] Marcas marca)
        {
            if (!await verificacionExistencia(Id))
            {
                return NotFound("Dicha marca no se encuentra en nuestra base de datos");
            }
            var resultado = await _marcasFlujo.ActualizarMarca(Id, marca);
            return Ok(resultado);
        }
        [HttpPost]
        public async Task<IActionResult> CrearMarca([FromBody]Marcas marca)
        {
            var resultado = await _marcasFlujo.CrearMarca(marca);
            return CreatedAtAction(nameof(ObtenerMarca), new { IdMarca = resultado }, null);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarMarca([FromRoute]Guid Id)
        {
            if(!await verificacionExistencia(Id))
            {
                return NotFound("Dicha marca no se encuentra en nuestra base de datos");
            }
            var resultado = await _marcasFlujo.EliminarMarca(Id);
            return NoContent();
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ObtenerMarca([FromRoute]Guid Id)
        {
            var resultado = await _marcasFlujo.ObtenerMarca(Id);
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerMarcas()
        {
            var resultado = await _marcasFlujo.ObtenerMarcas();
            if (!resultado.Any())
            {
                return NoContent();
            }
            return Ok(resultado);
        }

        private async Task<bool> verificacionExistencia(Guid Id)
        {
            var existe = await _marcasFlujo.ObtenerMarca(Id);

            return existe != null;
        }
    }
}
