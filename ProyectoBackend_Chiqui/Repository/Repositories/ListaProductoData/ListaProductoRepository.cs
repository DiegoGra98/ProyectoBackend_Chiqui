using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.ListaProductoData
{
    public class ListaProductoRepository : IListaProductoRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ListaProductoRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<ListaProductoModel>> GetAllProducto()
        {
            var db = dbConnection();

            var sql = @"SELECT 
                cp.id_Producto, cp.Descripcion as Producto, 
                cat.Descripcion as Categoria, 
                e.Descripcion as Estado, 
                ip.Ultimo_Precio_Venta as Precio_Venta,
                ip.Existencia,
                im.foto
                FROM CatalogoProductos cp 
                JOIN CategoriaProductos cat ON cp.id_Categoria = cat.id_Categoria
                JOIN Estado e ON cp.id_Estado = e.id_Estado
                JOIN InventarioProducto ip ON cp.id_Producto = ip.id_Producto
                JOIN ImagenesProductos im ON cp.id_Producto = im.id_producto
                WHERE cp.id_Estado = 1;";

            return await db.QueryAsync<ListaProductoModel>(sql, new { });
        }
    }
}
