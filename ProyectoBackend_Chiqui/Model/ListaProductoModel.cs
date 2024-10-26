namespace ProyectoBackend_Chiqui.Model
{
    public class ListaProductoModel
    {
        public int id_Producto { get; set; }
        public string Producto { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; }
        public double Precio_Venta {  get; set; }
        public int Existencia { get; set; }
        public string foto { get; set; }
    }
}
