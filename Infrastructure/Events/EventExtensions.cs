using Domain.Events;
using Domain.Abstractions.Events;
using Infrastructure.Models;
using Newtonsoft.Json;
using System;

namespace Infrastructure.Events
{
    //This whole class must change as well

    public static class EventExtensions
    {
        public static ParkingLotEventModel ToParkingLotEvent(this IDomainEvent domainEvent)
        {
            return new ParkingLotEventModel(
                Guid.NewGuid()
                , domainEvent.AggregateId
                ,domainEvent.GetType().Name
                ,JsonConvert.SerializeObject(domainEvent)
                ,domainEvent.TimeCreated);
        }

        public static ParkingSlotEventModel ToParkingSlotEvent(this IDomainEvent domainEvent)
        {
            return new ParkingSlotEventModel(
                Guid.NewGuid()
                ,domainEvent.AggregateId
                ,domainEvent.GetType().Name
                ,JsonConvert.SerializeObject(domainEvent)
                ,domainEvent.TimeCreated);
        }

        public static IDomainEvent DeserializeEvent(this DomainEventModel eventModel)
        {
            var assembly = typeof(IDomainEvent).Assembly;
            Type eventType;

            try
            {
                eventType = assembly.GetType($"Domain.Events.{eventModel.EventType}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al serializar evento: {ex}");
            }

            return (IDomainEvent) JsonConvert.DeserializeObject(eventModel.EventData, eventType);
        }
    }
}
