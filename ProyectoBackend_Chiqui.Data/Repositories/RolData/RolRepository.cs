using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.RolData
{
    public class RolRepository : IRolRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public RolRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteRol(RolModel rol)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Rol WHERE id_Rol = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = rol.id_Rol });

            return result > 0;
        }

        public async Task<IEnumerable<RolModel>> GetAllRol()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Rol";

            return await db.QueryAsync<RolModel>(sql, new { });
        }

        public async Task<RolModel> GetRol(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Rol WHERE id_Rol = @Id";

            return await db.QueryFirstOrDefaultAsync<RolModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertRol(RolModel rol)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarRol (@Descripcion)";

            var result = await db.ExecuteAsync(sql, new { rol.Descripcion });

            return result > 0;
        }

        public async Task<bool> UpdateRol(RolModel rol)
        {
            var db = dbConnection();

            var sql = @"UPDATE Rol 
            SET    
            Nombre = @Descripcion,
            WHERE id_Rol = @id_Rol";

            var result = await db.ExecuteAsync(sql, new { rol.Descripcion, rol.id_Rol });

            return result > 0;
        }
    }
}
