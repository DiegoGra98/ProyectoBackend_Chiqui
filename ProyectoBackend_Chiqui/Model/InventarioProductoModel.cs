namespace ProyectoBackend_Chiqui.Model
{
    public class InventarioProductoModel
    {
        public int id_Producto { get; set; }
        public int Existencia { get; set; }
        public double Ultimo_Precio_Compra {  get; set; }
        public double Ultimo_Precio_Venta {  get; set; }
        public string? Fecha_Ultima_Compra { get; set; }
        public string? Fecha_Ultima_Venta { get; set; }
        public string? Observaciones { get; set; }
        public string? Producto { get; set; }
    }
}
