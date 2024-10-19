using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.UsuarioData
{
    public class UsuarioRepository : IUsuarioRepository

    {
        private readonly MySQLConfiguration _connectionString;

        public UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteUsuario(UsuarioModel usuario)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Usuario WHERE id_Usuario = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = usuario.id_Usuario});

            return result > 0;
        }

        public  async Task<IEnumerable<UsuarioModel>> GetAllUsuario()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Usuario";

            return await db.QueryAsync<UsuarioModel>(sql, new { });
        }

        public async Task<UsuarioModel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Usuario WHERE id_Usuario = @Id";

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(sql, new {Id = id });
        }

        public async Task<bool> InsertUsuario(UsuarioModel usuario)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarUsuario (@Nombre,@Direccion,@Telefono,@Correo,@Contraseña,NOW(),@id_Rol)";

            var result = await db.ExecuteAsync(sql, new { usuario.Nombre, usuario.Direccion, usuario.Telefono, usuario.Correo, usuario.Contraseña, usuario.id_Rol });

            return result > 0;
        }

        public async Task<bool> UpdateUsuario(UsuarioModel usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE Usuario 
            SET    
            Nombre = @Nombre,
            Direccion = @Direccion,
            Telefono = @Telefono,
            Correo = @Correo,
            Contraseña = @Contraseña,
            Fecha_Registro = NOW(),
            id_Rol = @id_Rol
            WHERE id_Usuario = @id_Usuario";

            var result = await db.ExecuteAsync(sql, new { usuario.Nombre, usuario.Direccion, usuario.Telefono, usuario.Correo, usuario.Contraseña, usuario.id_Rol, usuario.id_Usuario });

            return result > 0;
        }
    }
}
