using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Models
{
    [Table("slot_eventlog", Schema = "parking")]
    public class ParkingSlotEventModel : DomainEventModel
    {
        public ParkingSlotEventModel(
            Guid eventId
            ,Guid aggregateId
            ,string eventType
            ,string eventData
            ,DateTimeOffset createdTime
        ) : base(
            eventId
            ,aggregateId
            ,eventType
            ,eventData
            ,createdTime
        )
        {}
    }
}
