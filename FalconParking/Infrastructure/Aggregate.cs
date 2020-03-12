using FalconParking.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    class Aggregate
    {
        public Guid AggregateId { get; protected set; }
        private bool _domainEventHistoryInitialized;
        private readonly List<DomainEvent> _domainEventHistory = new List<DomainEvent>();
        private readonly List<DomainEvent> _uncommittedDomainEvents = new List<DomainEvent>();
        private readonly List<DomainEvent> _stagedDomainEvents = new List<DomainEvent>();

        public IReadOnlyList<DomainEvent> DomainEventHistory
        {
            get { return _domainEventHistory.AsReadOnly(); }
            private set { this.InitializeDomainEventHistory(value); }
        }
    }
}
