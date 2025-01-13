using Hotel.Domain.Models.Enums;

namespace Hotel.Domain.Models.Entities;

public class Room : BaseEntity
{
    public int Number { get; set; }
    public RoomType Type { get; set; }
    public double PricePerNight { get; set; }
    public IList<Reservation> Reservations { get; set; }
}