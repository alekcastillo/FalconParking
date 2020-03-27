using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FalconParking.Domain.Attributes
{
    public enum ParkingLotStatus
    {
        [Description("Abierto")]
        Open,

        [Description("Cerrado")]
        Closed
    }
}
