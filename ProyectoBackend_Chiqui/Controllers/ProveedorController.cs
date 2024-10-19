using Microsoft.AspNetCore.Mvc;
using ProyectoBackend_Chiqui.Data.Repositories.ProveedorData;
using ProyectoBackend_Chiqui.Model;

namespace ProyectoBackend_Chiqui.Controllers
{
    [ApiController]
    [Route("Proveedor")]
    public class ProveedorController:ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpGet]
        [Route("ListProveedores")]
        public async Task<IActionResult> GetAllProveedor()
        {
            return Ok(await _proveedorRepository.GetAllProveedor());
        }

        [HttpGet]
        [Route("ListProveedor")]
        public async Task<IActionResult> GetProveedorDetails(int id)
        {
            return Ok(await _proveedorRepository.GetDetails(id));
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> RegisterProveedor([FromBody] ProveedorModel Proveedor)
        {
            if (Proveedor == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _proveedorRepository.InsertProveedor(Proveedor);
            return Created("created", created);
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> UpdateProveedor([FromBody] ProveedorModel Proveedor)
        {
            if (Proveedor == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _proveedorRepository.UpdateProveedor(Proveedor);

            return Created("created", created);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var created = await _proveedorRepository.DeleteProveedor(new ProveedorModel { id_Proveedor = id });

            return Created("created", created);
        }

    }
}
