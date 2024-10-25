using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Repository.Repositories.InventarioProductoData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("InventarioProducto")]
    public class InventarioProductoController : ControllerBase
    {
        private readonly IInventarioProductoRepository _inventarioProductoRepository;

        public InventarioProductoController(IInventarioProductoRepository inventarioProductoRepository)
        {
            _inventarioProductoRepository = inventarioProductoRepository;
        }

        [HttpGet]
        [Route("ListInventarioC")]
        public async Task<IActionResult> GetAllInventario()
        {
            return Ok(await _inventarioProductoRepository.GetAllInventario());
        }

        [HttpGet]
        [Route("ListInventario")]
        public async Task<IActionResult> GetInventarioDetails(int id)
        {
            return Ok(await _inventarioProductoRepository.GetDetail(id));
        }

        [HttpPut]
        [Route("ActualizarInventario")]
        public async Task<IActionResult> UpdateInventario([FromBody] InventarioProductoModel inventario)
        {
            if (inventario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _inventarioProductoRepository.UpdateInventario(inventario);

            return Created("created", created);
        }
    }
}
