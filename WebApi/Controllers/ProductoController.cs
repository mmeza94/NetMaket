using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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

            var spec = new ProductoWithCategoriaAndMarcaSpecification();
            var productos = await productoRepository.GetAllWithSpec(spec);
            return Ok(productos);
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<Producto>> GetProducto(int Id)
        {
            //Spec: debe incluir la logica  de la condicion  de la consulta  y tambien las relaciones entre las entidades
            //relacion entre producto y marca,categoria

            var spec = new ProductoWithCategoriaAndMarcaSpecification(Id);
            return await productoRepository.GetByIdWithSpec(spec);

        }
















    }









}
