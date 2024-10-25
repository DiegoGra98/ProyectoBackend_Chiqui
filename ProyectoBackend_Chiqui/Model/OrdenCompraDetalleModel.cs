namespace ProyectoBackend_Chiqui.Model
{
    public class OrdenCompraDetalleModel
    {
        public int id_Orden_deta {  get; set; }
        public int id_Orden_Enca {  get; set; }
        public int id_Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio_Unitario { get; set; }
        public string Observacion { get; set; }
    }
}
