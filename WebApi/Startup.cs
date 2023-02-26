using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

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


            services.AddDbContext<MarketDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });



            //Aqui le indico a la aplicacion que cuando se ejecute se va a crear un objeto de tipo productoRepository
            //Este objeto va a durar con vida el tiempo que dure la transaccion(unos milisegundos
            //Esto para que sean agiles, rapidos y de corta duracion
            services.AddTransient<IProductoRepository,ProductoRepository>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    
}
