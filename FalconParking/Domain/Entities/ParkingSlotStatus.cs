using System.ComponentModel;

namespace FalconParking.Domain.Entities
{
    public enum ParkingSlotStatus
    {
        [Description("Available")]
        AVAILABLE,

        [Description("Occuppied")]
        OCCUPPIED,

        [Description("Reserved")]
        RESERVED,

        [Description("Temporarily closed")]
        CLOSED
    }
}
