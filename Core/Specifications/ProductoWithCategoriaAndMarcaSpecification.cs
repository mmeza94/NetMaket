using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {//string sort, int? marca, int? categoria
        public ProductoWithCategoriaAndMarcaSpecification(ProductoSpecificationParams productoParams)
            : base(x =>  (string.IsNullOrEmpty(productoParams.Search) || x.Nombre.Contains(productoParams.Search))
                      && (!productoParams.Marca.HasValue || x.MarcaId == productoParams.Marca) // si marca tiene valor, hace el filtro consiguiente
                      && (!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria)

            )
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);


            //ApplyPagination(0,5);
            //productoParams.pageSize * (productoParams.PageIndex - 1)    -> esto representar el indice a partir del cual quiero comenzar a extraer los elementos

            ApplyPagination(productoParams.pageSize * (productoParams.PageIndex - 1), productoParams.pageSize);


            if (!string.IsNullOrEmpty(productoParams.Sort))
            {
                switch (productoParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDescending(p => p.Descripcion);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;

                }
            }
        }


        public ProductoWithCategoriaAndMarcaSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }



    }
}
