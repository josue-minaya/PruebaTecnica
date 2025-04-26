using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PrubaTecnica.DTOs;
using PrubaTecnica.Models;
using PrubaTecnica.Service;

namespace PrubaTecnica.Controllers
{
    [ApiController]
    [Route("api")]
    [EnableCors("AllowSpecificOrigin")]

    // [Authorize] // Proteger todo el controlador
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [Route("productos")]
        public ActionResult<ApiResponse<IEnumerable<Producto>>> GetProduct()
        {
            var productos = _productoService.GetAll();
            var response = new ApiResponse<IEnumerable<Producto>>(true, "Productos obtenidos exitosamente", productos);
            return response;
        }

        [HttpPost]
        [Route("productos")]
        public ActionResult<ApiResponse<string>> AddProduct([FromBody] ProductoDTO productoDTO)
        {
            if (productoDTO == null)
            {
                var errorResponse = new ApiResponse<string>(false, "Producto no puede ser nulo.", null);
                return BadRequest(errorResponse);
            }

            _productoService.Add(productoDTO);
            var successResponse = new ApiResponse<string>(true, "Producto creado exitosamente.", null);
            return Ok(successResponse);
        }

        [HttpDelete("eliminar/{id}")]
        public ActionResult<ApiResponse<string>> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                var errorResponse = new ApiResponse<string>(false, "ID no puede ser menor o igual a cero.", null);
                return BadRequest(errorResponse);
            }

            _productoService.Delete(id);

            var successResponse = new ApiResponse<string>(true, "Producto eliminado exitosamente.", null);
           
            return Ok(successResponse);

           
        }
        [HttpPut]
        [Route("actualizar")]

        public ActionResult<ApiResponse<string>> UpdateProduct([FromBody] Producto producto)
        {
            if (producto == null)
            {
                var errorResponse = new ApiResponse<string>(false, "Producto no puede ser nulo.", null);
                return BadRequest(errorResponse);
            }
            _productoService.Update(producto);
            var successResponse = new ApiResponse<string>(true, "Producto actualizado exitosamente.", null);
            return Ok(successResponse);
        }

        [HttpGet("producto/{id}")]
        public ActionResult<ApiResponse<string>> GetProductId(int id)
        {
            if (id <= 0)
            {
                var errorResponse = new ApiResponse<string>(false, "ID no puede ser menor o igual a cero.", null);
                return BadRequest(errorResponse);
            }

            var producto=_productoService.GetProducto(id);

            var successResponse = new ApiResponse<Producto>(true, "Producto encontrado.", producto);

            return Ok(successResponse);


        }
    }
}