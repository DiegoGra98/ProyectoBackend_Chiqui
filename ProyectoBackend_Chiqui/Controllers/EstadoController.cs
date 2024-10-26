using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.RolData;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Repository.Repositories.EstadoData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Estado")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoController(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        [HttpGet]
        [Route("ListEstados")]
        public async Task<IActionResult> GetAllEstado()
        {
            return Ok(await _estadoRepository.GetAllEstado());
        }

        [HttpGet]
        [Route("ListEstado")]
        public async Task<IActionResult> GetEstadoDetails(int id)
        {
            return Ok(await _estadoRepository.GetDetails(id));
        }

        [HttpPost]
        [Route("NuevoEstado")]
        public async Task<IActionResult> RegisterRol([FromBody] EstadoModel estado)
        {
            if (estado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _estadoRepository.InsertEstado(estado);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarRol")]
        public async Task<IActionResult> UpdateRol([FromBody] EstadoModel estado)
        {
            if (estado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _estadoRepository.UpdateEstado(estado);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarRol")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var created = await _estadoRepository.DeleteEstado(new EstadoModel { id_Estado = id });

            return Created("created", created);
        }
    }
}
