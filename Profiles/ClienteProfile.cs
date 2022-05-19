using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Cliente;
using ControleDeProdutos_API.Models;

namespace ControleDeProdutos_API.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteJuridicoDto>();
            CreateMap<Cliente, ReadClienteFisicoDto>();
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
