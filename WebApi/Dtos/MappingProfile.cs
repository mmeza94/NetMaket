using AutoMapper;
using Core.Entities;

namespace WebApi.Dtos
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {                                               // Campo destino   ----  proviene de --- Campo 
            CreateMap<Producto, ProductoDto>()
                        .ForMember(p => p.CategoriaNombre, x => x.MapFrom(a => a.Categoria.Nombre))
                        .ForMember(p => p.MarcaNombre, x => x.MapFrom(a => a.Marca.Nombre));
        }


    }
}
