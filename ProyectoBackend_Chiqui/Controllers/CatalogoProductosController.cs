using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.CategoriaData;
using ProyectoBackend_Chiqui.Model;
using ProyectoBackend_Chiqui.Repository.Repositories.CatalogoProductosData;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("CatalogoaProducto")]
    public class CatalogoProductosController : ControllerBase
    {
        private readonly ICatalogoProductosRepository _catalogoProductosRepository;

        public CatalogoProductosController(ICatalogoProductosRepository catalogoProductosRepository)
        {
            _catalogoProductosRepository = catalogoProductosRepository;
        }

        [HttpGet]
        [Route("ListProductos")]
        public async Task<IActionResult> GetAllProductos()
        {
            return Ok(await _catalogoProductosRepository.GetAllProducto());
        }

        [HttpGet]
        [Route("ListProducto")]
        public async Task<IActionResult> GetProductolDetails(int id)
        {
            return Ok(await _catalogoProductosRepository.GetDetails(id));
        }

        [HttpPost]
        [Route("NuevoProducto")]
        public async Task<IActionResult> RegisterProducto([FromBody] CatalogoProductosModel catalogoProductos)
        {
            if (catalogoProductos == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var created = await _catalogoProductosRepository.InsertProducto(catalogoProductos);
            return Created("created", created);
        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> UpdateProducto([FromBody] CatalogoProductosModel catalogoProductos)
        {
            if (catalogoProductos == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _catalogoProductosRepository.UpdateProducto(catalogoProductos);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var created = await _catalogoProductosRepository.DeleteProducto(new CatalogoProductosModel { id_Producto = id });

            return Created("created", created);
        }
    }
}
