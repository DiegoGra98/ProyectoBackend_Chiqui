using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.CategoriaData
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public CategoriaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<CategoriaModel>> GetAllCategoria()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM CategoriaProductos";

            return await db.QueryAsync<CategoriaModel>(sql, new { });
        }

        public async Task<CategoriaModel> GetCategoria(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM CategoriaProductos WHERE id_Categoria = @Id";

            return await db.QueryFirstOrDefaultAsync<CategoriaModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertCategoria(CategoriaModel categoria)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarCategoriaProducto (@Descripcion,@id_Estado)";

            var result = await db.ExecuteAsync(sql, new {categoria.Descripcion,categoria.id_Estado });

            return result > 0;
        }

        public async Task<bool> UpdateCategoria(CategoriaModel categoria)
        {
            var db = dbConnection();

            var sql = @"UPDATE CategoriaProductos 
            SET    
            Descripcion = @Descripcion,
            id_Estado = @id_Estado
            WHERE id_Categoria = @id_Categoria";

            var result = await db.ExecuteAsync(sql, new { categoria.Descripcion, categoria.id_Estado, categoria.id_Categoria });

            return result > 0;
        }
    }
}
