using FalconParking.Domain.Events;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public abstract class Aggregate
    {
        public int AggregateId { get; protected set; }
        private bool _domainEventHistoryInitialized;
        private readonly List<DomainEvent> _domainEventHistory = new List<DomainEvent>();
        private readonly List<DomainEvent> _uncommittedDomainEvents = new List<DomainEvent>();

        protected Aggregate(int aggregateId)
        {
            this.AggregateId = aggregateId;
        }

        public List<DomainEvent> GetDomainEventHistory()
        {
            return _domainEventHistory;
        }

        public List<DomainEvent> GetUncommittedDomainEvents()
        {
            return _uncommittedDomainEvents;
        }

        private void ApplyDomainEvent(DomainEvent domainEvent)
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

        protected void RaiseEvent(DomainEvent domainEvent)
        {
            //If the event is unable to be applied should it still be added to the uncommited log?
            this.ApplyDomainEvent(domainEvent);
            _uncommittedDomainEvents.Add(domainEvent);
        }

        public void InitializeDomainEventHistory(IEnumerable<DomainEvent> domainEventHistory)
        {
            // Add the entire domain event history to aggregate state
            _domainEventHistory.AddRange(domainEventHistory);

            _domainEventHistoryInitialized = true;
        }
    }
}
