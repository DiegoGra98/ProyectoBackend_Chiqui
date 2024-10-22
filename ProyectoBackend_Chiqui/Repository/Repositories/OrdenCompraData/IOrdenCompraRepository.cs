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
        Task<IEnumerable<OrdenCompraModel>> GetAllUsuario();
        Task<OrdenCompraModel> GetDetails(int id);
        Task<bool> InsertUsuario(OrdenCompraModel OrdenCompra);
        Task<bool> UpdateUsuario(OrdenCompraModel OrdenCompra);
        Task<bool> DeleteUsuario(OrdenCompraModel OrdenCompra);
    }
}
