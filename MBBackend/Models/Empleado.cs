using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MBBackend.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required, StringLength(16), MinLength(16)]
        public string Cedula { get; set; }
        [Required, StringLength(15)]
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        [Required, StringLength(15)]
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        [Required, StringLength(8), MinLength(8)]
        public string Celular { get; set; }
        [Required, StringLength(60)]
        public string Direccion { get; set; }
        [Required, StringLength(16), MinLength(6)]
        public string Usuario { get; set; }
        [Required, StringLength(16), MinLength(6)]
        public string Password { get; set; }

        public string Error { get; set; }
    }
}
