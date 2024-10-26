using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.PedidoData
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<PedidoModel>> GetAllPedidoUsr(int id_usuario);
        Task<PedidoModel> GetDetailsUsr(int id_pedido, int id_usuario);
        Task<IEnumerable<PedidoModel>> GetAllPedidoAd();
        Task<PedidoModel> GetDetailsAd(int id_pedido);
        Task<int> InsertPedido(PedidoModel pedido);
        Task<bool> UpdatePedido(PedidoModel pedido);
        Task<bool> DeletePedido(PedidoModel pedido);
        Task<bool> finalizarPedido(PedidoModel pedido);
    }
}
