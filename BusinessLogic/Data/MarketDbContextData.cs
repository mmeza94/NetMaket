using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarketDbContextData
    {

        public static async Task CargarData (MarketDbContext context, ILoggerFactory loggerFactory)
        {

            try
            {
                if (!context.Marcas.Any())
                {
                    var information = File.ReadAllText("../BusinessLogic/CargarData/marca.json");
                    var marcas = JsonSerializer.Deserialize<List<Marca>>(information);

                    foreach (var marca in marcas)
                    {
                        context.Add(marca);
                    }
                    
                    await context.SaveChangesAsync();

                }

                if (!context.Categorias.Any())
                {
                    var information = File.ReadAllText("../BusinessLogic/CargarData/categoria.json");
                    var categorias = JsonSerializer.Deserialize<List<Categoria>>(information);

                    foreach (var categoria in categorias)
                    {
                        context.Add(categoria);
                    }

                    await context.SaveChangesAsync();

                }


                if (!context.Productos.Any())
                {
                    var information = File.ReadAllText("../BusinessLogic/CargarData/producto.json");
                    var productos = JsonSerializer.Deserialize<List<Producto>>(information);

                    foreach (var producto in productos)
                    {
                        context.Add(producto);
                    }

                    await context.SaveChangesAsync();

                }

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<MarketDbContextData>();
                logger.LogError(e.Message);
                
            }

        }
            
    }
}
