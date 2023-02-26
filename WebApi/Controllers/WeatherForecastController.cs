using BusinessLogic.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly MarketDbContext context;
        private readonly ILoggerFactory logger;

        public WeatherForecastController(MarketDbContext context,ILoggerFactory logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> PostInfo()
        {

            await MarketDbContextData.CargarData(context, logger);
            return Ok("Hola mundo");
        }
    }
}