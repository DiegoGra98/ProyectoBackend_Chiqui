using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.CatalogoProductosData
{
    public class CatalogoProductosRepository : ICatalogoProductosRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public CatalogoProductosRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteProducto(CatalogoProductosModel catalogoProducto)
        {
            var db = dbConnection();

            var sql2 = @"DELETE FROM ImagenesProductos WHERE id_Producto = @Id";

            await db.ExecuteAsync(sql2, new { Id = catalogoProducto.id_Producto });

            var sql1 = @"DELETE FROM CatalogoProductos WHERE id_Producto = @Id";

            var result = await db.ExecuteAsync(sql1, new { Id = catalogoProducto.id_Producto });

            return result > 0;
        }

        public async Task<IEnumerable<CatalogoProductosModel>> GetAllProducto()
        {
            var db = dbConnection();

            var sql = @"SELECT cp.*, im.foto FROM CatalogoProductos cp JOIN ImagenesProductos im on cp.id_Producto = im.id_producto";

            return await db.QueryAsync<CatalogoProductosModel>(sql, new { });
        }

        public async Task<CatalogoProductosModel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT cp.*, im.foto FROM CatalogoProductos cp JOIN ImagenesProductos im on cp.id_Producto = im.id_producto WHERE cp.id_Producto = @Id";

            return await db.QueryFirstOrDefaultAsync<CatalogoProductosModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertProducto(CatalogoProductosModel catalogoProducto)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarProducto (@id_Categoria,@Descripcion,@id_Estado, @foto)";

            var result = await db.ExecuteAsync(sql, new { catalogoProducto.id_Categoria, catalogoProducto.Descripcion, catalogoProducto.id_Estado, catalogoProducto.foto });

            return result > 0;
        }

        public async Task<bool> UpdateProducto(CatalogoProductosModel catalogoProducto)
        {
            var db = dbConnection();

            var sql = @"CALL ActualizarProducto (@id_Categoria,@Descripcion,@id_Estado, @foto, @id_Producto)";

            var result = await db.ExecuteAsync(sql, new { catalogoProducto.id_Categoria, catalogoProducto.Descripcion, catalogoProducto.id_Estado, catalogoProducto.foto ,catalogoProducto.id_Producto });

            return result > 0;
        }
    }
}
