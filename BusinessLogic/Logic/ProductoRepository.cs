using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MarketDbContext context;

        public ProductoRepository(MarketDbContext context)
        {
            this.context = context;
        }


        public async Task<Producto> GetProductoByIdAsync(int Id)
        {
            var result =  await context.Productos
                                .Include(p => p.Marca)
                                .Include(p => p.Categoria)
                                .FirstOrDefaultAsync( p => p.Id == Id);

            return result;
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await context.Productos
                                .Include(p => p.Marca)
                                .Include(p => p.Categoria)
                                .ToListAsync();
        }
    }
}
