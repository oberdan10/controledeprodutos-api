using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Funcionario;
using ControleDeProdutos_API.Models;

namespace ControleDeProdutos_API.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile() 
        {
            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, ReadFuncionarioDto>();
            CreateMap<UpdateFuncionarioDto, Funcionario>();
        }
    }
}

//Instalar AutoMapper.Extensions.Microsoft.DependencyInjection.
//Instalar AutoMapper.