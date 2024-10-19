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
            var created = await _usuarioRepository.UpdateUsuario(Usuario);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var created =  await _usuarioRepository.DeleteUsuario(new UsuarioModel {id_Usuario = id});

            return Created("created", created);
        }

        [HttpPost]
        [Route("CodigoRecuperacion")]
        public async Task<IActionResult> RecContraseña([FromBody] UsuarioModel Usuario)
        {
            var created = await _usuarioRepository.RecContraseña(Usuario);

            return Created("created", created);
        }

        [HttpPut]
        [Route("CambiarContraseña")]
        public async Task<IActionResult> UpdateContraseña([FromBody] UsuarioModel Usuario)
        {
            if (Usuario == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _usuarioRepository.CambiarContraseña(Usuario);

            return Created("created", created);
        }

        [HttpGet]
        [Route("ValidarCodigo")]
        public async Task<IActionResult> ValidarCodigo(int codigo)
        {
            var created = await _usuarioRepository.ValidarCodigo(codigo);

            return Created("created", created);
        }
    }
}
