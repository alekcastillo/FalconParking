using FalconParking.Infrastructure.Abstractions.Events;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;

namespace FalconParking.Domain
{
    public abstract class Aggregate
    {
        public Guid AggregateId { get; protected set; }
        private bool _domainEventHistoryInitialized;
        private readonly List<IDomainEvent> _domainEventHistory = new List<IDomainEvent>();
        private readonly List<IDomainEvent> _uncommittedDomainEvents = new List<IDomainEvent>();

        protected Aggregate(
            Guid aggregateId)
        {
            this.AggregateId = aggregateId;
        }

        public List<IDomainEvent> GetDomainEventHistory()
        {
            return _domainEventHistory;
        }

        public List<IDomainEvent> GetUncommittedDomainEvents()
        {
            return _uncommittedDomainEvents;
        }

        private void ApplyDomainEvent(IDomainEvent domainEvent)
        {
            try
            {
                ((dynamic)this).Apply((dynamic)domainEvent);
            }
            catch(RuntimeBinderException rbe)
            {
                throw new InvalidOperationException($"No se pudo llamar el metodo Apply para el evento {domainEvent.GetType().Name}", rbe);
            }
        }

        public void CommitDomainEvents()
        {
            _domainEventHistory.AddRange(_uncommittedDomainEvents);
            _uncommittedDomainEvents.Clear();
        }

        protected void RaiseEvent(IDomainEvent domainEvent)
        {
            //If the event is unable to be applied should it still be added to the uncommited log?
            this.ApplyDomainEvent(domainEvent);
            _uncommittedDomainEvents.Add(domainEvent);
        }

        public void InitializeDomainEventHistory(IEnumerable<IDomainEvent> domainEventHistory)
        {
            foreach (var domainEvent in domainEventHistory) {
                ApplyDomainEvent(domainEvent);
            }

            _domainEventHistory.AddRange(domainEventHistory);

            _domainEventHistoryInitialized = true;
        }
    }
}
