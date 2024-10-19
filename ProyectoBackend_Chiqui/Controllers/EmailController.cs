using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.EmailData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpPost]
        [Route("CorreoBienvenida")]
        public IActionResult BienvenidaEmail(EmailModel emailModel)
        {
            _emailRepository.BienvenidaEmail(emailModel);
            return Ok();
        }

        //[HttpPost]
       // [Route("CorreoRecuperarPass")]
       // public IActionResult ContraRecuEmail(EmailModel emailModel)
        //{
         //   _emailRepository.RecContraseña(emailModel);
           // return Ok();
       // }
    }
}
