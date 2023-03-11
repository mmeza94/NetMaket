using System.Net;
using System.Text.Json;
using WebApi.Errors;

namespace WebApi.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger; // Va a evaluar la clase exception
        private readonly IHostEnvironment _environment;


        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }



        //Todas las peticiones van a pasar por aqui, si ocurre un error, los atrapa este catch y les devuelve el error en formato json
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);


                var response = _environment.IsDevelopment()
                                    ? new CodeErrorException((int)HttpStatusCode.InternalServerError, e.Message, e.StackTrace.ToString())
                                    : new CodeErrorException((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions { PropertyNamingPolicy= JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

            }
        }







    }
}
