using Hotel.Application.Commands.Rooms;
using Hotel.Application.Exceptions;
using Hotel.Domain.Models.Dtos;
using Hotel.Domain.Models.Entities;
using Hotel.Domain.Models.Enums;
using Hotel.Domain.Services;
using MediatR;

namespace Hotel.Application.Handlers.Rooms;

public class CreateRoomCommandHandler(IRoomService roomService) : IRequestHandler<CreateRoomCommand, Room>
{
    public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var converted = Enum.TryParse<RoomType>(request.Type, out RoomType type);

        if (!converted)
            throw new BadRequestException("Room type must be Single or Suite");
        
        var roomDto = new RoomDto(
            Number: request.Number,
            Type: type,
            PricePerNight: request.PricePerNight);

        var room = await roomService.AddAsync(roomDto);

        return room;
    }
}