using AutoMapper;
using ControleDeProdutos_API.DTOs.Categoria;
using ControleDeProdutos_API.Models;

namespace ControleDeProdutos_API.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile() 
        {
            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>();
            CreateMap<UpdateCategoriaDto, Categoria>();
        }
    }
}

//Instalar AutoMapper.Extensions.Microsoft.DependencyInjection.
//Instalar AutoMapper.