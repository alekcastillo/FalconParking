using FalconParking.Domain.Events;
using FalconParking.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Events
{
    public static class EventExtensions
    {
        public static EventModel ToEventModel(this DomainEvent domainEvent)
        {
            return new EventModel(
                new Guid(),
                domainEvent.AggregateId,
                domainEvent.GetType().Name,
                "{}"
                );
        }

        public static object DeserializeEvent(this EventModel eventModel)
        {
            var eventClrTypeName = eventModel.EventType;
            return JsonConvert.DeserializeObject(eventModel.EventData, Type.GetType(eventModel.EventType));
        }
    }
}
