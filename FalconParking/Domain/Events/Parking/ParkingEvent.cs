using FalconParking.Domain.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public abstract class ParkingEvent : DomainEvent, IDomainEvent
    {
        public ParkingEvent(
            int parkingLotId) : base(parkingLotId)
        {
        }
    }
}
