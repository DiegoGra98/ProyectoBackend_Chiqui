using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Repository.Repositories.PedidoData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        [Route("ListPedidosUsr")]
        public async Task<IActionResult> GetAllPedidoUsr(int id_Usuario)
        {
            return Ok(await _pedidoRepository.GetAllPedidoUsr(id_Usuario));
        }

        [HttpGet]
        [Route("ListPedidosAdm")]
        public async Task<IActionResult> GetAllPedidoAdm()
        {
            return Ok(await _pedidoRepository.GetAllPedidoAd());
        }

        [HttpGet]
        [Route("ListPedidoUsr")]
        public async Task<IActionResult> GetDetailsUsr(int id_Pedido, int id_Usuario)
        {
            return Ok(await _pedidoRepository.GetDetailsUsr(id_Pedido, id_Usuario));
        }

        [HttpGet]
        [Route("ListPedidoAdm")]
        public async Task<IActionResult> GetDetailsAdm(int id_Pedido)
        {
            return Ok(await _pedidoRepository.GetDetailsAd(id_Pedido));
        }

        [HttpPost]
        [Route("InsertarPedido")]
        public async Task<IActionResult> RegisterPedido([FromBody] PedidoModel pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            int createdId = await _pedidoRepository.InsertPedido(pedido);

            if (createdId > 0)
            {
                return CreatedAtAction(nameof(RegisterPedido), new { id = createdId }, createdId);
            }
            else
            {
                return StatusCode(500, "Error al crear el pedido.");
            }
        }

        [HttpPut]
        [Route("ActualizarPedido")]
        public async Task<IActionResult> UpdateRol([FromBody] PedidoModel pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _pedidoRepository.UpdatePedido(pedido);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarPedido")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var created = await _pedidoRepository.DeletePedido(new PedidoModel { id_Pedido = id });

            return Created("created", created);
        }
    }
}
