using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;
using System.Data;

namespace ProyectoBackend_Chiqui.Repository.Repositories.PedidoData
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public PedidoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeletePedido(PedidoModel pedido)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM c WHERE id_Pedido = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = pedido.id_Pedido });

            return result > 0;
        }

        public async Task<IEnumerable<PedidoModel>> GetAllPedidoAd()
        {
            var db = dbConnection();

            var sql = @"SELECT pe.*, u.Nombre AS Usuario, e.Descripcion AS Estado FROM PedidoEnca pe 
                JOIN Estado e ON pe.id_Estado = e.id_Estado
                JOIN Usuario u ON pe.id_Usuario = u.id_Usuario";

            return await db.QueryAsync<PedidoModel>(sql, new { });
        }

        public async Task<IEnumerable<PedidoModel>> GetAllPedidoUsr(int id_usuario)
        {
            var db = dbConnection();

            var sql = @"SELECT pe.*, u.Nombre AS Usuario, e.Descripcion AS Estado FROM PedidoEnca pe 
                JOIN Estado e ON pe.id_Estado = e.id_Estado
                JOIN Usuario u ON pe.id_Usuario = u.id_Usuario
                WHERE pe.id_Usuario = @Id";

            return await db.QueryAsync<PedidoModel>(sql, new { Id = id_usuario });
        }

        public async Task<PedidoModel> GetDetailsAd(int id_pedido)
        {
            var db = dbConnection();

            var sql = @"SELECT pe.*, u.Nombre AS Usuario, e.Descripcion AS Estado FROM PedidoEnca pe 
                JOIN Estado e ON pe.id_Estado = e.id_Estado
                JOIN Usuario u ON pe.id_Usuario = u.id_Usuario
                WHERE pe.id_Pedido = @Id";

            return await db.QueryFirstOrDefaultAsync<PedidoModel>(sql, new { Id = id_pedido });
        }

        public async Task<PedidoModel> GetDetailsUsr(int id_pedido, int id_usuario)
        {
            var db = dbConnection();

            var sql = @"SELECT pe.*, u.Nombre AS Usuario, e.Descripcion AS Estado FROM PedidoEnca pe 
                JOIN Estado e ON pe.id_Estado = e.id_Estado
                JOIN Usuario u ON pe.id_Usuario = u.id_Usuario
                WHERE pe.id_Pedido = @Id1 AND pe.id_Usuario = @Id2";

            return await db.QueryFirstOrDefaultAsync<PedidoModel>(sql, new { Id1 = id_pedido, Id2 = id_usuario });
        }

        public async Task<int> InsertPedido(PedidoModel pedido)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarPedidoEnca (NOW(), @id_Usuario, @id_Estado, @Fecha_Programada); SELECT LAST_INSERT_ID();";

            var id = await db.QuerySingleAsync<int>(sql, new { pedido.id_Usuario, pedido.id_Estado, pedido.Fecha_Programada });

            return id;
        }

        public async Task<bool> UpdatePedido(PedidoModel pedido)
        {
            var db = dbConnection();

            var sql = @"UPDATE InsertarPedidoEnca 
            SET    
            Fecha_Programada = @Fecha_Programada,
            id_Estado = @id_Estado
            WHERE id_Pedido = @id_Pedido";

            var result = await db.ExecuteAsync(sql, new { pedido.Fecha_Programada, pedido.id_Estado, pedido.id_Pedido });

            return result > 0;
        }
    }
}
