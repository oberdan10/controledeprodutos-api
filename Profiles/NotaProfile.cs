using AutoMapper;
using ControleDeProdutos_API.Data.DTOs.Nota;
using ControleDeProdutos_API.Models;

namespace ControleDeProdutos_API.Profiles
{
    public class NotaProfile : Profile
    {
        public NotaProfile()
        {
            CreateMap<CreateNotaDto, Nota>();
            CreateMap<Nota, ReadNotaDto>();
            CreateMap<UpdateNotaDto, Nota>();
        }
    }
}
