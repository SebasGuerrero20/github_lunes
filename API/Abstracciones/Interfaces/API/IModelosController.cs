using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.API
{
    public interface IModelosController
    {
        Task<IActionResult> ObtenerModelos(Guid IdMarca);

        Task<IActionResult> CrearModelo(Modelo modelo);

        Task<IActionResult> ObtenerModelo(Guid Id);

        Task<IActionResult> ActualizarModelo(Guid Id, Modelo modelo);

        Task<IActionResult> EliminarModelo(Guid Id);


    }
}
