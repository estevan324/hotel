using AutoMapper;
using Hotel.Domain.Models.Dtos;
using Hotel.Domain.Models.Entities;

namespace Hotel.Application.Profiles;

public class RoomProfile : Profile
{
    public RoomProfile()
    {
        _ = CreateMap<RoomDto, Room>()
            .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
            .ForMember(dest => dest.Number, opts => opts.MapFrom(src => src.Number))
            .ForMember(dest => dest.Type, opts => opts.MapFrom(src => src.Type))
            .ForMember(dest => dest.PricePerNight, opts => opts.MapFrom(src => src.PricePerNight))
            .ForMember(dest => dest.Reservations, opts => opts.Ignore())
            .ForMember(dest => dest.CreatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.UpdatedAt, opts => opts.Ignore())
            .ForMember(dest => dest.DeletedAt, opts => opts.Ignore());
    }
}