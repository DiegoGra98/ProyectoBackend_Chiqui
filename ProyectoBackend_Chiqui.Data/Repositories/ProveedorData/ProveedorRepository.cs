using Dapper;
using MySql.Data.MySqlClient;
using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.ProveedorData
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public ProveedorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteProveedor(ProveedorModel proveedor)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM Proveedores WHERE id_Proveedor = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = proveedor.id_Proveedor});

            return result > 0;
        }

        public async Task<IEnumerable<ProveedorModel>> GetAllProveedor()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Proveedores";

            return await db.QueryAsync<ProveedorModel>(sql, new { });
        }

        public async Task<ProveedorModel> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM Proveedores WHERE id_Proveedor = @Id";

            return await db.QueryFirstOrDefaultAsync<ProveedorModel>(sql, new { Id = id });
        }

        public async Task<bool> InsertProveedor(ProveedorModel proveedor)
        {
            var db = dbConnection();

            var sql = @"CALL InsertarProveedor (@Nombre_Proveedor,@Nombre_Contacto,@Direccion,@Telefono,@Correo)";

            var result = await db.ExecuteAsync(sql, new { proveedor.Nombre_Proveedor, proveedor.Nombre_Contacto, proveedor.Direccion, proveedor.Telefono, proveedor.Correo });

            return result > 0;
        }

        public async Task<bool> UpdateProveedor(ProveedorModel proveedor)
        {
            var db = dbConnection();

            var sql = @"UPDATE Proveedores 
            SET    
            Nombre_Proveedor = @Nombre_Proveedor,
            Nombre_Contacto = @Nombre_Contacto,
            Direccion = @Direccion,
            Telefono = @Telefono,
            Correo = @Correo
            WHERE id_Proveedor = @id_Proveedor";

            var result = await db.ExecuteAsync(sql, new { proveedor.Nombre_Proveedor, proveedor.Nombre_Contacto, proveedor.Direccion, proveedor.Telefono, proveedor.Correo, proveedor.id_Proveedor });

            return result > 0;
        }
    }
}
