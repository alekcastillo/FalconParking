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
        public static ParkingLotEventModel SerializeEvent(this IDomainEvent domainEvent)
        {
            return new ParkingLotEventModel(
                new Guid()
                ,domainEvent.AggregateId
                ,domainEvent.GetType().Name
                ,JsonConvert.SerializeObject(domainEvent)
                ,domainEvent.TimeCreated);
        }

        public static IDomainEvent DeserializeEvent(this DomainEventModel eventModel)
        {
            Type eventType;

            try
            {
                eventType = Type.GetType($"FalconParking.Domain.Events.{eventModel.EventType}");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al serializar evento: {ex}");
            }

            return (IDomainEvent) JsonConvert.DeserializeObject(eventModel.EventData, eventType);
        }
    }
}
