﻿using System.ComponentModel;

namespace FalconParking.Domain.Entities
{
    public enum ParkingSlotStatus
    {
        [Description("Disponible")]
        Available,

        [Description("Ocupado")]
        Occuppied,

        [Description("Reservado")]
        Reserved,

        [Description("Cerrado temporalmente")]
        Closed
    }
}
