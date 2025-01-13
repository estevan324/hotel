using Hotel.Domain.Models.Dtos;
using Hotel.Domain.Models.Entities;

namespace Hotel.Domain.Services;

public interface IRoomService
{
    Task<IList<Room>> GetAllAsync(Func<Room, bool>? where);
    Task<Room> GetByIdAsync(Guid id);
    Task<Room> AddAsync(RoomDto roomDto);
    Task<Room> UpdateAsync(Guid id, RoomDto roomDto);
    Task DeleteAsync(Guid id);
}