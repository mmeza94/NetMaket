using Core.Entities;
using Core.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IGenericRepository<Categoria> categoriaRepository;


        public CategoriaController(IGenericRepository<Categoria> CategoriaRepository)
        {
            categoriaRepository = CategoriaRepository;
        }



        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategoriaAll()
        {
            return Ok(await categoriaRepository.GetAllAsync());

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            return await categoriaRepository.GetByIdAsync(id);
        }



    }
}
