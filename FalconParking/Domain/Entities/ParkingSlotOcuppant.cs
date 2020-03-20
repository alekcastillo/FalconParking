using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingSlotOcuppant
    {
        private string carLicensePlate { get; set; }

        public ParkingSlotOcuppant(
            string CarLicensePlate)
        {
            carLicensePlate = CarLicensePlate;
        }

    }
}
