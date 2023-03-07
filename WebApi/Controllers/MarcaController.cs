using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IGenericRepository<Marca> marcaRepository;

        public MarcaController(IGenericRepository<Marca> marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetMarcaAll()
        {
            return Ok(await marcaRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarcaById(int id)
        {
            return await marcaRepository.GetByIdAsync(id);
        }



    }
}
