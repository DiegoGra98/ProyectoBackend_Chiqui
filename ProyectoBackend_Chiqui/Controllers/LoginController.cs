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
        public async Task<IActionResult> GetLogin([FromBody] UsuarioModel Usuario)
        {

        }

    }
}
