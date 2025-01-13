using Hotel.Domain.Models.Enums;

namespace Hotel.Domain.Models.Dtos;

public record RoomDto(
    int Number,
    RoomType Type,
    double PricePerNight,
    Guid? Id);