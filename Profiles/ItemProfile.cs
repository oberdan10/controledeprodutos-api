using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Item;
using ControleDeProdutos_API.Models;

namespace ControleDeProdutos_API.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile() 
        {
            CreateMap<CreateItemDto, Item>();
            CreateMap<Item, ReadItemDto>();
            CreateMap<UpdateItemDto, Item>();
        }
    }
}

//Instalar AutoMapper.Extensions.Microsoft.DependencyInjection.
//Instalar AutoMapper.