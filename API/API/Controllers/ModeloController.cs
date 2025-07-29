using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : Controller, IModelosController
    {

        private IModelosFlujo _modelosFlujo;

        public ModeloController(IModelosFlujo modelosFlujo)
        {
            _modelosFlujo = modelosFlujo;
        }

        [HttpPut("{IdModelo}")]
        public async Task<IActionResult> ActualizarModelo([FromRoute] Guid IdModelo, [FromBody] Modelo modelo)
        {
            if (!await verificacionExistencia(IdModelo))
            {
                return NotFound("No se encontró el modelo solicitado");
            }
            var resultado = await _modelosFlujo.ActualizarModelo(IdModelo, modelo);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CrearModelo(Modelo modelo)
        {
            if (modelo == null || string.IsNullOrEmpty(modelo.Nombre) || modelo.IdMarca == Guid.Empty)
            {
                return BadRequest("Datos invalidos");
            }

            var resultado = await _modelosFlujo.CrearModelo(modelo);
            return CreatedAtAction(nameof(ObtenerModelo), new { IdMarca = modelo.IdMarca, IdModelo = resultado }, modelo);
        }

        [HttpDelete("{IdModelo}")]
        public async Task<IActionResult> EliminarModelo([FromRoute] Guid IdModelo)
        {
            if (!await verificacionExistencia(IdModelo))
            {
                return NotFound("El modelo no existe");
            }
            var resultado = await _modelosFlujo.EliminarModelo(IdModelo);
            return NoContent();
        }

        [HttpGet("Modelo/{IdModelo}")]
        public async Task<IActionResult> ObtenerModelo([FromRoute] Guid IdModelo)
        {
            if (!await verificacionExistencia(IdModelo))
            {
                return NotFound("No se encontró el modelo solicitado");
            }
            var resultado = await _modelosFlujo.ObtenerModelo(IdModelo);
            return Ok(resultado);
        }

        [HttpGet("Marcas/{IdMarca}")]
        public async Task<IActionResult> ObtenerModelos([FromRoute] Guid IdMarca)
        {
            var resultado = await _modelosFlujo.ObtenerModelos(IdMarca);
            if (resultado == null || !resultado.Any())
            {
                return NotFound("No se encontraron modelos para la marca seleccionada");
            }
            return Ok(resultado);
        }

        #region Helpers


        private async Task<bool> verificacionExistencia(Guid IdModelo)
        {
            var existe = await _modelosFlujo.ObtenerModelo(IdModelo);

            return existe != null;
        }

        #endregion
    }
}
