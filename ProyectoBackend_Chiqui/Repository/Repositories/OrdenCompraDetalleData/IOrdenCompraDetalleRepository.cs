using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.OrdenCompraDetalleData
{
    public interface IOrdenCompraDetalleRepository
    {
        Task<IEnumerable<OrdenCompraDetalleModel>> GetDetalle(int id);
        Task<bool> InsertDetalle(OrdenCompraDetalleModel ordenDetalle);
        Task<bool> UpdateDetalle(OrdenCompraDetalleModel ordenDetalle);
        Task<bool> DeleteDetalle(OrdenCompraDetalleModel ordenDetalle);
    }
}
