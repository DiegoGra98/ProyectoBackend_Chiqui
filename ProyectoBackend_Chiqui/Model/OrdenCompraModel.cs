using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Model
{
    public class OrdenCompraModel
    {
        public int id_Orden_Enca { get; set; }
        public string? Fecha_Orden { get; set; }
        public int id_Proveedor { get; set; }
        public int Numero_Orden { get; set; }
        public int id_Estado { get; set; }
        public string? Observacion { get; set; }
    }
}
