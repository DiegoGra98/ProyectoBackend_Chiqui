using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.ProveedorData
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<ProveedorModel>> GetAllProveedor();
        Task<ProveedorModel> GetDetails(int id);
        Task<bool> InsertProveedor(ProveedorModel proveedor);
        Task<bool> UpdateProveedor(ProveedorModel proveedor);
        Task<bool> DeleteProveedor(ProveedorModel proveedor);
    }
}
