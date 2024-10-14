using ProyectoBackend_Chiqui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBackend_Chiqui.Data.Repositories.CategoriaData
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<CategoriaModel>> GetAllCategoria();
        Task<CategoriaModel> GetCategoria(int id);
        Task<bool> InsertCategoria(CategoriaModel categoria);
        Task<bool> UpdateCategoria(CategoriaModel categoria);
    }
}
