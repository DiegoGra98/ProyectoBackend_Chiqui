using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Repository.Repositories.PedidoDetalleData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("PedidoDetalle")]
    public class PedidoDetalleController : ControllerBase
    {
        private readonly IPedidoDetalleRepository _pedidoDetalleRepository;

        public PedidoDetalleController(IPedidoDetalleRepository pedidoDetalle)
        {
            _pedidoDetalleRepository = pedidoDetalle;
        }

        [HttpGet]
        [Route("ListDetalle")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _pedidoDetalleRepository.GetDetails(id));
        }

        [HttpPost]
        [Route("NuevoDetalle")]
        public async Task<IActionResult> RegisterRol([FromBody] PedidoDetalleModel pedidoDetalle)
        {
            if (pedidoDetalle == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _pedidoDetalleRepository.InsertDetalle(pedidoDetalle);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarDetalle")]
        public async Task<IActionResult> UpdateRol([FromBody] PedidoDetalleModel pedidoDetalle)
        {
            if (pedidoDetalle == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _pedidoDetalleRepository.UpdateDetalle(pedidoDetalle);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarDetalle")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var created = await _pedidoDetalleRepository.DeleteDetalle(new PedidoDetalleModel { id_Detalle_Pedido = id });

            return Created("created", created);
        }
    }
}
