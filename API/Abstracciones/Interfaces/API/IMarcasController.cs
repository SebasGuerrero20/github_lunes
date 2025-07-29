using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;

namespace Abstracciones.Interfaces.API
{
    public interface IMarcasController
    {
        Task<IActionResult> ObtenerMarcas();
        Task<IActionResult> ObtenerMarca(Guid Id);
        Task<IActionResult> CrearMarca(Marcas marca);
        Task<IActionResult> ActualizarMarca(Guid Id, Marcas marca);
        Task<IActionResult> EliminarMarca(Guid Id);
    }
}
