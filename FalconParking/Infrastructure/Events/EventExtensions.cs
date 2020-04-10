using FalconParking.Domain.Events;
using FalconParking.Infrastructure.Abstractions.Events;
using FalconParking.Infrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Events
{
    public static class EventExtensions
    {
        public static EventModel ToEventModel(this object domainEvent)
        {
            var DomainEvent = (DomainEvent) domainEvent;

            return new EventModel(
                new Guid()
                ,DomainEvent.AggregateId
                ,DomainEvent.GetType().Name
                ,JsonConvert.SerializeObject(DomainEvent)
                ,DomainEvent.TimeCreated);
        }

        public static IDomainEvent DeserializeEvent(this EventModel eventModel)
        {
            var eventType = default(Type);

            try
            {
                eventType = Type.GetType($"FalconParking.Domain.Events.{eventModel.EventType}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("Class load error, because: {0}", ex));
            }

            return (IDomainEvent) JsonConvert.DeserializeObject(eventModel.EventData, eventType);
        }
    }
}
