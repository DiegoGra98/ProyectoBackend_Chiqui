using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.InventarioProductoData
{
    public interface IInventarioProductoRepository
    {
        Task<IEnumerable<InventarioProductoModel>> GetAllInventario();
        Task<InventarioProductoModel> GetDetail(int id);
        Task<bool> UpdateInventario(InventarioProductoModel inventario);
    }
}
