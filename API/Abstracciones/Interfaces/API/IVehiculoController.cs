using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Abstracciones.Interfaces.API
{
    public interface IVehiculoController
    {
        Task<IActionResult> Obtener();
        Task<IActionResult> Obtener(Guid Id);
        Task<IActionResult> Agregar(VehiculoRequest vehiculo);
        Task<IActionResult> Editar(Guid Id, VehiculoRequest vehiculo);
        Task<IActionResult> Eliminar(Guid Id);
    }
}
