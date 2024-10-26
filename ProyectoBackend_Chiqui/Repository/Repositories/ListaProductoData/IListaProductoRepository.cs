using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.ListaProductoData
{
    public interface IListaProductoRepository
    {
        Task<IEnumerable<ListaProductoModel>> GetAllProducto();
    }
}
