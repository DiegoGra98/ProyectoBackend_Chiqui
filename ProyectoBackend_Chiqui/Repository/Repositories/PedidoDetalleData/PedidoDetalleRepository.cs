using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.PedidoDetalleData
{
    public class PedidoDetalleRepository : IPedidoDetalleRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public PedidoDetalleRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteDetalle(PedidoDetalleModel pedidoDetalle)
        {
            var db = dbConnection();

            var sql = @"CALL EliminarDetallePedido (@Id)";

            var result = await db.ExecuteAsync(sql, new { Id = pedidoDetalle.id_Detalle_Pedido });

            return result > 0;
        }

        public async Task<IEnumerable<PedidoDetalleModel>> GetDetails(int id_Pedido)
        {
            var db = dbConnection();

            var sql = @"SELECT pd.*, cp.Descripcion as Producto FROM PedidoDetalle pd JOIN CatalogoProductos cp ON pd.id_Producto = cp.id_Producto WHERE pd.id_Pedido = @Id";

            return await db.QueryAsync<PedidoDetalleModel>(sql, new { Id = id_Pedido });
        }

        public async Task<bool> InsertDetalle(PedidoDetalleModel pedidoDetalle)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarPedidoDetalle (@id_Pedido, @id_Producto, @Cantidad_Pedido, @Precio_Unitario)";

            var result = await db.ExecuteAsync(sql, new { pedidoDetalle.id_Pedido, pedidoDetalle.id_Producto, pedidoDetalle.Cantidad_Pedido, pedidoDetalle.Precio_Unitario });

            return result > 0;
        }

        public async Task<bool> UpdateDetalle(PedidoDetalleModel pedidoDetalle)
        {
            var db = dbConnection();

            var sql = @"CALL ActualizarDetallePedido (@id_Detalle_Pedido, @id_Producto, @Cantidad_Pedido, @Precio_Unitario)";

            var result = await db.ExecuteAsync(sql, new { pedidoDetalle.id_Detalle_Pedido, pedidoDetalle.id_Producto, pedidoDetalle.Cantidad_Pedido, pedidoDetalle.Precio_Unitario });

            return result > 0;
        }
    }
}
