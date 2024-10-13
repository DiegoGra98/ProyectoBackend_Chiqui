using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.RolData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Rol")]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        [HttpGet]
        [Route("ListRoles")]
        public async Task<IActionResult> GetAllRol()
        {
            return Ok(await _rolRepository.GetAllRol());
        }

        [HttpGet]
        [Route("ListRol")]
        public async Task<IActionResult> GetRolDetails(int id)
        {
            return Ok(await _rolRepository.GetRol(id));
        }

        [HttpPost]
        [Route("NuevoRol")]
        public async Task<IActionResult> RegisterRol([FromBody] RolModel rol)
        {
            if (rol == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _rolRepository.InsertRol(rol);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarRol")]
        public async Task<IActionResult> UpdateRol([FromBody] RolModel rol)
        {
            if (rol == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _rolRepository.UpdateRol(rol);

            return Ok(new { Message = "Rol actualizado con éxito." });
        }

        [HttpDelete]
        [Route("EliminarRol")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            await _rolRepository.DeleteRol(new RolModel { id_Rol = id });

            return Ok(new { Message = "Rol eliminado con éxito." });
        }
    }
}
