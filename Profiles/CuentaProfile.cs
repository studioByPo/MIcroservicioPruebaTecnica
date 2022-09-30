using AutoMapper;
using MicroservicioPrueba.Dto;
using MicroservicioPrueba.Entities;
namespace MicroservicioPrueba.Profiles;

public class CuentaProfile : Profile
{
    public CuentaProfile()
    {
        CreateMap<Cuenta, CuentaDto>()
            .ForMember(dest => dest.numero, opt => opt.MapFrom(src => src.cu_numero))
            .ForMember(dest => dest.cliente, opt => opt.MapFrom(src => src.cu_cliente))
            .ForMember(dest => dest.tipo, opt => opt.MapFrom(src => src.cu_tipo))
            .ForMember(dest => dest.saldo, opt => opt.MapFrom(src => src.cu_saldo))
            .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.cu_estado));

        CreateMap<CuentaDto, Cuenta>()
            .ForMember(dest => dest.cu_numero, opt => opt.MapFrom(src => src.numero))
            .ForMember(dest => dest.cu_cliente, opt => opt.MapFrom(src => src.cliente))
            .ForMember(dest => dest.cu_tipo, opt => opt.MapFrom(src => src.tipo))
            .ForMember(dest => dest.cu_saldo, opt => opt.MapFrom(src => src.saldo))
            .ForMember(dest => dest.cu_estado, opt => opt.MapFrom(src => src.estado));
    }
}
