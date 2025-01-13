using System.ComponentModel;

namespace Hotel.Domain.Models.Enums;

public enum RoomType
{
    [Description("Single")]
    Single,
    
    [Description("Suite")]
    Suite
}