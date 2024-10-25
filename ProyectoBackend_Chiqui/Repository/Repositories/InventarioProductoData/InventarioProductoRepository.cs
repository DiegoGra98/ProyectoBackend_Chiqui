using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.InventarioProductoData
{
    public class InventarioProductoRepository : IInventarioProductoRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public InventarioProductoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<InventarioProductoModel>> GetAllInventario()
        {
            var db = dbConnection();

            var sql = @"SELECT ip.*, cp.Descripcion AS Producto FROM InventarioProducto ip JOIN CatalogoProductos cp ON ip.id_Producto = cp.id_Producto";

            return await db.QueryAsync<InventarioProductoModel>(sql, new { });
        }

        public async Task<InventarioProductoModel> GetDetail(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT ip.*, cp.Descripcion AS Producto FROM InventarioProducto ip JOIN CatalogoProductos cp ON ip.id_Producto = cp.id_Producto WHERE ip.id_Producto = @Id";

            return await db.QueryFirstOrDefaultAsync<InventarioProductoModel>(sql, new { Id = id });
        }

        public async Task<bool> UpdateInventario(InventarioProductoModel inventario)
        {
            var db = dbConnection();

            var sql = @"UPDATE InventarioProducto 
            SET    
            Ultimo_Precio_Venta = @Ultimo_Precio_Venta
            WHERE id_Producto = @id_Producto";

            var result = await db.ExecuteAsync(sql, new { inventario.Ultimo_Precio_Venta, inventario.id_Producto });

            return result > 0;
        }
    }
}
