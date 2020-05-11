using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Attributes
{
    public enum ParkingLotStatus
    {
        [Description("Abierto")]
        Open,

        [Description("Cerrado")]
        Closed
    }
}
