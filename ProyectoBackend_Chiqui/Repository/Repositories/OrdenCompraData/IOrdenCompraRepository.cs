using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.OrdenCompraData
{
    public interface IOrdenCompraRepository
    {
        Task<IEnumerable<OrdenCompraModel>> GetAllOrden();
        Task<OrdenCompraModel> GetDetails(int id);
        Task<bool> InsertOrden(OrdenCompraModel OrdenCompra);
        Task<bool> UpdateOrden(OrdenCompraModel OrdenCompra);
        Task<bool> DeleteOrden(OrdenCompraModel OrdenCompra);
    }
}
