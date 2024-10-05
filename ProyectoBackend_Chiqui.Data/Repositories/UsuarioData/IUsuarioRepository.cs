using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.UsuarioData
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<UsuarioModel>> GetAllUsuario();
        Task<UsuarioModel> GetDetails(int id);
        Task<bool> InsertUsuario(UsuarioModel usuario);
        Task<bool> UpdateUsuario(UsuarioModel usuario);
        Task<bool> DeleteUsuario(UsuarioModel usuario);
    }
}
