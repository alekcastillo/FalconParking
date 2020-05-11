using System.ComponentModel;

namespace Domain.Entities
{
    public enum ParkingSlotReservationTime
    {
        [Description("15 minutos")]
        QuarterHour,

        [Description("Media hora")]
        HalfHour,

        [Description("Una hora")]
        OneHour,
    }
}
