using PrubaTecnica.DTOs;
using PrubaTecnica.Models;
using AutoMapper;

namespace PrubaTecnica.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}
