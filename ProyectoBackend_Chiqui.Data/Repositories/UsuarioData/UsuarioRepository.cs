using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using ProyectoBackend_Chiqui.Data.Repositories.EmailData;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Model.Funciones;
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
        private readonly IEmailRepository _emailRepository;

        public UsuarioRepository(MySQLConfiguration connectionString, IEmailRepository emailRepository)
        {
            _connectionString = connectionString;
            _emailRepository = emailRepository;
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

        public async Task<bool> RecContraseña(UsuarioModel usuario)
        {
            var db = dbConnection();

            // Primera consulta para buscar el usuario
            var sqlUsuario = @"SELECT Correo FROM Usuario WHERE Correo = @correo";
            var consulta = await db.QueryFirstOrDefaultAsync<UsuarioModel>(sqlUsuario, new { correo = usuario.Correo });

            // Verifica si no se encontró al usuario
            if (consulta == null)
            {
                return false;
            }

            // generación de token
            GenerarCodigo generador = new GenerarCodigo();
            string codigo = generador.GenerarNumeroAleatorio();
            // Si se encuentra el usuario, ejecuta otro query (puedes personalizar el SQL según la lógica)
            var sqlActualizarToken = @"UPDATE Usuario SET codigo_temp = @codigo_temp WHERE Correo = @correo";
             

            // Ejecutar el segundo query para actualizar el token de recuperación
            var filasAfectadas = await db.ExecuteAsync(sqlActualizarToken, new { codigo_temp = codigo, correo = usuario.Correo });
            _emailRepository.RecContraseña(usuario.Correo, codigo);

            return filasAfectadas > 0;
        }

        public async Task<bool> CambiarContraseña(UsuarioModel usuario)
        {
            var db = dbConnection();

            var sql = @"UPDATE Usuario 
            SET    
            Contraseña = @Contraseña
            WHERE Correo = @Correo and codigo_temp = @codigo_temp";

            var result = await db.ExecuteAsync(sql, new { usuario.Contraseña, usuario.Correo, usuario.codigo_temp });

            return result > 0;
        }
    }
}
