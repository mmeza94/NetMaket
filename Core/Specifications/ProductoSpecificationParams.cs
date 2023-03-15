using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductoSpecificationParams
    {
        public int? Marca { get; set; }
        public int? Categoria { get; set; }
        public string? Sort { get; set; }
        public int PageIndex { get; set; } = 1;//Por defecto su valor es = 1; -> si lo hago nuleable me da error int? a int no se puede convertir

        private const int MaxPageSize = 50;

        private int _pageSize = 3;

        public int pageSize   //Pro defecto, cada pagina tiene 6 registros
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize: value;
        }


        public string Search { get; set; }


    }
}
