using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Model
{
    public class ProveedorModel
    {
        public int id_Proveedor { get; set; }
        public string Nombre_Proveedor { get; set; }
        public string Nombre_Contacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
