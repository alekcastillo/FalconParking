using System.ComponentModel;

namespace FalconParkingClient.Attributes
{
    public enum ParkingSlotStatus
    {
        [Description("Disponible")]
        Disponible,

        [Description("Ocupado")]
        Ocupado,

        [Description("Reservado")]
        Reservado,

        [Description("Cerrado temporalmente")]
        Cerrado
    }
}
