using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.PedidoDetalleData
{
    public interface IPedidoDetalleRepository
    {
        Task<IEnumerable<PedidoDetalleModel>> GetDetails(int id);
        Task<bool> InsertDetalle(PedidoDetalleModel pedidoDetalle);
        Task<bool> UpdateDetalle(PedidoDetalleModel pedidoDetalle);
        Task<bool> DeleteDetalle(PedidoDetalleModel pedidoDetalle);
    }
}
