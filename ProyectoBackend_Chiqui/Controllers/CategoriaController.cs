using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.CategoriaData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("CategoriaProducto")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController (ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        [Route("ListCategorias")]
        public async Task<IActionResult> GetAllCategoria()
        {
            return Ok(await _categoriaRepository.GetAllCategoria());
        }

        [HttpGet]
        [Route("ListCategoria")]
        public async Task<IActionResult> GetCategorialDetails(int id)
        {
            return Ok(await _categoriaRepository.GetCategoria(id));
        }

        [HttpPost]
        [Route("NuevaCategoria")]
        public async Task<IActionResult> RegisterCategoria([FromBody] CategoriaModel categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _categoriaRepository.InsertCategoria(categoria);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarCategoria")]
        public async Task<IActionResult> UpdateCategoria([FromBody] CategoriaModel categoria)
        {
            if (categoria == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _categoriaRepository.UpdateCategoria(categoria);

            return Created("created", created);
        }
    }
}
