using FalconParking.Domain.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Infrastructure.Commands
{
    public class DomainCommand : ICommand<int>
    {
        public enum DomainCommandType
        {
            CREATE,
            UPDATE,
            DELETE
        }

        //public DomainCommandType Type { get; }
        public int AggregateId { get; }

        //CalledBy

        public DomainCommand(int aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
