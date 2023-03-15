using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Middleware;

namespace WebApi
{
    public class Startup
    {
        //El IConfiguration me permite acceder a los achivos .json desde c#
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile));


            //Cuando arranque el programa se genera un objeto de tipo IGenericRepository por cada request que envie el cliente
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));

            services.AddDbContext<MarketDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });



            //Aqui le indico a la aplicacion que cuando se ejecute se va a crear un objeto de tipo productoRepository
            //Este objeto va a durar con vida el tiempo que dure la transaccion(unos milisegundos
            //Esto para que sean agiles, rapidos y de corta duracion
            services.AddTransient<IProductoRepository,ProductoRepository>();
            services.AddControllers();


            services.AddCors( opt =>
            {
                opt.AddPolicy("CorsRule", rule =>
                {
                    rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseStatusCodePagesWithReExecute("/errors","?code={0}"); //para que el code tambien se imprima para el cliente
            //If you want to intercept status codes in production and return custom error pages

            app.UseRouting();

            app.UseCors("CorsRule");


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    
}
