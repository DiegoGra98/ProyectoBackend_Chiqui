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

            var sql = @"DELETE FROM Cliente WHERE id_Cliente = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = usuario.id_Cliente});

            return result > 0;
        }

        public  async Task<IEnumerable<UsuarioModel>> GetAllUsuario()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Cliente";

            return await db.QueryAsync<UsuarioModel>(sql, new { });
        }

        public async Task<UsuarioModel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Cliente WHERE id_Cliente = @Id";

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(sql, new {Id = id });
        }

        public async Task<bool> InsertUsuario(UsuarioModel usuario)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarCliente (@Nombre,@Direccion,@Telefono,@Correo,@Contraseña,NOW(),@id_Rol)";

            var result = await db.ExecuteAsync(sql, new { usuario.Nombre, usuario.Direccion, usuario.Telefono, usuario.Correo, usuario.Contraseña, usuario.id_Rol });

            return result > 0;
        }

        public async Task<bool> UpdateUsuario(UsuarioModel usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE Cliente 
            SET    
            Nombre = @Nombre,
            Direccion = @Direccion,
            Telefono = @Telefono,
            Correo = @Correo,
            Contraseña = @Contraseña,
            Fecha_Registro = @Fecha_Registro,
            id_Rol = @id_Rol
            WHERE id_Cliente = @id_Cliente";

            var result = await db.ExecuteAsync(sql, new { usuario.Nombre, usuario.Direccion, usuario.Telefono, usuario.Correo, usuario.Contraseña, usuario.Fecha_Registro, usuario.id_Rol, usuario.id_Cliente });

            return result > 0;
        }
    }
}
