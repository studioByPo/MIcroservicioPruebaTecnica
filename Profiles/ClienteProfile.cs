using AutoMapper;
using MicroservicioPrueba.Dto;
using MicroservicioPrueba.Entities;

namespace MicroservicioPrueba.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteDto>()
            .ForMember(dest=>dest.nombre, opt=>opt.MapFrom(src=>src.pr_nombre))
            .ForMember(dest => dest.genero, opt => opt.MapFrom(src => src.pr_genero))
            .ForMember(dest => dest.identificacion, opt => opt.MapFrom(src => src.pr_identificacion))
            .ForMember(dest => dest.edad, opt => opt.MapFrom(src => src.pr_edad))
            .ForMember(dest => dest.direccion, opt => opt.MapFrom(src => src.pr_direccion))
            .ForMember(dest => dest.telefono, opt => opt.MapFrom(src => src.pr_telefono))
            .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.cl_estado))
            .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.cl_password));
        
        CreateMap<ClienteDto, Cliente>()
            .ForMember(dest => dest.pr_nombre, opt => opt.MapFrom(src => src.nombre))
            .ForMember(dest => dest.pr_genero, opt => opt.MapFrom(src => src.genero))
            .ForMember(dest => dest.pr_identificacion, opt => opt.MapFrom(src => src.identificacion))
            .ForMember(dest => dest.pr_edad, opt => opt.MapFrom(src => src.edad))
            .ForMember(dest => dest.pr_direccion, opt => opt.MapFrom(src => src.direccion))
            .ForMember(dest => dest.pr_telefono, opt => opt.MapFrom(src => src.telefono))
            .ForMember(dest => dest.cl_estado, opt => opt.MapFrom(src => src.estado))
            .ForMember(dest => dest.cl_password, opt => opt.MapFrom(src => src.password));
    }
}
