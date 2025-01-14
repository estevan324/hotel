using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Hotel.Domain.Models.Entities;
using Hotel.Domain.Models.Enums;
using MediatR;

namespace Hotel.Application.Commands.Rooms;

[method: JsonConstructor]
public class CreateRoomCommand(int number, string type, double pricePerNight) : IRequest<Room>
{
    [JsonPropertyName("number")] 
    public int Number { get; set; } = number;
    
    [JsonPropertyName("type")] 
    public string Type { get; set; } = type;

    [JsonPropertyName("pricePerNight")] 
    public double PricePerNight { get; set; } = pricePerNight;
}
