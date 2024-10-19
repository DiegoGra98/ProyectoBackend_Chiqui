using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.LoginData
{
    public class LoginRepository : ILoginRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public LoginRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<UsuarioModel> GetLogin(LoginModel login)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Usuario WHERE Correo = @Correo AND Contraseña = @Contraseña";

            return await db.QueryFirstOrDefaultAsync<UsuarioModel>(sql, new { login.Correo, login.Contraseña});
        }
    }
}
