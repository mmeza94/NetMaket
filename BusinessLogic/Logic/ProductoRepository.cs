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
            return await context.Productos.FindAsync(Id);
        }

        public async Task<IReadOnlyList<Producto>> GetProductosAsync()
        {
            return await context.Productos.ToListAsync();
        }
    }
}
