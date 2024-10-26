namespace ProyectoBackend_Chiqui.Model
{
    public class PedidoModel
    {
        public int id_Pedido { get; set; }
        public string? Fecha_Pedido { get; set; }
        public int id_Usuario { get; set; }
        public int id_Estado { get; set; }
        public string? Fecha_Programada { get; set; }
        public double Total_Pedido { get; set; }
        public string? Usuario { get; set; }
        public string? Estado { get; set; }
    }
}
