using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.EstadoData
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public EstadoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteEstado(EstadoModel estado)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Estado WHERE id_Estado = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = estado.id_Estado });

            return result > 0;
        }

        public async Task<IEnumerable<EstadoModel>> GetAllEstado()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Estado";

            return await db.QueryAsync<EstadoModel>(sql, new { });
        }

        public async Task<EstadoModel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Estado WHERE id_Estado = @Id";

            return await db.QueryFirstOrDefaultAsync<EstadoModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertEstado(EstadoModel estado)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarEstado (@Descripcion)";

            var result = await db.ExecuteAsync(sql, new { estado.Descripcion });

            return result > 0;
        }

        public async Task<bool> UpdateEstado(EstadoModel estado)
        {
            var db = dbConnection();

            var sql = @"UPDATE Estado 
            SET    
            Descripcion = @Descripcion
            WHERE id_Estado = @id_Estado";

            var result = await db.ExecuteAsync(sql, new { estado.Descripcion, estado.id_Estado });

            return result > 0;
        }
    }
}
