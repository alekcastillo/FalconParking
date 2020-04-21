using FalconParking.Domain.Entities;
using FalconParking.Infrastructure.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotReservedEvent : ParkingSlotEvent
    {
        public int ReservationTime { get; }

        public ParkingSlotReservedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,int reservationTime
         ) : base(
            aggregateId
            ,currentUserId)
        {
            ReservationTime = reservationTime;
        }
    }
}
