using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.OrdenCompraData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("OrdenCompra")]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IOrdenCompraRepository _ordenCompraRepository;

        public OrdenCompraController(IOrdenCompraRepository ordenCompra)
        {
            _ordenCompraRepository = ordenCompra;
        }

        [HttpGet]
        [Route("ListOrdenes")]
        public async Task<IActionResult> GetAllOrdenes()
        {
            return Ok(await _ordenCompraRepository.GetAllOrden());
        }

        [HttpGet]
        [Route("ListOrden")]
        public async Task<IActionResult> GetOrdenDetails(int id)
        {
            return Ok(await _ordenCompraRepository.GetDetails(id));
        }

        [HttpPost]
        [Route("NuevaOrdenCompra")]
        public async Task<IActionResult> RegisterOrden([FromBody] OrdenCompraModel ordenCompra)
        {
            if (ordenCompra == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _ordenCompraRepository.InsertOrden(ordenCompra);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarOrdenCompra")]
        public async Task<IActionResult> UpdateOrden([FromBody] OrdenCompraModel ordenCompra)
        {
            if (ordenCompra == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ordenCompraRepository.UpdateOrden(ordenCompra);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarOrdenCompra")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var created = await _ordenCompraRepository.DeleteOrden(new OrdenCompraModel { id_Orden_Enca = id });

            return Created("created", created);
        }
    }
}
