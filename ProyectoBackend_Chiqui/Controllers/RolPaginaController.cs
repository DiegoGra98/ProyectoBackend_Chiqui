using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.RolPaginaData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("RolPagina")]
    public class RolPaginaController : ControllerBase
    {
        private readonly IRolPaginaRepository _rolPaginaRepository;

        public RolPaginaController(IRolPaginaRepository rolPaginaRepository)
        {
            _rolPaginaRepository = rolPaginaRepository;
        }

        [HttpGet]
        [Route("ListPaginas")]
        public async Task<IActionResult> GetAllPagina()
        {
            return Ok(await _rolPaginaRepository.GetAllPagina());
        }

        [HttpGet]
        [Route("ListPaginaRol")]
        public async Task<IActionResult> GetPaginaRol(int id_Rol)
        {
            return Ok(await _rolPaginaRepository.GetPaginaRol(id_Rol));
        }

        [HttpPost]
        [Route("AgregarPaginaRol")]
        public async Task<IActionResult> RegisterUsuario([FromBody] RolPaginaModel rolPagina)
        {
            if (rolPagina == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _rolPaginaRepository.InsertRolPagina(rolPagina);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarPaginaRol")]
        public async Task<IActionResult> UpdateRolPagina([FromBody] RolPaginaModel rolPagina)
        {
            if (rolPagina == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _rolPaginaRepository.UpdateRolPagina(rolPagina);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarPaginaRol")]
        public async Task<IActionResult> DeleteRolPagina(int id)
        {
            var created = await _rolPaginaRepository.DeleteRolPagina(new RolPaginaModel { idRol_Pagina = id });

            return Created("created", created);
        }
    }
}
