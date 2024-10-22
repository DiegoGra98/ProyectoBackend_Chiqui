using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.RolPaginaData
{
    public interface IRolPaginaRepository
    {
        Task<IEnumerable<PaginaModel>> GetAllPagina();
        Task<IEnumerable<RolPagina2Model>> GetPaginaRol(int id_Rol);
        Task<bool> InsertRolPagina(RolPaginaModel rolPagina);
        Task<bool> UpdateRolPagina(RolPaginaModel rolPagina);
        Task<bool> DeleteRolPagina(RolPaginaModel rolPagina);
    }
}
