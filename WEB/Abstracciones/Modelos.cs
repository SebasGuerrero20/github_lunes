using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones
{
    public class Modelos
    {
        public Guid? IdModelo { get; set; }
        public string? Nombre { get; set; }
        public Guid? IdMarca { get; set; }
        public Marca? Marca { get; set; } // Relación con la clase Marca
    }
}
