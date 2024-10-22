using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.CatalogoProductosData
{
    public interface ICatalogoProductosRepository
    {
        Task<IEnumerable<CatalogoProductosModel>> GetAllProducto();
        Task<CatalogoProductosModel> GetDetails(int id);
        Task<bool> InsertProducto(CatalogoProductosModel catalogoProducto);
        Task<bool> UpdateProducto(CatalogoProductosModel catalogoProducto);
        Task<bool> DeleteProducto(CatalogoProductosModel catalogoProducto);
    }
}
