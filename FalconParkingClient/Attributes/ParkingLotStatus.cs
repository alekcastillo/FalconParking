using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FalconParkingClient.Attributes
{
    public enum ParkingLotStatus
    {
        [Description("Abierto")]
        Abierto,

        [Description("Cerrado")]
        Cerrado
    }
}
