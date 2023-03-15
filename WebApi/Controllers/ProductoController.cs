using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> productoRepository;
        private readonly IMapper mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            this.productoRepository = productoRepository;
            this.mapper = mapper;
        }




        [HttpGet] 
        public async Task<ActionResult<Pagination<ProductoDto>>> GetProductos([FromQuery]ProductoSpecificationParams productoParams)
        {
            //Siempre que se devuelva un IReadonlyList, la info debe estar dentro del ok

            var spec = new ProductoWithCategoriaAndMarcaSpecification(productoParams);

            var productos = await productoRepository.GetAllWithSpec(spec);

            var specCount = new ProductoForCountingSpecification(productoParams);

            var totalProductos = await productoRepository.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoParams.pageSize)); // me devuelve la cantidad de paginas

            var totalPages = Convert.ToInt32(rounded);

            var data = mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos);

            return Ok(
                        new Pagination<ProductoDto>
                        {
                            Count = totalProductos,
                            Data = data,
                            PageCount = totalPages,
                            PageIndex = productoParams.PageIndex,
                            PageSize = productoParams.pageSize
                        }
                    );
            //return Ok(mapper.Map<IReadOnlyList<Producto>,IReadOnlyList<ProductoDto>>(productos));
        }





        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int Id)
        {
            //Spec: debe incluir la logica  de la condicion  de la consulta  y tambien las relaciones entre las entidades
            //relacion entre producto y marca,categoria

            var spec = new ProductoWithCategoriaAndMarcaSpecification(Id);
            var producto =  await productoRepository.GetByIdWithSpec(spec);


            if(producto == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }


            //<origen, destino>
            return mapper.Map<Producto,ProductoDto>(producto);

        }
















    }









}
