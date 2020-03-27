using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FalconParking.Domain.Events;

namespace FalconParking.Domain.Interfaces
{
    public interface IParkingEventRepository : IEventRepository<ParkingEvent>
    {
        IEnumerable<ParkingEvent> GetParkingSlotEventsSinceLastOpen(string parkingLotId);
    }
}
