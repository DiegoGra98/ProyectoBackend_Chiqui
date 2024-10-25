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

        public async Task<IEnumerable<CatalogoProductos2Model>> GetAllProducto()
        {
            var db = dbConnection();

            var sql = 
                @"SELECT cp.*, e.Descripcion as Estado, ca.Descripcion as Categoria, im.foto FROM CatalogoProductos cp 
                JOIN ImagenesProductos im on cp.id_Producto = im.id_producto 
                JOIN Estado e ON cp.id_Estado = e.id_Estado
                JOIN CategoriaProductos ca ON cp.id_Categoria = ca.id_Categoria";

            return await db.QueryAsync<CatalogoProductos2Model>(sql, new { });
        }

        public async Task<CatalogoProductos2Model> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = 
                @"SELECT cp.*, e.Descripcion as Estado, ca.Descripcion as Categoria, im.foto FROM CatalogoProductos cp 
                JOIN ImagenesProductos im on cp.id_Producto = im.id_producto 
                JOIN Estado e ON cp.id_Estado = e.id_Estado
                JOIN CategoriaProductos ca ON cp.id_Categoria = ca.id_Categoria
                WHERE cp.id_Producto = @Id";

            return await db.QueryFirstOrDefaultAsync<CatalogoProductos2Model>(sql, new { Id = id });
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
