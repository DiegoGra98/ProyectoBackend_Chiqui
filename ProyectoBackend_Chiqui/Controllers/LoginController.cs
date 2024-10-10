using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.LoginData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<IActionResult> GetLogin([FromBody] LoginModel login)
        {
            // Validación del modelo recibido
            if (!ModelState.IsValid)
            {
                return BadRequest("Datos inválidos.");
            }

            try
            {
                // Intentar obtener el usuario del repositorio
                var usuarioEncontrado = await _loginRepository.GetLogin(login);

                if (usuarioEncontrado == null)
                {
                    // Si no se encuentra el usuario, devolver una respues ta 404 (no encontrado)
                    return NotFound("Usuario o contraseña incorrectos.");
                }

                // Si se encuentra el usuario, devolver una respuesta 200 con los detalles
                return Ok(usuarioEncontrado);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

    }
}
