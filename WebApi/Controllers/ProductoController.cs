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
        private readonly IGenericRepository<Producto> productoRepository;

        public ProductoController(IGenericRepository<Producto> productoRepository)
        {
            this.productoRepository = productoRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            //Siempre que se devuelva un IReadonlyList, la info debe estar dentro del ok
            var productos = await productoRepository.GetAllAsync();
            return Ok(productos);
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<Producto>> GetProducto(int Id)
        {
            return await productoRepository.GetByIdAsync(Id);

        }
















    }









}
