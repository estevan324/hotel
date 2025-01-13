using AutoMapper;
using Hotel.Application.Exceptions;
using Hotel.Domain.Models.Dtos;
using Hotel.Domain.Models.Entities;
using Hotel.Domain.Repositories;
using Hotel.Domain.Services;

namespace Hotel.Application.Services;

public class RoomService(IRepository<Room> repository, IMapper mapper) : IRoomService
{
    public async Task<IList<Room>> GetAllAsync(Func<Room, bool>? where)
    {
        var rooms = await repository.GetAllAsync();

        if (where is not null)
            rooms = rooms.Where(where);

        return rooms.ToList();
    }

    public async Task<Room> GetByIdAsync(Guid id)
    {
        var room = await repository.GetByIdAsync(id);

        if (room is null)
            throw new NotFoundException("Room not found");

        return room;
    }

    public async Task<Room> AddAsync(RoomDto roomDto)
    {
        var room = mapper.Map<Room>(roomDto);
        return await repository.AddAsync(room);
    }

    public async Task<Room> UpdateAsync(Guid id, RoomDto roomDto)
    {
        await GetByIdAsync(id);
        var roomEntity = mapper.Map<Room>(roomDto);
        
        await repository.UpdateAsync(
            id, 
            roomEntity);

        return roomEntity;
    }

    public async Task DeleteAsync(Guid id)
    {
        await GetByIdAsync(id);
        await repository.DeleteAsync(id);
    }
}