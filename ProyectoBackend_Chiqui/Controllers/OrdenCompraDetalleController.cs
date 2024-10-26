using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Repository.Repositories.OrdenCompraDetalleData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("OrdenDetalle")]
    public class OrdenCompraDetalleController : ControllerBase
    {
        private readonly IOrdenCompraDetalleRepository _ordenCompraDetalleRepository;

        public OrdenCompraDetalleController(IOrdenCompraDetalleRepository ordenCompraDetalle)
        {
            _ordenCompraDetalleRepository = ordenCompraDetalle;
        }

        [HttpGet]
        [Route("ListDetalle")]
        public async Task<IActionResult> GetDetallelDetails(int id)
        {
            return Ok(await _ordenCompraDetalleRepository.GetDetalle(id));
        }

        [HttpPost]
        [Route("NuevaOrdenDetalle")]
        public async Task<IActionResult> RegisterOrden([FromBody] OrdenCompraDetalleModel ordenCompraDetalle)
        {
            if (ordenCompraDetalle == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _ordenCompraDetalleRepository.InsertDetalle(ordenCompraDetalle);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarOrdenDetalle")]
        public async Task<IActionResult> UpdateOrden([FromBody] OrdenCompraDetalleModel ordenCompraDetalle)
        {
            if (ordenCompraDetalle == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _ordenCompraDetalleRepository.UpdateDetalle(ordenCompraDetalle);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarOrdenDetalle")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var created = await _ordenCompraDetalleRepository.DeleteDetalle(new OrdenCompraDetalleModel { id_Orden_deta = id });

            return Created("created", created);
        }
    }
}
