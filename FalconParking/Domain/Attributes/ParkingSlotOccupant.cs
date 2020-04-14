using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingSlotOccupant
    {
        public string CarLicensePlate { get; private set; }

        public ParkingSlotOccupant(
            string carLicensePlate)
        {
            CarLicensePlate = carLicensePlate;
        }

    }
}
