namespace ProyectoBackend_Chiqui.Model
{
    public class PedidoDetalleModel
    {
        public int id_Detalle_Pedido { get; set; }
        public int id_Pedido { get; set; }
        public int id_Producto { get; set; }
        public int Cantidad_Pedido { get; set; }
        public double Precio_Unitario { get; set; }
        public double Sub_Total { get; set; }
        public string? Producto { get; set; }
    }
}
