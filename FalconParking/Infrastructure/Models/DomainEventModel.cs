using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FalconParking.Infrastructure.Models
{
    public abstract class DomainEventModel
    {
        [Key]
        public Guid EventId { get; private set; }
        public Guid AggregateId { get; private set; }
        public string EventType { get; private set; }

        [Column(TypeName = "jsonb")]
        public string EventData { get; private set; }
        public DateTimeOffset CreatedTime { get; private set; }

        public DomainEventModel(
            Guid eventId
            ,Guid aggregateId
            ,string eventType
            ,string eventData
            ,DateTimeOffset createdTime)
        {
            EventId = eventId;
            AggregateId = aggregateId;
            EventType = eventType;
            EventData = eventData;
            CreatedTime = createdTime;
        }
    }
}
