using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Empresa;
using ControleDeProdutos_API.Models;

namespace ControleDeProdutos_API.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<CreateEmpresaDto, Empresa>();
            CreateMap<Empresa, ReadEmpresaDto>();
            CreateMap<UpdateEmpresaDto, Empresa>();
        }
    }
}
