using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using System.Runtime.InteropServices.ComTypes;
>>>>>>> 3a95726 (gv Proveedores y Formulario Proveedores)
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
