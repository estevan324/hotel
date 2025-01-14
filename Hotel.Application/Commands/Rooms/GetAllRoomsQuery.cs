using Hotel.Domain.Models.Entities;
using MediatR;

namespace Hotel.Application.Commands.Rooms;

public class GetAllRoomsQuery : IRequest<IList<Room>>
{ }