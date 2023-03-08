using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<Producto> productoRepository;
        private readonly IMapper mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            this.productoRepository = productoRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            //Siempre que se devuelva un IReadonlyList, la info debe estar dentro del ok

            var spec = new ProductoWithCategoriaAndMarcaSpecification();
            var productos = await productoRepository.GetAllWithSpec(spec);
            return Ok(mapper.Map<IReadOnlyList<Producto>,IReadOnlyList<ProductoDto>>(productos));
        }



        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int Id)
        {
            //Spec: debe incluir la logica  de la condicion  de la consulta  y tambien las relaciones entre las entidades
            //relacion entre producto y marca,categoria

            var spec = new ProductoWithCategoriaAndMarcaSpecification(Id);
            var producto =  await productoRepository.GetByIdWithSpec(spec);

            //<origen, destino>
            return mapper.Map<Producto,ProductoDto>(producto);

        }
















    }









}
