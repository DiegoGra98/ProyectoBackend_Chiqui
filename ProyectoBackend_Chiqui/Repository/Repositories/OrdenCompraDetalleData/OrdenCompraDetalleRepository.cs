using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.OrdenCompraDetalleData
{
    public class OrdenCompraDetalleRepository : IOrdenCompraDetalleRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public OrdenCompraDetalleRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteDetalle(OrdenCompraDetalleModel ordenDetalle)
        {
            var db = dbConnection();

            var sql = @"CALL EliminarDetalle (@Id)";

            var result = await db.ExecuteAsync(sql, new { Id = ordenDetalle.id_Orden_deta });

            return result > 0;
        }

        public async Task<IEnumerable<OrdenCompraDetalleModel>> GetDetalle(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM OrdenCompraDetalle WHERE id_Orden_Enca = @Id";

            return await db.QueryAsync<OrdenCompraDetalleModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertDetalle(OrdenCompraDetalleModel ordenDetalle)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarOrdenCompraDetalle (@id_Orden_Enca, @id_Producto, @Cantidad, @Precio_Unitario, @Observacion)";

            var result = await db.ExecuteAsync(sql, new { ordenDetalle.id_Orden_Enca, ordenDetalle.id_Producto, ordenDetalle.Cantidad, ordenDetalle.Precio_Unitario, ordenDetalle.Observacion });

            return result > 0;
        }

        public async Task<bool> UpdateDetalle(OrdenCompraDetalleModel ordenDetalle)
        {
            var db = dbConnection();

            var sql = @"UPDATE OrdenCompraDetalle 
            SET    
            id_Producto = @id_Producto
            Cantidad = @Cantidad,
            Precio_Unitario = @Precio_Unitario,
            Observacion = @Observacion
            WHERE id_Orden_deta = @id_Orden_deta";

            var result = await db.ExecuteAsync(sql, new { ordenDetalle.id_Producto, ordenDetalle.Cantidad, ordenDetalle.Precio_Unitario, ordenDetalle.Observacion, ordenDetalle.id_Orden_deta });

            return result > 0;
        }
    }
}
