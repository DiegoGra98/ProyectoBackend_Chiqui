using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Model.Funciones
{
    public class GenerarCodigo
    {
        public string GenerarNumeroAleatorio()
        {
            Random random = new Random();
            int numero = random.Next(100000, 1000000); // Número aleatorio de 6 dígitos
            return numero.ToString();
        }
    }
}
