using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FalconParking.Infrastructure.Models
{
    public class EventModel
    {
        [Key]
        public Guid EventId { get; private set; }
        public int AggregateId { get; private set; }
        public string EventType { get; private set; }

        [Column(TypeName = "jsonb")]
        public string EventData { get; private set; }
        public DateTimeOffset TimeCreated { get; private set; }

        public EventModel(
            Guid eventId
            ,int aggregateId
            ,string eventType
            ,string eventData
            ,DateTimeOffset timeCreated)
        {
            EventId = eventId;
            AggregateId = aggregateId;
            EventType = eventType;
            EventData = eventData;
            TimeCreated = timeCreated;
        }
    }
}
