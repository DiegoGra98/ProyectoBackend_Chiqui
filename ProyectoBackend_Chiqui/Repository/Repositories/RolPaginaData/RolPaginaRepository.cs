using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.RolPaginaData
{
    public class RolPaginaRepository : IRolPaginaRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public RolPaginaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteRolPagina(RolPaginaModel rolPagina)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Rol_Pagina WHERE idRol_Pagina = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = rolPagina.idRol_Pagina });

            return result > 0;
        }

        public async Task<IEnumerable<PaginaModel>> GetAllPagina()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Paginas";

            return await db.QueryAsync<PaginaModel>(sql, new { });
        }

        public async Task<IEnumerable<RolPagina2Model>> GetPaginaRol(int id_Rol)
        {
            var db = dbConnection();

            var sql = @"SELECT rp.*, p.Nombre, p.Icono, p.Url FROM Rol_Pagina rp JOIN Roles r on rp.id_Rol = r.id_Rol JOIN Paginas p on rp.id_Pagina = p.id_Pagina WHERE rp.id_Rol = @Id";

            return await db.QueryAsync<RolPagina2Model>(sql, new { Id = id_Rol });
        }

        public async Task<bool> InsertRolPagina(RolPaginaModel rolPagina)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarRolPagina (@id_Rol,@id_Pagina)";

            var result = await db.ExecuteAsync(sql, new { rolPagina.id_Rol, rolPagina.id_Pagina });

            return result > 0;
        }

        public async Task<bool> UpdateRolPagina(RolPaginaModel rolPagina)
        {
            var db = dbConnection();

            var sql = @"UPDATE Rol_Pagina 
            SET    
            id_Rol = @id_Rol,
            id_Pagina = @id_Pagina
            WHERE idRol_Pagina = @idRol_Pagina";

            var result = await db.ExecuteAsync(sql, new { rolPagina.id_Rol, rolPagina.id_Pagina, rolPagina.idRol_Pagina });

            return result > 0;
        }
    }
}
