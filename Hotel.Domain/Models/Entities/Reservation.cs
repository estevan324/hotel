namespace Hotel.Domain.Models.Entities;

public class Reservation : BaseEntity
{
    public string GuestName { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public Room Room { get; set; }
    public Guid RoomId { get; set; }
}
