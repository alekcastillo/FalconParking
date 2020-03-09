using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    class ParkingLot
    {
        public int id { get; private set; }
        public string code { get; private set; }
        public float x { get; private set; }
        public float y { get; private set; }
        public int totalSlots { get; private set; }
    }
}
