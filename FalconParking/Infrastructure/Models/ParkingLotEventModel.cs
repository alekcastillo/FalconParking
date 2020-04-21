using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FalconParking.Infrastructure.Models
{
    [Table("lot_eventlog", Schema = "parking")]
    public class ParkingLotEventModel : DomainEventModel
    {
        public ParkingLotEventModel(
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
