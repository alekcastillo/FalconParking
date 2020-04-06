using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingSlotOcuppant
    {
        public string CarLicensePlate { get; private set; }

        public ParkingSlotOcuppant(
            string carLicensePlate)
        {
            CarLicensePlate = carLicensePlate;
        }

    }
}
