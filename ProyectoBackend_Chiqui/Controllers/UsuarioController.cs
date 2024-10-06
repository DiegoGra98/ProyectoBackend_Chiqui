using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.UsuarioData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("ListUsuarios")]
        public async Task<IActionResult> GetAllUsuario()
        {
            return Ok(await _usuarioRepository.GetAllUsuario());
        }

        [HttpGet]
        [Route("ListUsuario")]
        public async Task<IActionResult> GetUsuarioDetails(int id)
        {
            return Ok(await _usuarioRepository.GetDetails(id));
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> RegisterUsuario([FromBody]UsuarioModel Usuario)
        {
            if(Usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _usuarioRepository.InsertUsuario(Usuario);
            return Created("created", created);
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> UpdateUsuario([FromBody] UsuarioModel Usuario)
        {
            if (Usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _usuarioRepository.UpdateUsuario(Usuario);

            return Ok(new { Message = "Usuario actualizado con éxito." });
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
             await _usuarioRepository.DeleteUsuario(new UsuarioModel {id_Cliente = id});

            return Ok(new { Message = "Usuario eliminado con éxito." });
        }
    }
}
