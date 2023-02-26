using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            //Siempre que se devuelva un IReadonlyList, la info debe estar dentro del ok
            var productos = await productoRepository.GetProductosAsync();
            return Ok(productos);
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<Producto>> GetProducto(int Id)
        {
            return await productoRepository.GetProductoByIdAsync(Id);

        }
















    }









}
