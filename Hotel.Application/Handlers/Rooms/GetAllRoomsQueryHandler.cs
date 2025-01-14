using Hotel.Application.Commands;
using Hotel.Application.Commands.Rooms;
using Hotel.Domain.Models.Entities;
using Hotel.Domain.Services;
using MediatR;

namespace Hotel.Application.Handlers.Rooms;

public class GetAllRoomsQueryHandler(IRoomService roomService) : IRequestHandler<GetAllRoomsQuery, IList<Room>>
{
    public async Task<IList<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
    {
        var rooms = await roomService.GetAllAsync();
        return rooms;
    }
}