using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.RolData
{
    public interface IRolRepository
    {
        Task<IEnumerable<RolModel>> GetAllRol();
        Task<RolModel> GetRol(int id);
        Task<bool> InsertRol(RolModel rol);
        Task<bool> UpdateRol(RolModel rol);
        Task<bool> DeleteRol(RolModel rol);
    }
}
