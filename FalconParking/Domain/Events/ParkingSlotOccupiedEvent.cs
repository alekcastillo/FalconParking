using FalconParking.Domain.Entities;
using FalconParking.Infrastructure.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotOccupiedEvent : ParkingSlotEvent
    {
        public string OccupantLicensePlate { get; }

        public ParkingSlotOccupiedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,string occupant
         ) : base(
            aggregateId
            ,currentUserId)
        {
            OccupantLicensePlate = occupant;
        }
    }
}
