using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Data.Repositories.OrdenCompraData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.OrdenCompraData
{
    public class OrdenCompraRepository : IOrdenCompraRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public OrdenCompraRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteOrden(OrdenCompraModel OrdenCompra)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM OrdenCompraEnca WHERE id_Orden_Enca = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = OrdenCompra.id_Orden_Enca });

            return result > 0;
        }

        public async Task<IEnumerable<OrdenCompraModel>> GetAllOrden()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM OrdenCompraEnca";

            return await db.QueryAsync<OrdenCompraModel>(sql, new { });
        }

        public async Task<OrdenCompraModel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM OrdenCompraEnca WHERE id_Orden_Enca = @Id";

            return await db.QueryFirstOrDefaultAsync<OrdenCompraModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertOrden(OrdenCompraModel OrdenCompra)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarOrdenCompraEnca (NOW(),@id_Proveedor, @Numero_Orden, @id_Estado, @Observacion)";

            var result = await db.ExecuteAsync(sql, new { OrdenCompra.id_Proveedor, OrdenCompra.Numero_Orden, OrdenCompra.id_Estado, OrdenCompra.Observacion });

            return result > 0;
        }

        public async Task<bool> UpdateOrden(OrdenCompraModel OrdenCompra)
        {
            var db = dbConnection();

            var sql = @"UPDATE OrdenCompraEnca 
            SET    
            Fecha_Orden = NOW(),
            id_Proveedor = @id_Proveedor,
            Numero_Orden = @Numero_Orden,
            id_Estado = @id_Estado,
            Observacion = @Observacion
            WHERE id_Orden_Enca = @id_Orden_Enca";

            var result = await db.ExecuteAsync(sql, new { OrdenCompra.id_Proveedor, OrdenCompra.Numero_Orden, OrdenCompra.id_Estado, OrdenCompra.Observacion, OrdenCompra.id_Orden_Enca });

            return result > 0;
        }
    }
}
