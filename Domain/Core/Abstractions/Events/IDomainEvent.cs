using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Abstractions.Events
{
    public interface IDomainEvent : INotification
    {
        Guid AggregateId { get; }
        DateTimeOffset TimeCreated { get; }
    }
}
