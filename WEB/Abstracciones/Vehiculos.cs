using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones
{
    public class VehiculosBase
    {
        [Required(ErrorMessage = "La placa del vehiculo es necesaria para su registro")]
        [RegularExpression(@"[A-Z0-9]{3}-[0-9]{3}", ErrorMessage = "El formato de la placa debe ser ### o ABC-###")]
        [StringLength(7, ErrorMessage = "La placa debe tener 7 caracteres")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "El año de fabricacion es necesario para su registro")]
        [RegularExpression(@"(19|20)\d\d", ErrorMessage = "El formato para el año no es valido")]
        public int Anio { get; set; }
        [Required(ErrorMessage = "Es necesario el color del vehiculo para su registro")]
        [StringLength(30, ErrorMessage = "El color debe ser mayor a 4 caracteres y menor a 30 caracteres", MinimumLength = 4)]
        public string Color { get; set; }
        [Required(ErrorMessage = "Es necesario el precio de venta para su registro")]
        public Decimal Precio { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Es necesario el Correo del propietario para su registro")]
        public string CorreoPropietario { get; set; }
        [Phone]
        [Required(ErrorMessage = "Es necesario el Telefono del propietario para su registro")]
        public string TelefonoPropietario { get; set; }

    }
    public class Request : VehiculosBase
    {
        public Guid IdModelo { get; set; }
    }

    public class Response : VehiculosBase
    {
        public Guid IdVehiculo { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
