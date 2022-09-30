using AutoMapper;
using MicroservicioPrueba.Dto;
using MicroservicioPrueba.Entities;

namespace MicroservicioPrueba.Profiles;

public class MovimientoProfile : Profile
{
    public MovimientoProfile()
    {
        CreateMap<Movimientos, MovimientoDto>()
            .ForMember(dest => dest.valor, opt => opt.MapFrom(src => src.mo_valor))
            .ForMember(dest => dest.id_cuenta, opt => opt.MapFrom(src => src.mo_id_cuenta))
            .ForMember(dest => dest.saldo_final, opt => opt.MapFrom(src => src.mo_saldo_final));

        CreateMap<MovimientoDto, Movimientos>()
            .ForMember(dest => dest.mo_valor, opt => opt.MapFrom(src => src.valor))
            .ForMember(dest => dest.mo_id_cuenta, opt => opt.MapFrom(src => src.id_cuenta))
            .ForMember(dest => dest.mo_saldo_final, opt => opt.MapFrom(src => src.saldo_final));
    }
}
