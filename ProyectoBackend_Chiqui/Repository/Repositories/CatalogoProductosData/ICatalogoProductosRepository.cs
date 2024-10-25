using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.CatalogoProductosData
{
    public interface ICatalogoProductosRepository
    {
        Task<IEnumerable<CatalogoProductos2Model>> GetAllProducto();
        Task<CatalogoProductos2Model> GetDetails(int id);
        Task<bool> InsertProducto(CatalogoProductosModel catalogoProducto);
        Task<bool> UpdateProducto(CatalogoProductosModel catalogoProducto);
        Task<bool> DeleteProducto(CatalogoProductosModel catalogoProducto);
    }
}
