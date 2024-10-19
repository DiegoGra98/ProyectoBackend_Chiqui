using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Model
{
    public class UsuarioModel
    {
        public int id_Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public string? Fecha_Registro { get; set; }
        public string? codigo_temp {  get; set; }
        public int id_Rol { get; set; }

    }
}
