using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Repository.Repositories.EstadoData
{
    public interface IEstadoRepository
    {
        Task<IEnumerable<EstadoModel>> GetAllEstado();
        Task<EstadoModel> GetDetails(int id);
        Task<bool> InsertEstado(EstadoModel estado);
        Task<bool> UpdateEstado(EstadoModel estado);
        Task<bool> DeleteEstado(EstadoModel estado);
    }
}
