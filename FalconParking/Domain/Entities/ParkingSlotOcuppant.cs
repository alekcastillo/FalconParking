using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingSlotOcuppant
    {
        public string carLicensePlate { get; private set; }

        public ParkingSlotOcuppant(
            string CarLicensePlate)
        {
            carLicensePlate = CarLicensePlate;
        }

    }
}
