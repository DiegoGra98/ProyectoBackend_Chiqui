using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.LoginData;
using ProyectoBackend_Chiqui.Repository.Repositories.ListaProductoData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("ListaProductos")]
    public class ListaProductoController : ControllerBase
    {
        private readonly IListaProductoRepository _listaProductoRepository;

        public ListaProductoController(IListaProductoRepository listaProductoRepository)
        {
            _listaProductoRepository = listaProductoRepository;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> GetAllOrdenes()
        {
            return Ok(await _listaProductoRepository.GetAllProducto());
        }
    }
}
