using ProyectoBackend_Chiqui.Data;
using ProyectoBackend_Chiqui.Data.Repositories.OrdenCompraData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.OrdenCompraData
{
    public class OrdenCompraRepository : IOrdenCompraRepository
    {
        private readonly MySQLConfiguration _connectionString;

        public OrdenCompraRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> DeleteUsuario(OrdenCompraModel OrdenCompra)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrdenCompraModel>> GetAllUsuario()
        {
            throw new NotImplementedException();
        }

        public async Task<OrdenCompraModel> GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertUsuario(OrdenCompraModel OrdenCompra)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUsuario(OrdenCompraModel OrdenCompra)
        {
            throw new NotImplementedException();
        }
    }
}
