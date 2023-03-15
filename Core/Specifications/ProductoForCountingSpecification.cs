using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoForCountingSpecification:BaseSpecification<Producto>
    {

        //Se agrega el constructor con filtros porque queremos contar la cantidad de registros que devuelve ya  filtrado
        public ProductoForCountingSpecification(ProductoSpecificationParams productoParams)
                    : base(x => (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search))
                             && (!productoParams.Marca.HasValue || x.MarcaId == productoParams.Marca) // si marca tiene valor, hace el filtro consiguiente
                             && (!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria))

            
        {

        }




    }
}
