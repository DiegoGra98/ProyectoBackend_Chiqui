using Org.BouncyCastle.Asn1.Mozilla;

namespace ProyectoBackend_Chiqui.Model
{
    public class CatalogoProductosModel
    {
        public int id_Producto { get; set; }
        public int id_Categoria { get; set; }
        public string Descripcion { get; set; }
        public int id_Estado { get; set; }
    }
}
